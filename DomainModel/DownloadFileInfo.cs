using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class DownloadFileInfo
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        //public int fileSize { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
        public int Kbps { get; set; }

        public DownloadFileInfo(string fileName, long fileSize, string status, string time, int kbps)
        {
            FileName = fileName;
            FileSize = fileSize;
            Status = status;
            Time = time;
            Kbps = kbps;
        }
    }
}