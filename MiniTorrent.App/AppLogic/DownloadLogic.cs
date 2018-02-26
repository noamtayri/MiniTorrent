using MiniTorrent.App.MiniTorrentService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniTorrent.App.AppLogic
{
    public class DownloadLogic
    {
        private byte[] downloadedBytes;
        private string fileName;
        private List<string> sourcesIP;
        private int fileSize;
        private string downloadFolderPath;

        public DownloadLogic(string fileName, List<string> sourcesIP, int fileSize, string downloadFolderPath)
        {
            this.fileName = fileName;
            this.sourcesIP = sourcesIP;
            this.fileSize = fileSize;
            this.downloadFolderPath = downloadFolderPath;
        }

        public void Start()
        {
            if (File.Exists(downloadFolderPath + "\\" + fileName))            
                File.Delete(downloadFolderPath + "\\" + fileName);
            FileStream fileStream = File.Open(downloadFolderPath + "\\" + fileName, FileMode.Create);
            downloadedBytes = new byte[fileSize];

            List<FractionData> fractions = new List<FractionData>();
            int fractionSize = fileSize / sourcesIP.Count;
            int remainder = fileSize;
            //int remainder = fileSize - (fractionSize * sourcesIP.Count);
            

        }

        private void GetResourcesLogic(string fileName)
        {
            var client = new MiniTorrentServiceClient();
            var seeds = client.GetListOfResources(fileName);
            Console.WriteLine("aa");
        }

        public class FractionData
        {
            private string ip;
            private string fileName;
            private int fileSize;
            private int offset;
            private int fractionSize;
            public Task DownTask { get; }
            public Byte[] RecvBytesArr { get; }

            public FractionData(string ip, string fileName, int fileSize, int offset, int fractionSize)
            {
                this.ip = ip;
                this.fileName = fileName;
                this.fileSize = fileSize;
                this.offset = offset;
                this.fractionSize = fractionSize;
                RecvBytesArr = new byte[fractionSize];
                DownTask = new Task((() =>
                {
                    fractionDownload();
                }));
            }

            private void fractionDownload()
            {
                try
                {
                    TcpClient tcpClient = new TcpClient(this.ip, 8005);
                    NetworkStream networkStream = tcpClient.GetStream();
                    StreamWriter streamWriter = new StreamWriter(networkStream);

                    streamWriter.WriteLine(this.fileName);
                    streamWriter.Flush();
                    streamWriter.WriteLine(this.fileSize);
                    streamWriter.Flush();
                    streamWriter.WriteLine(this.offset);
                    streamWriter.Flush();
                    streamWriter.WriteLine(this.fractionSize);
                    streamWriter.Flush();

                    int bytesRecv = 0;
                    bytesRecv += networkStream.Read(RecvBytesArr, 0, fractionSize);
                    while (bytesRecv < fractionSize)                    
                        bytesRecv += networkStream.Read(RecvBytesArr, 0, fractionSize);
                    
                    /*
                    do
                    {
                        bytesRecv += networkStream.Read(RecvBytesArr, bytesRecv, fractionSize);
                    } while (bytesRecv < fractionSize);
                    */

                }
                catch (SocketException e)
                {
                    Console.WriteLine(e);
                }    
            
            }
        }
    }
}
