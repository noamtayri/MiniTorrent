﻿using System.Collections.Generic;
using DomainModel;
using MiniTorrent.Dal.Providers;

namespace MiniTorrent.Service.Domain
{
    public class UserService
    {
        private readonly MiniTorrentProvider _miniTorrentProvider;

        public UserService()
        {
            _miniTorrentProvider = new MiniTorrentProvider();
        }

        public void LoginFlag(string userName)
        {
            _miniTorrentProvider.LoginFlag(userName);
        }

        public void LogoutFlag(string userName)
        {
            _miniTorrentProvider.LogoutFlag(userName);
        }

        public List<TransferFile> GetUserFiles(string userName)
        {
            return _miniTorrentProvider.GetMyFiles(userName);
        }

        public void UpdateUserFiles(string fileName, string userName)
        {
            _miniTorrentProvider.UpdateUserTransferFiles(fileName, userName);
        }

        public bool UpdateUserDetails(string oldUserName, string newUserName, string password, string ip, string port)
        {
            return _miniTorrentProvider.SetUserDetails(oldUserName, newUserName, password, ip, port);
        }
    }
}