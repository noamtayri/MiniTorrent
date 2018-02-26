using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
using MiniTorrent.App.AppLogic.Classes;
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
        private readonly FileLogic _fileLogic;
        private DownloadLogic _downloadLogic;
        private UploadLogic _uploadLogic;
        public TransferFile TempChoosedFile { get; set; }

        public Window1(User user)
        {
            InitializeComponent();
            MyUser = user;
            _userLogic = new UserLogic();
            _fileLogic = new FileLogic();
            Task.Factory.StartNew((() =>
            {
                _uploadLogic = new UploadLogic();
                _uploadLogic.MyUploadEvent += updateUploadTransferListView;
                _uploadLogic.UploadListener("C:\\Users\\USER\\Desktop\\Noam\\שנה ג\\סמסטר א\\תכנות ברשת NET\\פרויקט\\MiniTorrent\\up");
                //_uploadLogic.UploadListener("");
            }));

            _userLogic.LoginFlagLogic(MyUser.UserName);
            _userLogic.RetrieveUserFilesLogic(MyUser);
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {

            _userLogic.LogoutFlagLogic(MyUser.UserName, this);
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
            _fileLogic.SearchButton_ClickLogic(fileName, SearchResaultListView);
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchResaultListView.SelectedItem == null)
            {
                MessageBox.Show("You must choose a file", "Error");
            }
            else
            {
                var file = SearchResaultListView.SelectedItem as TransferFile;
                TempChoosedFile = file;
                if (MyUser.OwnedFiles.Any(a => a.FileName.Equals(file?.FileName)))
                    MessageBox.Show("You already own that file", "Error");
                else if (file.ResourcesNumber == 0)
                    MessageBox.Show("No resources for this file", "Error");
                else
                {
                    Task.Factory.StartNew((() =>
                    {
                        _downloadLogic = new DownloadLogic(file.FileName, file.FileSize, "C:\\Users\\USER\\Desktop\\Noam\\שנה ג\\סמסטר א\\תכנות ברשת NET\\פרויקט\\MiniTorrent\\down");
                        //_downloadLogic = new DownloadLogic(file.FileName, file.FileSize, "");
                        _downloadLogic.MyDownloadEvent += updateDownloadTransferListView;
                        _downloadLogic.Start();
                    }));                                       
                }
            }
        }

        private void updateUploadTransferListView(UploadFileInfo info)
        {
            Dispatcher.BeginInvoke(new Action(delegate()
            {
                foreach (TransferFile line in FileTransferListView.Items)
                {
                    if (line.FileName.Equals(info.FileName))
                        break;
                        line.Status = info.Status;
                }
                FileTransferListView.Items.Refresh();
            }));        
        }

        private void updateDownloadTransferListView(DownloadFileInfo info, bool isDone)
        {
            if (!isDone)
            {
                Dispatcher.BeginInvoke(new Action(delegate()
                {
                    //TransferFile newFile = SearchResaultListView.SelectedItem as TransferFile;
                    TransferFile newFile = TempChoosedFile;
                    newFile.Status = info.Status;
                    FileTransferListView.Items.Add(newFile);
                    FileTransferListView.Items.Refresh();
                }));
                /*
                //TransferFile newFile = SearchResaultListView.SelectedItem as TransferFile;
                TransferFile newFile = TempChoosedFile;
                newFile.Status = info.Status;
                FileTransferListView.Items.Add(newFile);
                */
            }
            else
            {
                Dispatcher.BeginInvoke(new Action(delegate()
                {
                    foreach (TransferFile line in FileTransferListView.Items)
                    {
                        if (line.FileName.Equals(info.FileName))
                        {
                            line.Status = info.Status;
                            line.Time = info.Time;
                            TransferFile[] a = new TransferFile[MyUser.OwnedFiles.Length + 1];
                            for (int i = 0; i < MyUser.OwnedFiles.Length; i++)
                                a[i] = MyUser.OwnedFiles[i];
                            a[a.Length] = line;
                            MyUser.OwnedFiles = a;
                            //MyUser.OwnedFiles[MyUser.OwnedFiles.Length] = line;
                        }
                    }
                    FileTransferListView.Items.Refresh();
                }));
                /*
                foreach (TransferFile line in FileTransferListView.Items)
                {
                    if (line.FileName.Equals(info.FileName))
                    {
                        line.Status = info.Status;
                        line.Time = info.Time;
                        TransferFile[] a = new TransferFile[MyUser.OwnedFiles.Length+1];
                        for (int i = 0; i < MyUser.OwnedFiles.Length; i++)
                            a[i] = MyUser.OwnedFiles[i];
                        a[a.Length] = line;
                        MyUser.OwnedFiles = a;
                        //MyUser.OwnedFiles[MyUser.OwnedFiles.Length] = line;
                    }
                }
                */
            }
            TempChoosedFile = null;
            
        }
    }
}
