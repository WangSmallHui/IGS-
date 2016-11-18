using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace GPSDatasDownload
{
    public partial class Form1 : Form
    {
        private string URL = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (this.txtFTP.Text == string.Empty)
            {
                MessageBox.Show("要先输入FTP", "错误");
                return;
            }
            URL = this.txtFTP.Text;
            List<string> files = new List<string>();       
            LoadListViewItem(URL);
        }

        private void LoadListViewItem(string URL)
        {
            this.labStates.Text = "加载中...";
            this.labStates.ForeColor = Color.Green;
            this.listItem.Items.Clear();
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
            {
                List<string> ls = FTPHelper.FTPGetFile(URL);
                this.listItem.Invoke(new Action(() => { this.listItem.BeginUpdate(); }));
                foreach (var item in ls)
                {
                    string[] strs = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    ListViewItem lvi = new ListViewItem(strs[8]);
                    lvi.SubItems.Add(strs[4]);
                    lvi.SubItems.Add(strs[5] + " " + strs[6] + " " + strs[7]);
                    //异步加载
                    this.listItem.Invoke(new Action(() =>
                    {
                        this.listItem.Items.Add(lvi);
                    }));
                }
                this.listItem.Invoke(new Action(() => { this.listItem.EndUpdate();}));
                this.labStates.Invoke(new Action(() =>
                {
                    this.labStates.Text = "加载完毕...";
                }));
            }));
        }
        //双击进入下一级菜单
        private void listItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listItem.SelectedItems[0].Text.IndexOf('.') != -1)
            {
                string length = this.listItem.SelectedItems[0].SubItems[1].Text;
                string url = URL[URL.Length - 1] == '/' ? URL + this.listItem.SelectedItems[0].Text : URL + '/' + this.listItem.SelectedItems[0].Text;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = this.listItem.SelectedItems[0].Text;
                sfd.Filter = "所有文件(*.*)|*.*";
                if (DialogResult.OK == sfd.ShowDialog())
                    this.lblDown.Text = "正在下载:" + this.listItem.SelectedItems[0].Text;
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    FTPHelper.FTPDownLoad(url, sfd.FileName, length, progress);
                    this.lblDown.Invoke(new Action(() => { this.lblDown.Text = "下载完成"; }));
                }));

            }
            else
            {
                URL = URL[URL.Length - 1] == '/' ? URL + this.listItem.SelectedItems[0].Text : URL + '/' + this.listItem.SelectedItems[0].Text;
                this.txtFTP.Text = URL;
                LoadListViewItem(URL);
            }

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (URL.Length > 17)
            {
                URL = URL.Substring(0, URL.LastIndexOf('/'));
                this.txtFTP.Text = URL;
                LoadListViewItem(URL);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();
            if (DialogResult.OK == fdb.ShowDialog())
            {
                ListViewItem[] selectitems = new ListViewItem[this.listItem.SelectedItems.Count];
                listItem.SelectedItems.CopyTo(selectitems, 0);
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    foreach (ListViewItem item in selectitems)
                    {
                        string length = item.SubItems[1].Text;
                        string url = URL[URL.Length - 1] == '/' ? URL + item.Text : URL + '/' + item.Text;
                        this.lblDown.Invoke(new Action(() => { this.lblDown.Text = "正在下载:" + item.Text; }));
                        FTPHelper.FTPDownLoad(url, Path.Combine(fdb.SelectedPath, item.Text), length, progress);
                        this.lblDown.Invoke(new Action(() => { this.lblDown.Text = "下载完成"; }));
                        Thread.Sleep(100);
                    }       
                }));
            }
            
        }
    }
}
