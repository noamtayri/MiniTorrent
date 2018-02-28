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
using System.IO;

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
        private readonly ConfigLogic _configLogic;
        private DownloadLogic _downloadLogic;
        public UploadLogic _uploadLogic;
        public Window MainWindow { get; set; }
        public TransferFile TempChoosedFile { get; set; }
        private string downloadPath;
        private string uploadPath;

        public Window1(User user, Window mainWindow)
        {
            InitializeComponent();
            MyUser = user;
            this.MainWindow = mainWindow;
            _userLogic = new UserLogic();
            _fileLogic = new FileLogic();
            _configLogic = new ConfigLogic();
            //if (!File.Exists("MyConfig.xml"))
            //{
            //    downloadPath = "download";
            //    uploadPath = "upload";                
            //}
            //if (!Directory.Exists(_configLogic.DownloadFolderPath))
            //    Directory.CreateDirectory(_configLogic.DownloadFolderPath);
            //if (!Directory.Exists(_configLogic.UploadFolderPath))
            //    Directory.CreateDirectory(_configLogic.UploadFolderPath);
            downloadPath = _configLogic.GetDownPath();
            uploadPath = _configLogic.GetUpPath();
            Task.Factory.StartNew((() =>
            {
                _uploadLogic = new UploadLogic();
                _uploadLogic.MyUploadEvent += updateUploadTransferListView;
                _uploadLogic.UploadListener(uploadPath);
                //_uploadLogic.UploadListener("");
            }));
            _userLogic.RetrieveUserFilesLogic(MyUser, FileTransferListView);
            _userLogic.LoginFlagLogic(MyUser.UserName);
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            _uploadLogic.StopListener();
            _userLogic.LogoutFlagLogic(MyUser.UserName, this, MainWindow);
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
                _userLogic.RetrieveUserFilesLogic(MyUser);
                if (MyUser.OwnedFiles.Any(a => a.FileName.Equals(file?.FileName)))
                    MessageBox.Show("You already own that file", "Error");
                else if (file.ResourcesNumber == 0)
                    MessageBox.Show("No resources for this file", "Error");
                else
                {
                    Task.Factory.StartNew((() =>
                    {
                        _downloadLogic = new DownloadLogic(file.FileName, file.FileSize, downloadPath);
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
                TransferFile newFile = new TransferFile();
                newFile = TempChoosedFile;
                Dispatcher.BeginInvoke(new Action(delegate()
                {
                    newFile.Status = info.Status;
                    FileTransferListView.Items.Add(newFile);
                    FileTransferListView.Items.Refresh();
                }));
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
                            _userLogic.UpdateUserTransferFilesLogic(line.FileName, MyUser.UserName);
                            _fileLogic.CopyFileByPaths(line.FileName, downloadPath, uploadPath);
                        }
                    }
                    FileTransferListView.Items.Refresh();
                }));
            }
            TempChoosedFile = null;
            
        }

        private void ConfigButton_Click(object sender, RoutedEventArgs e)
        {
            EditMyConfigWindow editWindow = new EditMyConfigWindow(MyUser, this);
            editWindow.Show();
            this.Hide();
        }
    }
}
