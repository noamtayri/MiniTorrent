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

namespace MiniTorrent.App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //list of file to download
            List<File> allFiles = new List<File>();
            allFiles = fileList();   

            //put the list of file to download in the list view
            SearchResaultListView.ItemsSource = allFiles;
            
            //handle in the search
            CollectionView view = (CollectionView) CollectionViewSource.GetDefaultView(SearchResaultListView.ItemsSource);
            view.Filter = FileFilter;
        }
        /**
         * helper for the listview filtering
         */
        private bool FileFilter(object item)
        {
            if (String.IsNullOrEmpty(SearchTextBox.Text))
            {
                return true;
            }                
            else
            {
                return ((item as File).fileName.IndexOf(SearchTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        /**
         * file class
         */
        public class File
        {
            public string fileName { get; set; }
            public int size { get; set; }
            public int resourcesNumber { get; set; }

            /**
             * builder
             */
            public File(string fileName, int size, int resourcesNumber)
            {
                this.fileName = fileName;
                this.size = size;
                this.resourcesNumber = resourcesNumber;
            }
        }

        /**
         * function that return list of files
         */
        private List<File> fileList()
        {
            List<File> allFiles = new List<File>();

            File file1 = new File("aaa bgt", 120, 2);
            File file2 = new File("bbb", 240, 1);
            File file3 = new File("ccc", 12, 0);
            File file4 = new File("ddd", 1010, 8);
            File file5 = new File("eee", 100, 3);

            allFiles.Add(file1);
            allFiles.Add(file2);
            allFiles.Add(file3);
            allFiles.Add(file4);
            allFiles.Add(file5);

            return allFiles;
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
            CollectionViewSource.GetDefaultView(SearchResaultListView.ItemsSource).Refresh();
        }
    }
}
