using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTorrent.App.AppLogic.Classes
{
    public class UploadFileInfo
    {
        public string FileName { get; set; }
        public long FileSize { get; set; } 
        //public int FileSize { get; set; }
        public string Status { get; set; }

        public UploadFileInfo(string fileName, long fileSize, string status)
        {
            FileName = fileName;
            FileSize = fileSize;
            Status = status;
        }
    }
}