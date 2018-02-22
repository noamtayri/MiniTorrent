using MiniTorrent.Dal.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel;

namespace MiniTorrent.Service.Domain
{
    public class SearchFileService
    {
        private readonly MiniTorrentProvider _miniTorrentProvider;

        public SearchFileService()
        {
            _miniTorrentProvider = new MiniTorrentProvider();
        }

        public List<TransferFile> SearchFiles(string fileName)
        {
            var files = _miniTorrentProvider.GetSearchedFiles(fileName);
            if (files == null)
                return null;
            return files;
        }
    }
}