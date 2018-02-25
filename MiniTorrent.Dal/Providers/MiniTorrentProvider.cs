using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTorrent.Dal.Providers
{
    public class MiniTorrentProvider
    {
        public DomainModel.User  GetUser(string userName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                return miniTorentDB.Users
                    .Where(u => u.UserName.Equals(userName))
                    .Select(u => new DomainModel.User { UserName = u.UserName, Password = u.Password })
                    .FirstOrDefault();
            }
        }

        public List<DomainModel.TransferFile> GetSearchedFiles(string fileName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                var a = miniTorentDB.UsersTransferFiles
                    .Where(f => f.TransferFile.FileName.Contains(fileName) && f.User.LogIn.Equals(true))
                    .GroupBy(u => u.TransferFileID)
                    .Select(g => new DomainModel.TransferFile
                    {
                        FileName = g.First().TransferFile.FileName,
                        FileSize = g.First().TransferFile.FileSize.GetValueOrDefault(),
                        ResourcesNumber = g.Count()
                    });

                var b = miniTorentDB.TransferFiles
                    .Where(f => f.FileName.Contains(fileName) && !a.Any(r => r.FileName.Equals(f.FileName)))
                    .Select(t =>
                        new DomainModel.TransferFile
                        {
                            FileName = t.FileName,
                            FileSize = t.FileSize.GetValueOrDefault(),
                            ResourcesNumber = 0
                        })
                    .ToList();
                var d = a.ToList();
                d.AddRange(b);

                return d;
            }
        }

        public void LoginFlag(string userName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                var user = miniTorentDB.Users
                    .FirstOrDefault(u => u.UserName.Equals(userName));
                user.LogIn = true;
                miniTorentDB.SubmitChanges();
            }
        }

        public void LogoutFlag(string userName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                var user = miniTorentDB.Users
                    .FirstOrDefault(u => u.UserName.Equals(userName));
                user.LogIn = false;
                miniTorentDB.SubmitChanges();
            }
        }

        public List<DomainModel.TransferFile> GetMyFiles(string userName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                return miniTorentDB.UsersTransferFiles
                    .Where(u => u.User.UserName.Equals(userName))
                    .Select(u =>
                        new DomainModel.TransferFile
                        {
                            FileName = u.TransferFile.FileName,
                            FileSize = u.TransferFile.FileSize.GetValueOrDefault()
                        })
                    .ToList();
            }
        }

        public List<DomainModel.User> GetListOfResources(string fileName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                return miniTorentDB.UsersTransferFiles
                    .Where(f => f.TransferFile.FileName.Equals(fileName) && f.User.LogIn.Equals(true))
                    .Select(u => new DomainModel.User {Port = u.User.PORT.GetValueOrDefault(), IP = u.User.IP})
                    .ToList();
            }        
        }
    }
}
