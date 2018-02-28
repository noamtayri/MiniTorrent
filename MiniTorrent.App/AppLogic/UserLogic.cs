using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniTorrent.App.MiniTorrentService;
using System.Windows;
using System.Windows.Controls;

namespace MiniTorrent.App.AppLogic
{
    public class UserLogic
    {
        private ConfigLogic _configLogic;

        public void CheckLoginByConfig(string file, Window window)
        {
            
        }

        public bool LoginButton_ClickLogic(string userName, string password, Window window)
        {
            var client = new MiniTorrentServiceClient();
            var user = client.Login(userName, password);
            //ConfigLogic _configLogic = null;
            if (user != null)
            {
                if (!File.Exists("MyConfig.xml"))
                {                    
                    var _configLogic = new ConfigLogic(userName, password, "download", "upload", EditMyConfigWindow.getMyIp(), "8005");
                    EditMyConfigWindow.writeXmlFile("MyConfig.xml", _configLogic);
                    client.UpdateUserDetails(_configLogic.UserName, _configLogic.UserName, _configLogic.Password, _configLogic.IpAddress, _configLogic.Port);
                    if (!Directory.Exists(_configLogic.DownloadFolderPath))
                        Directory.CreateDirectory(_configLogic.DownloadFolderPath);
                    if (!Directory.Exists(_configLogic.UploadFolderPath))
                        Directory.CreateDirectory(_configLogic.UploadFolderPath);
                }
                Window1 window1 = new Window1(user, window);
                window1.Show();
                window.Hide();
                return true;
            }
            else
            {
                MessageBox.Show("Disabled user or Wrong username/password", "Error");
            }
            return false;
        }

        public void LoginFlagLogic(string userName)
        {
            var clinet = new MiniTorrentServiceClient();
            clinet.LoginFlag(userName);
        }

        public void LogoutFlagLogic(string userName, Window window, Window mainWindow)
        {
            if(File.Exists("MyConfig.xml"))
                File.Delete("MyConfig.xml");
            var clinet = new MiniTorrentServiceClient();
            clinet.LogoutFlag(userName);
            mainWindow.Show();
            window.Close();
        }

        public void RetrieveUserFilesLogic(User user)
        {
            var clinet = new MiniTorrentServiceClient();
            user.OwnedFiles = clinet.GetMyFiles(user.UserName);
        }

        public void RetrieveUserFilesLogic(User user, ListView view)
        {
            var clinet = new MiniTorrentServiceClient();
            user.OwnedFiles = clinet.GetMyFiles(user.UserName);
            foreach (var file in user.OwnedFiles)
            {
                file.Status = "Upload waiting";
                view.Items.Add(file);
            }
        }

        public void UpdateUserTransferFilesLogic(string fileName, string userName)
        {
            var clinet = new MiniTorrentServiceClient();
            clinet.UpdateUserFiles(fileName, userName);
        }
    }
}
