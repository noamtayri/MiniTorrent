﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTorrent.Dal.Providers
{
    public class MiniTorrentProvider
    {
        //with treatment in Enable property
        public DomainModel.User GetUser(string userName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                return miniTorentDB.Users
                    .Where(u => u.UserName.Equals(userName) && u.Enable==true)
                    .Select(u => new DomainModel.User { UserName = u.UserName, Password = u.Password, EnableDisable = u.Enable.HasValue })
                    .FirstOrDefault();
            }
        }
        //without treatment in Enable property
        public DomainModel.User AdminGetUser(string userName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                return miniTorentDB.Users
                    .Where(u => u.UserName.Equals(userName))
                    .Select(u => new DomainModel.User { UserName = u.UserName, Password = u.Password, EnableDisable = (bool)u.Enable })
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

        public List<string> GetListOfResources(string fileName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                return miniTorentDB.UsersTransferFiles
                    .Where(f => f.TransferFile.FileName.Equals(fileName) && f.User.LogIn.Equals(true))
                    .Select(u => u.User.IP)
                    .ToList();
            }        
        }

        public void UpdateUserTransferFiles(string fileName, string userName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                var userId = miniTorentDB.Users
                    .Where(u => u.UserName.Equals(userName))
                    .Select(u => u.ID)
                    .FirstOrDefault();
                var fileId = miniTorentDB.TransferFiles
                    .Where(f => f.FileName.Equals(fileName))
                    .Select(f => f.ID)
                    .FirstOrDefault();

                var a = new UsersTransferFile();
                a.UserID = userId;
                a.TransferFileID = fileId;
                miniTorentDB.UsersTransferFiles.InsertOnSubmit(a);
                miniTorentDB.SubmitChanges();
            }
        }

        public bool SetUserDetails(string oldUserName, string newUserName, string password, string ip, string port)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                if (oldUserName != newUserName)
                {
                    var checkUser = miniTorentDB.Users
                        .FirstOrDefault(u => u.UserName.Equals(newUserName));
                    if (checkUser != null)
                    {
                        return false;
                    }
                }
                var user = miniTorentDB.Users
                    .FirstOrDefault(u => u.UserName.Equals(oldUserName));
                user.UserName = newUserName;
                user.Password = password;
                user.IP = ip;
                user.PORT = int.Parse(port);
                miniTorentDB.SubmitChanges();
                return true;
            }
        }

        public bool AdminUpdateUser(string oldUserName, string newUserName, string password, bool enable)
        {
            using (var miniTorentDB =new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                if (oldUserName != newUserName)
                {
                    var checkUser = miniTorentDB.Users
                        .FirstOrDefault(u => u.UserName.Equals(newUserName));
                    if (checkUser != null)
                    {
                        return false;
                    }
                }
                var user = miniTorentDB.Users
                    .FirstOrDefault(u => u.UserName.Equals(oldUserName));
                user.UserName = newUserName;
                user.Password = password;
                user.Enable = enable;
                miniTorentDB.SubmitChanges();
                return true;
            }
        }

        public bool AddNewUser(string userName, string password)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                var checkUser = miniTorentDB.Users
                    .FirstOrDefault(u => u.UserName.Equals(userName));
                if (checkUser == null)
                {
                    var newUser = new User
                    {
                        UserName = userName,
                        Password = password,
                        LogIn = false,
                        Enable = true
                    };
                    miniTorentDB.Users.InsertOnSubmit(newUser);
                    miniTorentDB.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void DeleteUser(string userName)
        {
            using (var miniTorentDB = new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"].ConnectionString))
            {
                var usersTransferFilesToDelete = miniTorentDB.UsersTransferFiles
                    .Where(u => u.User.UserName.Equals(userName))
                    .ToList();
                foreach (var line in usersTransferFilesToDelete)
                {
                    miniTorentDB.GetTable<UsersTransferFile>().DeleteOnSubmit(line);
                }
                var userToDelete = miniTorentDB.Users
                    .FirstOrDefault(u => u.UserName.Equals(userName));
                miniTorentDB.GetTable<User>().DeleteOnSubmit(userToDelete);
                miniTorentDB.SubmitChanges();
            }
        }

        public int GetOnlineUsers()
        {
            using (var miniTorentDB =
                new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"]
                    .ConnectionString))
            {
                return miniTorentDB.Users
                    .Count(u => u.LogIn.Equals(true));
            }
        }

        public int GetUsersAmount()
        {
            using (var miniTorentDB =
                new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"]
                    .ConnectionString))
            {
                return miniTorentDB.Users.Count();
            }
        }

        public int GetFilesAmount()
        {
            using (var miniTorentDB =
                new MiniTorrentDBDataContext(ConfigurationManager.ConnectionStrings["MiniTorrentConnection"]
                    .ConnectionString))
            {
                return miniTorentDB.TransferFiles.Count();
            }
        }
    }
}
