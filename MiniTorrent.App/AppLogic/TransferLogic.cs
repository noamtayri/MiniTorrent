using MiniTorrent.App.MiniTorrentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTorrent.App.AppLogic
{
    public class TransferLogic
    {
        public void DownloadLogic(string fileName)
        {
            var client = new MiniTorrentServiceClient();
            var seeds = client.GetListOfResources(fileName);
            Console.WriteLine("aa");
        }
    }
}
