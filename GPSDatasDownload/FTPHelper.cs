using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace GPSDatasDownload
{
    public class FTPHelper
    {
        public static List<string> FTPGetDirectory(string uri)
        {
            FtpWebRequest _ftp = null;
            List<string> filename = new List<string>();
            try
            {
                _ftp = (FtpWebRequest)FtpWebRequest.Create(uri);
                //IGS以及MIT等ftp都是无需密码
                _ftp.Credentials = new NetworkCredential("", "");
                //获取ftp文件夹列表
                _ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                _ftp.UseBinary = true;
                WebResponse response = _ftp.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        filename.Add(line);
                        line = reader.ReadLine();
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return filename;
        }
        public static int FTPGetFileSize(string uri)
        {
            int size = 0;
            FtpWebRequest _ftp = null;
            List<string> filename = new List<string>();
            try
            {
                _ftp = (FtpWebRequest)FtpWebRequest.Create(uri);
                //IGS以及MIT等ftp都是无需密码
                _ftp.Credentials = new NetworkCredential("", "");
                //获取ftp文件夹列表
                _ftp.Method = WebRequestMethods.Ftp.GetFileSize;
                _ftp.UseBinary = true;
                WebResponse response = _ftp.GetResponse();
                size = (int)response.ContentLength;
            }
            catch (Exception ex)
            {

            }
            return size;
        }
        public static List<string> FTPGetFile(string uri)
        {
            FtpWebRequest _ftp = null;
            List<string> filename = new List<string>();
            try
            {
                _ftp = (FtpWebRequest)FtpWebRequest.Create(uri);
                //IGS以及MIT等ftp都是无需密码
                _ftp.Credentials = new NetworkCredential("", "");
                //获取ftp文件夹列表
                _ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                _ftp.UseBinary = true;
                WebResponse response = _ftp.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        filename.Add(line);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return filename;
        }
        public static void FTPDownLoad(string uri, string path, string len, ProgressBar progress)
        {
            FtpWebRequest _ftp = null;
            List<string> filename = new List<string>();
            try
            {
                _ftp = (FtpWebRequest)FtpWebRequest.Create(uri);
                //IGS以及MIT等ftp都是无需密码
                _ftp.Credentials = new NetworkCredential("", "");
                _ftp.Method = WebRequestMethods.Ftp.DownloadFile;
                _ftp.UseBinary = true;
                using (Stream reader = _ftp.GetResponse().GetResponseStream())
                {
                    using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        int length = Convert.ToInt32(len);
                        int buffersize = 2 * 1024;
                        //这里采用字节，减少同时对磁盘的读写
                        byte[] buffer = new byte[buffersize];
                        int readlength = reader.Read(buffer, 0, buffersize);
                        progress.Invoke(new Action(() =>
                        {
                            progress.Value = 0;
                        }));
                        while (readlength != 0)
                        {
                            progress.Invoke(new Action(() =>
                            {
                                progress.Value += ((int)((1.0 * readlength / length) * 100) == 0 ? 1 : (int)((1.0 * readlength / length) * 100));
                            }));
                            stream.Write(buffer, 0, readlength);
                            readlength = reader.Read(buffer, 0, buffersize);
                        }
                        progress.Invoke(new Action(() =>
                        {
                            progress.Value = 100;
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }

}
