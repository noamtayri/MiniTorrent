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
        public DomainModel.User GetUser2(string userName)
        {
            var users = new List<DomainModel.User>
            {
                new DomainModel.User { UserName = "Barak", Password = "12345"},
                new DomainModel.User { UserName = "Noam", Password = "12345"},
                new DomainModel.User { UserName = "Nofar", Password = "12345"}
            };
            return users.FirstOrDefault(u => u.UserName.Equals(userName));
        }
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
                /*
                var user = miniTorentDB.Users.FirstOrDefault(u => u.UserName.Equals("Noam"));
                var usersTransferFiles = user?.UsersTransferFiles.Select(f => new DomainModel.TransferFile
                {
                    FileName = f.TransferFile.FileName,
                    FileSize = (int)f.TransferFile.FileSize,
                    ResourcesNumber = (int)f.TransferFile.FileResources
                }).ToList();
                */
                return miniTorentDB.TransferFiles
                    .Where(f => f.FileName.Contains(fileName))
                    .Select(f => new DomainModel.TransferFile { FileName = f.FileName, FileSize = (int)f.FileSize, ResourcesNumber = (int)f.FileResources })
                    .ToList();
            }
        }
    }
}
