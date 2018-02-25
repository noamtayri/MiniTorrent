using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MiniTorrent.App.MiniTorrentService;
using System.Windows;


namespace MiniTorrent.App.AppLogic
{
    public class FileLogic
    {
        public void SearchButton_ClickLogic(string fileName, ListView listView)
        {
            var client = new MiniTorrentServiceClient();
            var files = client.SearchFiles(fileName);
            if (files.Length != 0)
                listView.ItemsSource = files;
            else
            {
                listView.ItemsSource = null;
                MessageBox.Show("File not found", "Error");
            }
        }
    }
}
