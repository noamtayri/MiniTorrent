using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MiniTorrent.App.AppLogic
{
    public class ConfigLogic
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DownloadFolderPath { get; set; }
        public string UploadFolderPath { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        
        public ConfigLogic() { }

        public ConfigLogic(string userName, string password, string downloadFolderPath, string uploadFolderPath, string ipAddress, string port)
        {
            UserName = userName;
            Password = password;
            DownloadFolderPath = downloadFolderPath;
            UploadFolderPath = uploadFolderPath;
            IpAddress = ipAddress;
            Port = port;
        }

        public string GetDownPath()
        {
            string downPath="";
            XmlTextReader reader = new XmlTextReader("MyConfig.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "DownloadPath":
                            reader.Read();
                            downPath = reader.Value;
                            break;

                        default:
                            break;
                    }
                }
            }
            reader.Close();
            return downPath;
        }

        public string GetUpPath()
        {
            string upPath = "";
            XmlTextReader reader = new XmlTextReader("MyConfig.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "UploadPath":
                            reader.Read();
                            upPath = reader.Value;
                            break;

                        default:
                            break;
                    }
                }
            }
            reader.Close();
            return upPath;
        }
    }
}
