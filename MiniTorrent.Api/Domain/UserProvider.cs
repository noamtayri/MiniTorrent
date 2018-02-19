using System.Collections.Generic;
using System.Linq;
using DomainModel;

namespace MiniTorrent.Api.Domain
{
    public class UserProvider
    {
        public User GetUser(string userName)
        {
            var users = new List<User>
            {
                new User { UserName = "Barak", Password = "12345"},
                new User { UserName = "Noam", Password = "12345"},
                new User { UserName = "Nofar", Password = "12345"}
            };
            return users.FirstOrDefault(u => u.UserName.Equals(userName));
        }
    }
}
