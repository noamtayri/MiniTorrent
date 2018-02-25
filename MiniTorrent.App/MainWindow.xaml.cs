using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MiniTorrent.App.MiniTorrentService;

namespace MiniTorrent.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Class1 a = new Class1();
        }
        
        /**
         * login button - check username and password
         */
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            var client = new MiniTorrentServiceClient();
            var user = client.Login(username, password);

            //if (checkLogIn(username, password))
            if (user != null)
            {
                Window1 window1 = new Window1(user);
                window1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password", "Error");
            }        
        }
        /**
         * helper method to resemble check login parameters from Web Service
         */
        private Boolean checkLogIn(string username, string password)
        {
            Dictionary<string,string> identifiedusers = new Dictionary<string, string>();
            identifiedusers.Add("noam","1234");
            identifiedusers.Add("a","aaa");
            identifiedusers.Add("b","bbb");

            return identifiedusers.Any(entry => entry.Key == username && entry.Value == password);
        }
    }
}
