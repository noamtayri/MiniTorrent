using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
using System.Xml;
using MiniTorrent.App.AppLogic;
using MiniTorrent.App.MiniTorrentService;

namespace MiniTorrent.App
{
    /// <summary>
    /// Interaction logic for EditMyConfigWindow.xaml
    /// </summary>
    public partial class EditMyConfigWindow : Window
    {
        private User oldUser;
        private ConfigLogic userFromConfig;
        private Window1 window1;
        private UploadLogic _uploadLogic;


        public EditMyConfigWindow(User myUser, Window1 window1)
        {
            InitializeComponent();
            _uploadLogic = new UploadLogic();
            oldUser = myUser;
            this.window1 = window1;
            if (File.Exists("MyConfig.xml"))
            {
                userFromConfig = new ConfigLogic();
                readXmlFile("MyConfig.xml", userFromConfig);
                setUserDetailsInTextBoxes(userFromConfig);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ConfigLogic userFromTextBox = new ConfigLogic(ConfigUsernameTextBox.Text, ConfigPasswordBox.Password, "downloads", "uploads", getMyIp(), "8005");
            writeXmlFile("MyConfig.xml", userFromTextBox);
            var client = new MiniTorrentServiceClient();
            client.UpdateUserDetails(oldUser.UserName, userFromTextBox.UserName, userFromTextBox.Password, getMyIp(), userFromTextBox.Port);
            _uploadLogic.StopListener();
            window1.Close();
            Window1 window = new Window1(new User
            { UserName = userFromTextBox.UserName,
                Password = userFromTextBox.Password,
                IP = userFromTextBox.IpAddress,
                Port = int.Parse(userFromTextBox.Port)               
            },window1.MainWindow);
            this.Close();
        }

        public static void writeXmlFile(string filePath, ConfigLogic newUser)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = "\t";
            using (XmlWriter writer = XmlWriter.Create(filePath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Client");

                writer.WriteStartElement("UserName");
                writer.WriteString(newUser.UserName);
                writer.WriteEndElement();

                writer.WriteStartElement("Password");
                writer.WriteString(newUser.Password);
                writer.WriteEndElement();

                writer.WriteStartElement("DownloadPath");
                writer.WriteString(newUser.DownloadFolderPath);
                writer.WriteEndElement();

                writer.WriteStartElement("UploadPath");
                writer.WriteString(newUser.UploadFolderPath);
                writer.WriteEndElement();

                writer.WriteStartElement("Ip");
                writer.WriteString(getMyIp());
                writer.WriteEndElement();

                writer.WriteStartElement("Port");
                writer.WriteString(newUser.Port);
                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Close();
            }
        }

        public static void readXmlFile(string filePath, ConfigLogic newUser)
        {
            XmlTextReader reader = new XmlTextReader(filePath);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "UserName":
                            reader.Read();
                            newUser.UserName = reader.Value;
                            break;

                        case "Password":
                            reader.Read();
                            newUser.Password = reader.Value;
                            break;
                            
                        case "DownloadPath":
                            reader.Read();
                            newUser.DownloadFolderPath = reader.Value;
                            break;

                        case "UploadPath":
                            reader.Read();
                            newUser.UploadFolderPath = reader.Value;
                            break;

                        case "Port":
                            reader.Read();
                            newUser.Port = reader.Value;
                            break;
                        default:
                            break;
                    }
                }
            }
            reader.Close();
            newUser.IpAddress = getMyIp();
        }

        private void setUserDetailsInTextBoxes(ConfigLogic user)
        {
            ConfigUsernameTextBox.Text = user.UserName;
            ConfigPasswordBox.Password = user.Password;
            ConfigDownTextBox.Text = user.DownloadFolderPath;
            ConfigUpTextBox.Text = user.UploadFolderPath;
            ConfigIPTextBox.Text = user.IpAddress;
            ConfigPortTextBox.Text = user.Port;
        }

        public static string getMyIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                    return ip.ToString();
            }
            return null;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            window1.Show();
            this.Close();
        }
    }
}
