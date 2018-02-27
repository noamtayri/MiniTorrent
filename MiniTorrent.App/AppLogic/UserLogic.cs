using System;
using System.Collections.Generic;
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
        public void LoginButton_ClickLogic(string userName, string password, Window window)
        {
            var client = new MiniTorrentServiceClient();
            var user = client.Login(userName, password);

            if (user != null)
            {
                Window1 window1 = new Window1(user);
                window1.Show();
                window.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password", "Error");
            }
        }

        public void LoginFlagLogic(string userName)
        {
            var clinet = new MiniTorrentServiceClient();
            clinet.LoginFlag(userName);
        }

        public void LogoutFlagLogic(string userName, Window window)
        {
            var clinet = new MiniTorrentServiceClient();
            clinet.LogoutFlag(userName);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            window.Hide();
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
