﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel;
using MiniTorrent.Service.Domain;

namespace MiniTorrent.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MiniTorrentService : IMiniTorrentService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public User Login(string userName, string password)
        {
            AuthService authService = new AuthService();
            return authService.Login(userName, password);
        }

        public List<TransferFile> SearchFiles(string fileName)
        {
            SearchFileService searchFileService = new SearchFileService();
            return searchFileService.SearchFiles(fileName);
        }

        public void LoginFlag(string userName)
        {
            UserService userService = new UserService();
            userService.LoginFlag(userName);
        }

        public void LogoutFlag(string userName)
        {
            UserService userService = new UserService();
            userService.LogoutFlag(userName);
        }

        public List<TransferFile> GetMyFiles(string userName)
        {
            UserService userService = new UserService();
            return userService.GetUserFiles(userName);
        }

        public List<string> GetListOfResources(string fileName)
        {
            SeedersService seedersService = new SeedersService();
            return seedersService.GetListOfResources(fileName);
        }

        public void UpdateUserFiles(string fileName, string userName)
        {
            UserService userService = new UserService();
            userService.UpdateUserFiles(fileName, userName);
        }

        public bool UpdateUserDetails(string oldUserName, string newUserName, string password, string ip, string port)
        {
            UserService userService = new UserService();
            return userService.UpdateUserDetails(oldUserName, newUserName, password, ip, port);
        }

        public bool AddNewUser(string userName, string password)
        {
            AdminService adminService = new AdminService();
            return adminService.AddNewUser(userName, password);
        }

        public User GetUser(string userName)
        {
            AuthService authService = new AuthService();
            return authService.GetUser(userName);
        }

        public bool AdminUpdateUser(string oldUserName, string newUserName, string password, bool enable)
        {
            AdminService adminService = new AdminService();
            return adminService.AdminUpdateUser(oldUserName, newUserName, password, enable);
        }

        public void DeleteUser(string userName)
        {
            AdminService adminService = new AdminService();
            adminService.DeleteUser(userName);
        }

        public User AdminGetUser(string userName)
        {
            AdminService adminService = new AdminService();
            return adminService.AdminGetUser(userName);
        }

        public int GetOnlineUsers()
        {
            AdminService adminService = new AdminService();
            return adminService.GetOnlineUsers();
        }

        public int GetUsersAmount()
        {
            AdminService adminService = new AdminService();
            return adminService.GetUsersAmount();
        }

        public int GetFilesAmount()
        {
            AdminService adminService = new AdminService();
            return adminService.GetFilesAmount();
        }

        /*
        public List<User> GetListOfResources(string fileName)
        {
            SeedersService seedersService = new SeedersService();
            return seedersService.GetListOfResources(fileName);
        }*/
    }
}
