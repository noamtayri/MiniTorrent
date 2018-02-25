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
    }
}