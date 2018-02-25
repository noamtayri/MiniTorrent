using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MiniTorrent.App.AppLogic;
using MiniTorrent.App.MiniTorrentService;

namespace MiniTorrent.App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public User MyUser { get; set; }
        private readonly UserLogic _userLogic;

        public Window1(User user)
        {
            InitializeComponent();
            MyUser = user;
            _userLogic = new UserLogic();
            _userLogic.LoginFlagLogic(MyUser.UserName);
            //var clinet = new MiniTorrentServiceClient();
            //clinet.LoginFlag(MyUser.UserName);
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            _userLogic.LogoutFlagLogic(MyUser.UserName, this);
            //var clinet = new MiniTorrentServiceClient();
            //clinet.LogoutFlag(MyUser.UserName);
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            //this.Hide();
        }
        /**
         * search text box change - for search files
         */
        private void SearchTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            //CollectionViewSource.GetDefaultView(SearchResaultListView.ItemsSource).Refresh();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = SearchTextBox.Text;

            var client = new MiniTorrentServiceClient();
            var files = client.SearchFiles(fileName);
            if (files.Length != 0)
                SearchResaultListView.ItemsSource = files;
            else
            {
                SearchResaultListView.ItemsSource = null;
                MessageBox.Show("File not found", "Error");
            }
        }
    }
}
