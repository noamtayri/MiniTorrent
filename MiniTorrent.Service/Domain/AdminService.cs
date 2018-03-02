using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniTorrent.Dal.Providers;

namespace MiniTorrent.Service.Domain
{
    public class AdminService
    {
        private readonly MiniTorrentProvider _miniTorrentProvider;

        public AdminService()
        {
            _miniTorrentProvider = new MiniTorrentProvider();
        }

        public bool AddNewUser(string userName, string password)
        {
            return _miniTorrentProvider.AddNewUser(userName, password);
        }

        public bool AdminUpdateUser(string oldUserName, string newUserName, string password, bool enable)
        {
            return _miniTorrentProvider.AdminUpdateUser(oldUserName, newUserName, password, enable);
        }
    }
}