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
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            if (checkLogIn(username, password))
            {
                Window1 window1 = new Window1();
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
