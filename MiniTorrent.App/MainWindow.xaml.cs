using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MiniTorrent.App.AppLogic;
using MiniTorrent.App.MiniTorrentService;
using System.Xml;

namespace MiniTorrent.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserLogic _userLogic;
        private ConfigLogic _configLogic;
        public MainWindow()
        {
            InitializeComponent();
            UsernameTextBox.Focus();
            _userLogic = new UserLogic();
            KeyDown += OnEnterDownHandler;
            if (File.Exists("MyConfig.xml"))
            {
                string username = "", password = "";
                XmlTextReader reader = new XmlTextReader("MyConfig.xml");
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "UserName":
                                reader.Read();
                                username = reader.Value;
                                break;

                            case "Password":
                                reader.Read();
                                password = reader.Value;
                                break;
                        }
                    }
                }
                reader.Close();
                _userLogic.LoginButton_ClickLogic(username, password, this);
            }
        }
        
        /**
         * login button - check username and password
         */
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            UsernameTextBox.Text = "";
            PasswordBox.Password = "";
            UsernameTextBox.Focus();
            _userLogic.LoginButton_ClickLogic(username, password, this);

        }

        private void OnEnterDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton_Click(this, null);
            }
        }
    }
}
