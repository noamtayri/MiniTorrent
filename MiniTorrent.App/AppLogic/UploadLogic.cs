using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MiniTorrent.App.AppLogic.Classes;

namespace MiniTorrent.App.AppLogic
{
    public delegate void UploadEvent(UploadFileInfo info, bool isDone);

    public class UploadLogic
    {
        public UploadEvent MyUploadEvent;

        private string uploadFolderPath;
        private static int port = 8005;

        public void UploadListener(string uploadFolderPath)
        {
            this.uploadFolderPath = uploadFolderPath;
            TcpListener tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                Task.Factory.StartNew((() => uploadFile(tcpClient)));
            }
        }

        private void uploadFile(TcpClient tcpClient)
        {
            NetworkStream networkStream = tcpClient.GetStream();
            StreamReader streamReader = new StreamReader(networkStream);

            var fileName = streamReader.ReadLine();
            var fileSize = streamReader.ReadLine();
            var fileOffset = streamReader.ReadLine();
            var fractionSize = streamReader.ReadLine();

            UploadFileInfo info = new UploadFileInfo(fileName, long.Parse(fileSize), "Uploading");
            MyUploadEvent(info, false);

            byte[] uploadBytes = new byte[int.Parse(fractionSize)];
            bool finishRead = false;
            while (!finishRead)
            {
                try
                {
                    using (BinaryReader binaryReader = new BinaryReader(new FileStream(uploadFolderPath + "\\" + fileName, FileMode.Open)))
                    {
                        binaryReader.BaseStream.Seek(long.Parse(fileOffset), SeekOrigin.Begin);
                        binaryReader.Read(uploadBytes, 0, uploadBytes.Length);
                    }
                    finishRead = true;
                    networkStream.Write(uploadBytes,0,uploadBytes.Length);
                }
                catch //(Exception e)
                {
                    finishRead = false;
                }
            }
            info.Status = "Upload complete";
            MyUploadEvent(info, true);
        }
    }
}
