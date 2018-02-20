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

        public User GetUser(string userName)
        {
            return _miniTorrentProvider.GetUser(userName);
        }
    }
}