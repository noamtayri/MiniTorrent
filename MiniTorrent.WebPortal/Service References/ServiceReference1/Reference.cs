﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniTorrent.WebPortal.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/DomainModel")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EnableDisableField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IPField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MiniTorrent.WebPortal.ServiceReference1.TransferFile[] OwnedFilesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PortField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool EnableDisable {
            get {
                return this.EnableDisableField;
            }
            set {
                if ((this.EnableDisableField.Equals(value) != true)) {
                    this.EnableDisableField = value;
                    this.RaisePropertyChanged("EnableDisable");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IP {
            get {
                return this.IPField;
            }
            set {
                if ((object.ReferenceEquals(this.IPField, value) != true)) {
                    this.IPField = value;
                    this.RaisePropertyChanged("IP");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MiniTorrent.WebPortal.ServiceReference1.TransferFile[] OwnedFiles {
            get {
                return this.OwnedFilesField;
            }
            set {
                if ((object.ReferenceEquals(this.OwnedFilesField, value) != true)) {
                    this.OwnedFilesField = value;
                    this.RaisePropertyChanged("OwnedFiles");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Port {
            get {
                return this.PortField;
            }
            set {
                if ((this.PortField.Equals(value) != true)) {
                    this.PortField = value;
                    this.RaisePropertyChanged("Port");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TransferFile", Namespace="http://schemas.datacontract.org/2004/07/DomainModel")]
    [System.SerializableAttribute()]
    public partial class TransferFile : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FileNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FileSizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ResourcesNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FileName {
            get {
                return this.FileNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FileNameField, value) != true)) {
                    this.FileNameField = value;
                    this.RaisePropertyChanged("FileName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FileSize {
            get {
                return this.FileSizeField;
            }
            set {
                if ((this.FileSizeField.Equals(value) != true)) {
                    this.FileSizeField = value;
                    this.RaisePropertyChanged("FileSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ResourcesNumber {
            get {
                return this.ResourcesNumberField;
            }
            set {
                if ((this.ResourcesNumberField.Equals(value) != true)) {
                    this.ResourcesNumberField = value;
                    this.RaisePropertyChanged("ResourcesNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Time {
            get {
                return this.TimeField;
            }
            set {
                if ((object.ReferenceEquals(this.TimeField, value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IMiniTorrentService")]
    public interface IMiniTorrentService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/GetData", ReplyAction="http://tempuri.org/IMiniTorrentService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/GetData", ReplyAction="http://tempuri.org/IMiniTorrentService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/Login", ReplyAction="http://tempuri.org/IMiniTorrentService/LoginResponse")]
        MiniTorrent.WebPortal.ServiceReference1.User Login(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/Login", ReplyAction="http://tempuri.org/IMiniTorrentService/LoginResponse")]
        System.Threading.Tasks.Task<MiniTorrent.WebPortal.ServiceReference1.User> LoginAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/SearchFiles", ReplyAction="http://tempuri.org/IMiniTorrentService/SearchFilesResponse")]
        MiniTorrent.WebPortal.ServiceReference1.TransferFile[] SearchFiles(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/SearchFiles", ReplyAction="http://tempuri.org/IMiniTorrentService/SearchFilesResponse")]
        System.Threading.Tasks.Task<MiniTorrent.WebPortal.ServiceReference1.TransferFile[]> SearchFilesAsync(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/LoginFlag", ReplyAction="http://tempuri.org/IMiniTorrentService/LoginFlagResponse")]
        void LoginFlag(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/LoginFlag", ReplyAction="http://tempuri.org/IMiniTorrentService/LoginFlagResponse")]
        System.Threading.Tasks.Task LoginFlagAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/LogoutFlag", ReplyAction="http://tempuri.org/IMiniTorrentService/LogoutFlagResponse")]
        void LogoutFlag(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/LogoutFlag", ReplyAction="http://tempuri.org/IMiniTorrentService/LogoutFlagResponse")]
        System.Threading.Tasks.Task LogoutFlagAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/GetMyFiles", ReplyAction="http://tempuri.org/IMiniTorrentService/GetMyFilesResponse")]
        MiniTorrent.WebPortal.ServiceReference1.TransferFile[] GetMyFiles(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/GetMyFiles", ReplyAction="http://tempuri.org/IMiniTorrentService/GetMyFilesResponse")]
        System.Threading.Tasks.Task<MiniTorrent.WebPortal.ServiceReference1.TransferFile[]> GetMyFilesAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/GetListOfResources", ReplyAction="http://tempuri.org/IMiniTorrentService/GetListOfResourcesResponse")]
        string[] GetListOfResources(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/GetListOfResources", ReplyAction="http://tempuri.org/IMiniTorrentService/GetListOfResourcesResponse")]
        System.Threading.Tasks.Task<string[]> GetListOfResourcesAsync(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/UpdateUserFiles", ReplyAction="http://tempuri.org/IMiniTorrentService/UpdateUserFilesResponse")]
        void UpdateUserFiles(string fileName, string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/UpdateUserFiles", ReplyAction="http://tempuri.org/IMiniTorrentService/UpdateUserFilesResponse")]
        System.Threading.Tasks.Task UpdateUserFilesAsync(string fileName, string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/UpdateUserDetails", ReplyAction="http://tempuri.org/IMiniTorrentService/UpdateUserDetailsResponse")]
        bool UpdateUserDetails(string oldUserName, string newUserName, string password, string ip, string port);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/UpdateUserDetails", ReplyAction="http://tempuri.org/IMiniTorrentService/UpdateUserDetailsResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserDetailsAsync(string oldUserName, string newUserName, string password, string ip, string port);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/AddNewUser", ReplyAction="http://tempuri.org/IMiniTorrentService/AddNewUserResponse")]
        bool AddNewUser(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiniTorrentService/AddNewUser", ReplyAction="http://tempuri.org/IMiniTorrentService/AddNewUserResponse")]
        System.Threading.Tasks.Task<bool> AddNewUserAsync(string userName, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMiniTorrentServiceChannel : MiniTorrent.WebPortal.ServiceReference1.IMiniTorrentService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MiniTorrentServiceClient : System.ServiceModel.ClientBase<MiniTorrent.WebPortal.ServiceReference1.IMiniTorrentService>, MiniTorrent.WebPortal.ServiceReference1.IMiniTorrentService {
        
        public MiniTorrentServiceClient() {
        }
        
        public MiniTorrentServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MiniTorrentServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MiniTorrentServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MiniTorrentServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public MiniTorrent.WebPortal.ServiceReference1.User Login(string userName, string password) {
            return base.Channel.Login(userName, password);
        }
        
        public System.Threading.Tasks.Task<MiniTorrent.WebPortal.ServiceReference1.User> LoginAsync(string userName, string password) {
            return base.Channel.LoginAsync(userName, password);
        }
        
        public MiniTorrent.WebPortal.ServiceReference1.TransferFile[] SearchFiles(string fileName) {
            return base.Channel.SearchFiles(fileName);
        }
        
        public System.Threading.Tasks.Task<MiniTorrent.WebPortal.ServiceReference1.TransferFile[]> SearchFilesAsync(string fileName) {
            return base.Channel.SearchFilesAsync(fileName);
        }
        
        public void LoginFlag(string userName) {
            base.Channel.LoginFlag(userName);
        }
        
        public System.Threading.Tasks.Task LoginFlagAsync(string userName) {
            return base.Channel.LoginFlagAsync(userName);
        }
        
        public void LogoutFlag(string userName) {
            base.Channel.LogoutFlag(userName);
        }
        
        public System.Threading.Tasks.Task LogoutFlagAsync(string userName) {
            return base.Channel.LogoutFlagAsync(userName);
        }
        
        public MiniTorrent.WebPortal.ServiceReference1.TransferFile[] GetMyFiles(string userName) {
            return base.Channel.GetMyFiles(userName);
        }
        
        public System.Threading.Tasks.Task<MiniTorrent.WebPortal.ServiceReference1.TransferFile[]> GetMyFilesAsync(string userName) {
            return base.Channel.GetMyFilesAsync(userName);
        }
        
        public string[] GetListOfResources(string fileName) {
            return base.Channel.GetListOfResources(fileName);
        }
        
        public System.Threading.Tasks.Task<string[]> GetListOfResourcesAsync(string fileName) {
            return base.Channel.GetListOfResourcesAsync(fileName);
        }
        
        public void UpdateUserFiles(string fileName, string userName) {
            base.Channel.UpdateUserFiles(fileName, userName);
        }
        
        public System.Threading.Tasks.Task UpdateUserFilesAsync(string fileName, string userName) {
            return base.Channel.UpdateUserFilesAsync(fileName, userName);
        }
        
        public bool UpdateUserDetails(string oldUserName, string newUserName, string password, string ip, string port) {
            return base.Channel.UpdateUserDetails(oldUserName, newUserName, password, ip, port);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUserDetailsAsync(string oldUserName, string newUserName, string password, string ip, string port) {
            return base.Channel.UpdateUserDetailsAsync(oldUserName, newUserName, password, ip, port);
        }
        
        public bool AddNewUser(string userName, string password) {
            return base.Channel.AddNewUser(userName, password);
        }
        
        public System.Threading.Tasks.Task<bool> AddNewUserAsync(string userName, string password) {
            return base.Channel.AddNewUserAsync(userName, password);
        }
    }
}
