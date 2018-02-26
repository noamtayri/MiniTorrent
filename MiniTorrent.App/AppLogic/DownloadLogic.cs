using MiniTorrent.App.MiniTorrentService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MiniTorrent.App.AppLogic.Classes;

namespace MiniTorrent.App.AppLogic
{
    public delegate void DownloadEvent(DownloadFileInfo info, bool isDone);

    public class DownloadLogic
    {
        public DownloadEvent MyDownloadEvent;

        private byte[] downloadedBytes;
        private string fileName;
        private List<string> sourcesIP;
        private int fileSize;
        private string downloadFolderPath;

        public DownloadLogic(string fileName, int fileSize, string downloadFolderPath)
        {
            var client = new MiniTorrentServiceClient();
            this.fileName = fileName;
            this.sourcesIP = (List<string>)client.GetListOfResources(this.fileName).Select(u => u.IP);
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
            //int remainder = fileSize;
            int remainder = fileSize - (fractionSize * sourcesIP.Count);

            DownloadFileInfo info = new DownloadFileInfo(this.fileName, this.fileSize, "in Downloading process", DateTime.Now.ToString());

            MyDownloadEvent(info, false);
            FractionData fraction;
            for (int i = 0; i < sourcesIP.Count-1; i++)
            {
                fraction = new FractionData(sourcesIP[i], fileName, fileSize, fractionSize * i, fractionSize);
                fractions.Add(fraction);
                fraction.DownTask.Start();
            }
            fraction = new FractionData(sourcesIP[sourcesIP.Count - 1], fileName, fileSize, fractionSize * (sourcesIP.Count - 1), remainder);
            fractions.Add(fraction);
            fraction.DownTask.Start();

            for (int i = 0; i < fractions.Count; i++)
            {
                Task.WaitAll(fractions[i].DownTask);
                fileStream.Write(fractions[i].RecvBytesArr, 0, fractions[i].RecvBytesArr.Length);
                //fileStream.Write(fractions[i].RecvBytesArr, fractionSize * i, fractions[i].RecvBytesArr.Length);
            }
            fileStream.Close();
            TimeSpan timeSpan = DateTime.Now - DateTime.Parse(info.Time);
            info.Kbps = (int)(fileSize / timeSpan.TotalSeconds / 1000);
            info.Status = "Download completed";
            MyDownloadEvent(info, true);
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
