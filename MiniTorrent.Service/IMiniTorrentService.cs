using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DomainModel;

namespace MiniTorrent.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMiniTorrentService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        User Login(string userName, string password);

        [OperationContract]
        List<TransferFile> SearchFiles(string fileName);

        [OperationContract]
        void LoginFlag(string userName);

        [OperationContract]
        void LogoutFlag(string userName);

        [OperationContract]
        List<TransferFile> GetMyFiles(string userName);

        [OperationContract]
        List<string> GetListOfResources(string fileName);

        [OperationContract]
        void UpdateUserFiles(string fileName, string userName);

        [OperationContract]
        bool UpdateUserDetails(string oldUserName, string newUserName, string password, string ip, string port);

        [OperationContract]
        bool AddNewUser(string userName, string password);

        [OperationContract]
        User GetUser(string userName);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.

}
