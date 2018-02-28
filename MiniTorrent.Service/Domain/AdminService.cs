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

        public void AddNewUser(string userName, string password)
        {
            _miniTorrentProvider.AddNewUser(userName, password);
        }
    }
}