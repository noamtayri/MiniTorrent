using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel;
using MiniTorrent.Dal.Providers;


namespace MiniTorrent.Service.Domain
{
    public class SeedersService
    {
        private readonly MiniTorrentProvider _miniTorrentProvider;

        public SeedersService()
        {
            _miniTorrentProvider = new MiniTorrentProvider();
        }

        public List<string> GetListOfResources(string fileName)
        {
            return _miniTorrentProvider.GetListOfResources(fileName);
        }

        /*
        public List<User> GetListOfResources(string fileName)
        {
            return _miniTorrentProvider.GetListOfResources(fileName);
        }*/
    }
}
 