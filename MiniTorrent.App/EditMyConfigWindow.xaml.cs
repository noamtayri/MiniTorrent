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

namespace MiniTorrent.App
{
    /// <summary>
    /// Interaction logic for EditMyConfigWindow.xaml
    /// </summary>
    public partial class EditMyConfigWindow : Window
    {
        private Window window;

        public EditMyConfigWindow(Window window)
        {
            InitializeComponent();
            this.window = window;
            if (File.Exists("MyConfig.xml"))
            {
                readXmlFile("MyConfig.xml");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            writeXmlFile("MyConfig.xml");

            window.Show();
            this.Close();
        }

        private void writeXmlFile(string filePath)
        {
            //XmlWriterSettings xmlSettings = new XmlWriterSettings();
            //xmlSettings.Indent = true;
            //xmlSettings.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create(filePath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Client");

                writer.WriteStartElement("UserName");
                writer.WriteString(ConfigUsernameTextBox.Text);
                writer.WriteEndElement();

                writer.WriteStartElement("Password");
                writer.WriteString(ConfigPasswordBox.Password);
                writer.WriteEndElement();

                writer.WriteStartElement("DownloadPath");
                writer.WriteString(ConfigDownTextBox.Text);
                writer.WriteEndElement();

                writer.WriteStartElement("UploadPath");
                writer.WriteString(ConfigUpTextBox.Text);
                writer.WriteEndElement();

                writer.WriteStartElement("Ip");
                writer.WriteString(getMyIp());
                writer.WriteEndElement();

                writer.WriteStartElement("Port");
                writer.WriteString("8005");
                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Close();

            }
        }

        private void readXmlFile(string filePath)
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
                            ConfigUsernameTextBox.Text = reader.Value;
                            break;

                        case "Password":
                            reader.Read();
                            ConfigPasswordBox.Password = reader.Value;
                            break;
                            
                        case "DownloadPath":
                            reader.Read();
                            ConfigDownTextBox.Text = reader.Value;
                            break;

                        case "UploadPath":
                            reader.Read();
                            ConfigUpTextBox.Text = reader.Value;
                            break;

                        default:
                            break;
                    }
                }
            }
            reader.Close();
        }

        private string getMyIp()
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
            window.Show();
            this.Close();
        }
    }
}
