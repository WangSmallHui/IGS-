namespace GPSDatasDownload
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFTP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.labStates = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.btnDownload = new System.Windows.Forms.Button();
            this.listItem = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBack = new System.Windows.Forms.Button();
            this.lblDown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "FTP地址：";
            // 
            // txtFTP
            // 
            this.txtFTP.Location = new System.Drawing.Point(65, 13);
            this.txtFTP.Name = "txtFTP";
            this.txtFTP.Size = new System.Drawing.Size(213, 21);
            this.txtFTP.TabIndex = 1;
            this.txtFTP.Text = "ftp://ftp.igs.org";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(285, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(71, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // labStates
            // 
            this.labStates.AutoSize = true;
            this.labStates.ForeColor = System.Drawing.Color.Red;
            this.labStates.Location = new System.Drawing.Point(362, 18);
            this.labStates.Name = "labStates";
            this.labStates.Size = new System.Drawing.Size(59, 12);
            this.labStates.TabIndex = 3;
            this.labStates.Text = "已断开...";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(14, 379);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(363, 23);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress.TabIndex = 5;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(383, 379);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(50, 23);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // listItem
            // 
            this.listItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listItem.FullRowSelect = true;
            this.listItem.Location = new System.Drawing.Point(14, 40);
            this.listItem.Name = "listItem";
            this.listItem.Size = new System.Drawing.Size(419, 305);
            this.listItem.TabIndex = 7;
            this.listItem.UseCompatibleStateImageBehavior = false;
            this.listItem.View = System.Windows.Forms.View.Details;
            this.listItem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listItem_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "大小";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "创建时间";
            this.columnHeader3.Width = 120;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(14, 350);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(419, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "返回上一级";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblDown
            // 
            this.lblDown.AutoSize = true;
            this.lblDown.Location = new System.Drawing.Point(18, 407);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(0, 12);
            this.lblDown.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 423);
            this.Controls.Add(this.lblDown);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.listItem);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.labStates);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtFTP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IGS数据下载by王会";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFTP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label labStates;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ListView listItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblDown;
    }
}

