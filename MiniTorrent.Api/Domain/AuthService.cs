using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel;

namespace MiniTorrent.Api.Domain
{
    public class AuthService
    {
        private readonly UserProvider _userProvider;

        public AuthService()
        {
            _userProvider = new UserProvider();
        }

        public User Login(string userName, string password)
        {
            var user = _userProvider.GetUser(userName);
            if (user == null)
                return null;
            return ValidatePassword(password, user.Password) ? user : null;
        }

        private bool ValidatePassword(string password, string userPassword)
        {
            return password.Equals(userPassword);
        }
    }
}