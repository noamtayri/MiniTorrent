using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniTorrent.App.MiniTorrentService;
using System.Windows;

namespace MiniTorrent.App.AppLogic
{
    public class UserLogic
    {
        public void LoginButton_ClickLogic(string userName, string password, Window window)
        {
            var client = new MiniTorrentServiceClient();
            var user = client.Login(userName, password);

            //if (checkLogIn(username, password))
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
    }
}
