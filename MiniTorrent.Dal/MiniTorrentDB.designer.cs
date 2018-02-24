﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniTorrent.Dal
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MiniTorrent")]
	public partial class MiniTorrentDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTransferFile(TransferFile instance);
    partial void UpdateTransferFile(TransferFile instance);
    partial void DeleteTransferFile(TransferFile instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertUsersTransferFile(UsersTransferFile instance);
    partial void UpdateUsersTransferFile(UsersTransferFile instance);
    partial void DeleteUsersTransferFile(UsersTransferFile instance);
    #endregion
		
		public MiniTorrentDBDataContext() : 
				base(global::MiniTorrent.Dal.Properties.Settings.Default.MiniTorrentConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MiniTorrentDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MiniTorrentDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MiniTorrentDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MiniTorrentDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TransferFile> TransferFiles
		{
			get
			{
				return this.GetTable<TransferFile>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<UsersTransferFile> UsersTransferFiles
		{
			get
			{
				return this.GetTable<UsersTransferFile>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TransferFiles")]
	public partial class TransferFile : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _FileName;
		
		private System.Nullable<int> _FileSize;
		
		private EntitySet<UsersTransferFile> _UsersTransferFiles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnFileNameChanging(string value);
    partial void OnFileNameChanged();
    partial void OnFileSizeChanging(System.Nullable<int> value);
    partial void OnFileSizeChanged();
    #endregion
		
		public TransferFile()
		{
			this._UsersTransferFiles = new EntitySet<UsersTransferFile>(new Action<UsersTransferFile>(this.attach_UsersTransferFiles), new Action<UsersTransferFile>(this.detach_UsersTransferFiles));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileName", DbType="NVarChar(50)")]
		public string FileName
		{
			get
			{
				return this._FileName;
			}
			set
			{
				if ((this._FileName != value))
				{
					this.OnFileNameChanging(value);
					this.SendPropertyChanging();
					this._FileName = value;
					this.SendPropertyChanged("FileName");
					this.OnFileNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileSize", DbType="Int")]
		public System.Nullable<int> FileSize
		{
			get
			{
				return this._FileSize;
			}
			set
			{
				if ((this._FileSize != value))
				{
					this.OnFileSizeChanging(value);
					this.SendPropertyChanging();
					this._FileSize = value;
					this.SendPropertyChanged("FileSize");
					this.OnFileSizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TransferFile_UsersTransferFile", Storage="_UsersTransferFiles", ThisKey="ID", OtherKey="TransferFileID")]
		public EntitySet<UsersTransferFile> UsersTransferFiles
		{
			get
			{
				return this._UsersTransferFiles;
			}
			set
			{
				this._UsersTransferFiles.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_UsersTransferFiles(UsersTransferFile entity)
		{
			this.SendPropertyChanging();
			entity.TransferFile = this;
		}
		
		private void detach_UsersTransferFiles(UsersTransferFile entity)
		{
			this.SendPropertyChanging();
			entity.TransferFile = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _UserName;
		
		private string _Password;
		
		private System.Nullable<bool> _LogIn;
		
		private EntitySet<UsersTransferFile> _UsersTransferFiles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnLogInChanging(System.Nullable<bool> value);
    partial void OnLogInChanged();
    #endregion
		
		public User()
		{
			this._UsersTransferFiles = new EntitySet<UsersTransferFile>(new Action<UsersTransferFile>(this.attach_UsersTransferFiles), new Action<UsersTransferFile>(this.detach_UsersTransferFiles));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(50)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(MAX)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogIn", DbType="Bit")]
		public System.Nullable<bool> LogIn
		{
			get
			{
				return this._LogIn;
			}
			set
			{
				if ((this._LogIn != value))
				{
					this.OnLogInChanging(value);
					this.SendPropertyChanging();
					this._LogIn = value;
					this.SendPropertyChanged("LogIn");
					this.OnLogInChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_UsersTransferFile", Storage="_UsersTransferFiles", ThisKey="ID", OtherKey="UserID")]
		public EntitySet<UsersTransferFile> UsersTransferFiles
		{
			get
			{
				return this._UsersTransferFiles;
			}
			set
			{
				this._UsersTransferFiles.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_UsersTransferFiles(UsersTransferFile entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_UsersTransferFiles(UsersTransferFile entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UsersTransferFiles")]
	public partial class UsersTransferFile : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID;
		
		private int _TransferFileID;
		
		private EntityRef<TransferFile> _TransferFile;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnTransferFileIDChanging(int value);
    partial void OnTransferFileIDChanged();
    #endregion
		
		public UsersTransferFile()
		{
			this._TransferFile = default(EntityRef<TransferFile>);
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransferFileID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int TransferFileID
		{
			get
			{
				return this._TransferFileID;
			}
			set
			{
				if ((this._TransferFileID != value))
				{
					if (this._TransferFile.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTransferFileIDChanging(value);
					this.SendPropertyChanging();
					this._TransferFileID = value;
					this.SendPropertyChanged("TransferFileID");
					this.OnTransferFileIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TransferFile_UsersTransferFile", Storage="_TransferFile", ThisKey="TransferFileID", OtherKey="ID", IsForeignKey=true)]
		public TransferFile TransferFile
		{
			get
			{
				return this._TransferFile.Entity;
			}
			set
			{
				TransferFile previousValue = this._TransferFile.Entity;
				if (((previousValue != value) 
							|| (this._TransferFile.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TransferFile.Entity = null;
						previousValue.UsersTransferFiles.Remove(this);
					}
					this._TransferFile.Entity = value;
					if ((value != null))
					{
						value.UsersTransferFiles.Add(this);
						this._TransferFileID = value.ID;
					}
					else
					{
						this._TransferFileID = default(int);
					}
					this.SendPropertyChanged("TransferFile");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_UsersTransferFile", Storage="_User", ThisKey="UserID", OtherKey="ID", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.UsersTransferFiles.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.UsersTransferFiles.Add(this);
						this._UserID = value.ID;
					}
					else
					{
						this._UserID = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
