using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MiniTorrent.App.AppLogic;
using MiniTorrent.App.MiniTorrentService;

namespace MiniTorrent.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserLogic _userLogic;

        public MainWindow()
        {
            InitializeComponent();
            _userLogic = new UserLogic();
        }
        
        /**
         * login button - check username and password
         */
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            _userLogic.LoginButton_ClickLogic(username, password, this);
        }
    }
}
