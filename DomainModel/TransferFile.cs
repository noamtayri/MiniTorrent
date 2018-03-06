using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class TransferFile
    {
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public int ResourcesNumber { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
        public int Kbps { get; set; }
    }
}
