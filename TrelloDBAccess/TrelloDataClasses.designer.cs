﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrelloDBAccess
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
	
	
	public partial class TrelloDataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertUsers(Users instance);
    partial void UpdateUsers(Users instance);
    partial void DeleteUsers(Users instance);
    partial void InsertProjects(Projects instance);
    partial void UpdateProjects(Projects instance);
    partial void DeleteProjects(Projects instance);
    partial void InsertBoards(Boards instance);
    partial void UpdateBoards(Boards instance);
    partial void DeleteBoards(Boards instance);
    partial void InsertTasks(Tasks instance);
    partial void UpdateTasks(Tasks instance);
    partial void DeleteTasks(Tasks instance);
    partial void InsertProjectMembers(ProjectMembers instance);
    partial void UpdateProjectMembers(ProjectMembers instance);
    partial void DeleteProjectMembers(ProjectMembers instance);
    partial void InsertTaskMovements(TaskMovements instance);
    partial void UpdateTaskMovements(TaskMovements instance);
    partial void DeleteTaskMovements(TaskMovements instance);
    #endregion
		
		public TrelloDataClassesDataContext() : 
				base(global::TrelloDBAccess.Properties.Settings.Default.db_aa5374_trelloConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TrelloDataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TrelloDataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TrelloDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TrelloDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Users> Users
		{
			get
			{
				return this.GetTable<Users>();
			}
		}
		
		public System.Data.Linq.Table<Projects> Projects
		{
			get
			{
				return this.GetTable<Projects>();
			}
		}
		
		public System.Data.Linq.Table<Boards> Boards
		{
			get
			{
				return this.GetTable<Boards>();
			}
		}
		
		public System.Data.Linq.Table<Tasks> Tasks
		{
			get
			{
				return this.GetTable<Tasks>();
			}
		}
		
		public System.Data.Linq.Table<ProjectMembers> ProjectMembers
		{
			get
			{
				return this.GetTable<ProjectMembers>();
			}
		}
		
		public System.Data.Linq.Table<TaskMovements> TaskMovements
		{
			get
			{
				return this.GetTable<TaskMovements>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Users : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserID;
		
		private string _Login;
		
		private string _Email;
		
		private string _Password;
		
		private string _Avatar;
		
		private EntityRef<Tasks> _Tasks;
		
		private EntityRef<ProjectMembers> _ProjectMembers;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnLoginChanging(string value);
    partial void OnLoginChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnAvatarChanging(string value);
    partial void OnAvatarChanged();
    #endregion
		
		public Users()
		{
			this._Tasks = default(EntityRef<Tasks>);
			this._ProjectMembers = default(EntityRef<ProjectMembers>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="INT PRIMARY KEY IDENTITY", IsPrimaryKey=true)]
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
					if ((this._Tasks.HasLoadedOrAssignedValue || this._ProjectMembers.HasLoadedOrAssignedValue))
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Login", DbType="NVARCHAR(50) NOT NULL UNIQUE", CanBeNull=false)]
		public string Login
		{
			get
			{
				return this._Login;
			}
			set
			{
				if ((this._Login != value))
				{
					this.OnLoginChanging(value);
					this.SendPropertyChanging();
					this._Login = value;
					this.SendPropertyChanged("Login");
					this.OnLoginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVARCHAR(100) NOT NULL UNIQUE", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVARCHAR(100) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Avatar", DbType="NVARCHAR(100)")]
		public string Avatar
		{
			get
			{
				return this._Avatar;
			}
			set
			{
				if ((this._Avatar != value))
				{
					this.OnAvatarChanging(value);
					this.SendPropertyChanging();
					this._Avatar = value;
					this.SendPropertyChanged("Avatar");
					this.OnAvatarChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tasks_Users", Storage="_Tasks", ThisKey="UserID", OtherKey="UserID", IsForeignKey=true)]
		public Tasks Tasks
		{
			get
			{
				return this._Tasks.Entity;
			}
			set
			{
				Tasks previousValue = this._Tasks.Entity;
				if (((previousValue != value) 
							|| (this._Tasks.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Tasks.Entity = null;
						previousValue.Users.Remove(this);
					}
					this._Tasks.Entity = value;
					if ((value != null))
					{
						value.Users.Add(this);
						this._UserID = value.UserID;
					}
					else
					{
						this._UserID = default(int);
					}
					this.SendPropertyChanged("Tasks");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProjectMembers_Users", Storage="_ProjectMembers", ThisKey="UserID", OtherKey="UserID", IsForeignKey=true)]
		public ProjectMembers ProjectMembers
		{
			get
			{
				return this._ProjectMembers.Entity;
			}
			set
			{
				ProjectMembers previousValue = this._ProjectMembers.Entity;
				if (((previousValue != value) 
							|| (this._ProjectMembers.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ProjectMembers.Entity = null;
						previousValue.Users.Remove(this);
					}
					this._ProjectMembers.Entity = value;
					if ((value != null))
					{
						value.Users.Add(this);
						this._UserID = value.UserID;
					}
					else
					{
						this._UserID = default(int);
					}
					this.SendPropertyChanged("ProjectMembers");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Projects : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProjectID;
		
		private string _ProjectName;
		
		private EntityRef<Boards> _Boards;
		
		private EntityRef<ProjectMembers> _ProjectMembers;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProjectIDChanging(int value);
    partial void OnProjectIDChanged();
    partial void OnProjectNameChanging(string value);
    partial void OnProjectNameChanged();
    #endregion
		
		public Projects()
		{
			this._Boards = default(EntityRef<Boards>);
			this._ProjectMembers = default(EntityRef<ProjectMembers>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectID", DbType="INT PRIMARY KEY IDENTITY", IsPrimaryKey=true)]
		public int ProjectID
		{
			get
			{
				return this._ProjectID;
			}
			set
			{
				if ((this._ProjectID != value))
				{
					if ((this._Boards.HasLoadedOrAssignedValue || this._ProjectMembers.HasLoadedOrAssignedValue))
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProjectIDChanging(value);
					this.SendPropertyChanging();
					this._ProjectID = value;
					this.SendPropertyChanged("ProjectID");
					this.OnProjectIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectName", DbType="NVARCHAR(100) NOT NULL UNIQUE", CanBeNull=false)]
		public string ProjectName
		{
			get
			{
				return this._ProjectName;
			}
			set
			{
				if ((this._ProjectName != value))
				{
					this.OnProjectNameChanging(value);
					this.SendPropertyChanging();
					this._ProjectName = value;
					this.SendPropertyChanged("ProjectName");
					this.OnProjectNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Boards_Projects", Storage="_Boards", ThisKey="ProjectID", OtherKey="ProjectID", IsForeignKey=true)]
		public Boards Boards
		{
			get
			{
				return this._Boards.Entity;
			}
			set
			{
				Boards previousValue = this._Boards.Entity;
				if (((previousValue != value) 
							|| (this._Boards.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Boards.Entity = null;
						previousValue.Projects.Remove(this);
					}
					this._Boards.Entity = value;
					if ((value != null))
					{
						value.Projects.Add(this);
						this._ProjectID = value.ProjectID;
					}
					else
					{
						this._ProjectID = default(int);
					}
					this.SendPropertyChanged("Boards");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProjectMembers_Projects", Storage="_ProjectMembers", ThisKey="ProjectID", OtherKey="ProjectID", IsForeignKey=true)]
		public ProjectMembers ProjectMembers
		{
			get
			{
				return this._ProjectMembers.Entity;
			}
			set
			{
				ProjectMembers previousValue = this._ProjectMembers.Entity;
				if (((previousValue != value) 
							|| (this._ProjectMembers.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ProjectMembers.Entity = null;
						previousValue.Projects.Remove(this);
					}
					this._ProjectMembers.Entity = value;
					if ((value != null))
					{
						value.Projects.Add(this);
						this._ProjectID = value.ProjectID;
					}
					else
					{
						this._ProjectID = default(int);
					}
					this.SendPropertyChanged("ProjectMembers");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Boards : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BoardID;
		
		private int _ProjectID;
		
		private string _BoardName;
		
		private string _BoardColor;
		
		private EntitySet<Projects> _Projects;
		
		private EntityRef<Tasks> _Tasks;
		
		private EntityRef<TaskMovements> _TaskMovements;
		
		private EntityRef<TaskMovements> _TaskMovements1;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBoardIDChanging(int value);
    partial void OnBoardIDChanged();
    partial void OnProjectIDChanging(int value);
    partial void OnProjectIDChanged();
    partial void OnBoardNameChanging(string value);
    partial void OnBoardNameChanged();
    partial void OnBoardColorChanging(string value);
    partial void OnBoardColorChanged();
    #endregion
		
		public Boards()
		{
			this._Projects = new EntitySet<Projects>(new Action<Projects>(this.attach_Projects), new Action<Projects>(this.detach_Projects));
			this._Tasks = default(EntityRef<Tasks>);
			this._TaskMovements = default(EntityRef<TaskMovements>);
			this._TaskMovements1 = default(EntityRef<TaskMovements>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BoardID", DbType="INT PRIMARY KEY IDENTITY", IsPrimaryKey=true)]
		public int BoardID
		{
			get
			{
				return this._BoardID;
			}
			set
			{
				if ((this._BoardID != value))
				{
					if (((this._Tasks.HasLoadedOrAssignedValue || this._TaskMovements.HasLoadedOrAssignedValue) 
								|| this._TaskMovements1.HasLoadedOrAssignedValue))
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBoardIDChanging(value);
					this.SendPropertyChanging();
					this._BoardID = value;
					this.SendPropertyChanged("BoardID");
					this.OnBoardIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectID", DbType="INT NOT NULL")]
		public int ProjectID
		{
			get
			{
				return this._ProjectID;
			}
			set
			{
				if ((this._ProjectID != value))
				{
					this.OnProjectIDChanging(value);
					this.SendPropertyChanging();
					this._ProjectID = value;
					this.SendPropertyChanged("ProjectID");
					this.OnProjectIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BoardName", DbType="NVARCHAR(100) NOT NULL", CanBeNull=false)]
		public string BoardName
		{
			get
			{
				return this._BoardName;
			}
			set
			{
				if ((this._BoardName != value))
				{
					this.OnBoardNameChanging(value);
					this.SendPropertyChanging();
					this._BoardName = value;
					this.SendPropertyChanged("BoardName");
					this.OnBoardNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BoardColor", DbType="NVARCHAR(20)", CanBeNull=false)]
		public string BoardColor
		{
			get
			{
				return this._BoardColor;
			}
			set
			{
				if ((this._BoardColor != value))
				{
					this.OnBoardColorChanging(value);
					this.SendPropertyChanging();
					this._BoardColor = value;
					this.SendPropertyChanged("BoardColor");
					this.OnBoardColorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Boards_Projects", Storage="_Projects", ThisKey="ProjectID", OtherKey="ProjectID")]
		public EntitySet<Projects> Projects
		{
			get
			{
				return this._Projects;
			}
			set
			{
				this._Projects.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tasks_Boards", Storage="_Tasks", ThisKey="BoardID", OtherKey="BoardID", IsForeignKey=true)]
		public Tasks Tasks
		{
			get
			{
				return this._Tasks.Entity;
			}
			set
			{
				Tasks previousValue = this._Tasks.Entity;
				if (((previousValue != value) 
							|| (this._Tasks.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Tasks.Entity = null;
						previousValue.Boards.Remove(this);
					}
					this._Tasks.Entity = value;
					if ((value != null))
					{
						value.Boards.Add(this);
						this._BoardID = value.BoardID;
					}
					else
					{
						this._BoardID = default(int);
					}
					this.SendPropertyChanged("Tasks");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TaskMovements_Boards", Storage="_TaskMovements", ThisKey="BoardID", OtherKey="FromBoardID", IsForeignKey=true)]
		public TaskMovements TaskMovements
		{
			get
			{
				return this._TaskMovements.Entity;
			}
			set
			{
				TaskMovements previousValue = this._TaskMovements.Entity;
				if (((previousValue != value) 
							|| (this._TaskMovements.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TaskMovements.Entity = null;
						previousValue.Boards.Remove(this);
					}
					this._TaskMovements.Entity = value;
					if ((value != null))
					{
						value.Boards.Add(this);
						this._BoardID = value.FromBoardID;
					}
					else
					{
						this._BoardID = default(int);
					}
					this.SendPropertyChanged("TaskMovements");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TaskMovements_Boards1", Storage="_TaskMovements1", ThisKey="BoardID", OtherKey="ToBoardID", IsForeignKey=true)]
		public TaskMovements TaskMovements1
		{
			get
			{
				return this._TaskMovements1.Entity;
			}
			set
			{
				TaskMovements previousValue = this._TaskMovements1.Entity;
				if (((previousValue != value) 
							|| (this._TaskMovements1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TaskMovements1.Entity = null;
						previousValue.Boards1.Remove(this);
					}
					this._TaskMovements1.Entity = value;
					if ((value != null))
					{
						value.Boards1.Add(this);
						this._BoardID = value.ToBoardID;
					}
					else
					{
						this._BoardID = default(int);
					}
					this.SendPropertyChanged("TaskMovements1");
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
		
		private void attach_Projects(Projects entity)
		{
			this.SendPropertyChanging();
			entity.Boards = this;
		}
		
		private void detach_Projects(Projects entity)
		{
			this.SendPropertyChanging();
			entity.Boards = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Tasks : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TaskID;
		
		private int _BoardID;
		
		private string _TaskTitle;
		
		private string _TaskDescription;
		
		private int _UserID;
		
		private EntitySet<Users> _Users;
		
		private EntitySet<Boards> _Boards;
		
		private EntityRef<TaskMovements> _TaskMovements;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTaskIDChanging(int value);
    partial void OnTaskIDChanged();
    partial void OnBoardIDChanging(int value);
    partial void OnBoardIDChanged();
    partial void OnTaskTitleChanging(string value);
    partial void OnTaskTitleChanged();
    partial void OnTaskDescriptionChanging(string value);
    partial void OnTaskDescriptionChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    #endregion
		
		public Tasks()
		{
			this._Users = new EntitySet<Users>(new Action<Users>(this.attach_Users), new Action<Users>(this.detach_Users));
			this._Boards = new EntitySet<Boards>(new Action<Boards>(this.attach_Boards), new Action<Boards>(this.detach_Boards));
			this._TaskMovements = default(EntityRef<TaskMovements>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskID", DbType="INT PRIMARY KEY IDENTITY", IsPrimaryKey=true)]
		public int TaskID
		{
			get
			{
				return this._TaskID;
			}
			set
			{
				if ((this._TaskID != value))
				{
					if (this._TaskMovements.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTaskIDChanging(value);
					this.SendPropertyChanging();
					this._TaskID = value;
					this.SendPropertyChanged("TaskID");
					this.OnTaskIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BoardID")]
		public int BoardID
		{
			get
			{
				return this._BoardID;
			}
			set
			{
				if ((this._BoardID != value))
				{
					this.OnBoardIDChanging(value);
					this.SendPropertyChanging();
					this._BoardID = value;
					this.SendPropertyChanged("BoardID");
					this.OnBoardIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskTitle", DbType="NVARCHAR(100) NOT NULL", CanBeNull=false)]
		public string TaskTitle
		{
			get
			{
				return this._TaskTitle;
			}
			set
			{
				if ((this._TaskTitle != value))
				{
					this.OnTaskTitleChanging(value);
					this.SendPropertyChanging();
					this._TaskTitle = value;
					this.SendPropertyChanged("TaskTitle");
					this.OnTaskTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskDescription", DbType="NVARCHAR(MAX)", CanBeNull=false)]
		public string TaskDescription
		{
			get
			{
				return this._TaskDescription;
			}
			set
			{
				if ((this._TaskDescription != value))
				{
					this.OnTaskDescriptionChanging(value);
					this.SendPropertyChanging();
					this._TaskDescription = value;
					this.SendPropertyChanged("TaskDescription");
					this.OnTaskDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="INT")]
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
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tasks_Users", Storage="_Users", ThisKey="UserID", OtherKey="UserID")]
		public EntitySet<Users> Users
		{
			get
			{
				return this._Users;
			}
			set
			{
				this._Users.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tasks_Boards", Storage="_Boards", ThisKey="BoardID", OtherKey="BoardID")]
		public EntitySet<Boards> Boards
		{
			get
			{
				return this._Boards;
			}
			set
			{
				this._Boards.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TaskMovements_Tasks", Storage="_TaskMovements", ThisKey="TaskID", OtherKey="TaskID", IsForeignKey=true)]
		public TaskMovements TaskMovements
		{
			get
			{
				return this._TaskMovements.Entity;
			}
			set
			{
				TaskMovements previousValue = this._TaskMovements.Entity;
				if (((previousValue != value) 
							|| (this._TaskMovements.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TaskMovements.Entity = null;
						previousValue.Tasks.Remove(this);
					}
					this._TaskMovements.Entity = value;
					if ((value != null))
					{
						value.Tasks.Add(this);
						this._TaskID = value.TaskID;
					}
					else
					{
						this._TaskID = default(int);
					}
					this.SendPropertyChanged("TaskMovements");
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
		
		private void attach_Users(Users entity)
		{
			this.SendPropertyChanging();
			entity.Tasks = this;
		}
		
		private void detach_Users(Users entity)
		{
			this.SendPropertyChanging();
			entity.Tasks = null;
		}
		
		private void attach_Boards(Boards entity)
		{
			this.SendPropertyChanging();
			entity.Tasks = this;
		}
		
		private void detach_Boards(Boards entity)
		{
			this.SendPropertyChanging();
			entity.Tasks = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class ProjectMembers : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProjectID;
		
		private int _UserID;
		
		private EntitySet<Users> _Users;
		
		private EntitySet<Projects> _Projects;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProjectIDChanging(int value);
    partial void OnProjectIDChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    #endregion
		
		public ProjectMembers()
		{
			this._Users = new EntitySet<Users>(new Action<Users>(this.attach_Users), new Action<Users>(this.detach_Users));
			this._Projects = new EntitySet<Projects>(new Action<Projects>(this.attach_Projects), new Action<Projects>(this.detach_Projects));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectID", DbType="INT NOT NULL", IsPrimaryKey=true)]
		public int ProjectID
		{
			get
			{
				return this._ProjectID;
			}
			set
			{
				if ((this._ProjectID != value))
				{
					this.OnProjectIDChanging(value);
					this.SendPropertyChanging();
					this._ProjectID = value;
					this.SendPropertyChanged("ProjectID");
					this.OnProjectIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="INT NOT NULL", IsPrimaryKey=true)]
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
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProjectMembers_Users", Storage="_Users", ThisKey="UserID", OtherKey="UserID")]
		public EntitySet<Users> Users
		{
			get
			{
				return this._Users;
			}
			set
			{
				this._Users.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProjectMembers_Projects", Storage="_Projects", ThisKey="ProjectID", OtherKey="ProjectID")]
		public EntitySet<Projects> Projects
		{
			get
			{
				return this._Projects;
			}
			set
			{
				this._Projects.Assign(value);
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
		
		private void attach_Users(Users entity)
		{
			this.SendPropertyChanging();
			entity.ProjectMembers = this;
		}
		
		private void detach_Users(Users entity)
		{
			this.SendPropertyChanging();
			entity.ProjectMembers = null;
		}
		
		private void attach_Projects(Projects entity)
		{
			this.SendPropertyChanging();
			entity.ProjectMembers = this;
		}
		
		private void detach_Projects(Projects entity)
		{
			this.SendPropertyChanging();
			entity.ProjectMembers = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class TaskMovements : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MovementID;
		
		private int _TaskID;
		
		private int _FromBoardID;
		
		private int _ToBoardID;
		
		private System.DateTime _MovementTimestamp;
		
		private EntitySet<Boards> _Boards;
		
		private EntitySet<Boards> _Boards1;
		
		private EntitySet<Tasks> _Tasks;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMovementIDChanging(int value);
    partial void OnMovementIDChanged();
    partial void OnTaskIDChanging(int value);
    partial void OnTaskIDChanged();
    partial void OnFromBoardIDChanging(int value);
    partial void OnFromBoardIDChanged();
    partial void OnToBoardIDChanging(int value);
    partial void OnToBoardIDChanged();
    partial void OnMovementTimestampChanging(System.DateTime value);
    partial void OnMovementTimestampChanged();
    #endregion
		
		public TaskMovements()
		{
			this._Boards = new EntitySet<Boards>(new Action<Boards>(this.attach_Boards), new Action<Boards>(this.detach_Boards));
			this._Boards1 = new EntitySet<Boards>(new Action<Boards>(this.attach_Boards1), new Action<Boards>(this.detach_Boards1));
			this._Tasks = new EntitySet<Tasks>(new Action<Tasks>(this.attach_Tasks), new Action<Tasks>(this.detach_Tasks));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MovementID", DbType="INT PRIMARY KEY IDENTITY", IsPrimaryKey=true)]
		public int MovementID
		{
			get
			{
				return this._MovementID;
			}
			set
			{
				if ((this._MovementID != value))
				{
					this.OnMovementIDChanging(value);
					this.SendPropertyChanging();
					this._MovementID = value;
					this.SendPropertyChanged("MovementID");
					this.OnMovementIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskID", DbType="INT NOT NULL")]
		public int TaskID
		{
			get
			{
				return this._TaskID;
			}
			set
			{
				if ((this._TaskID != value))
				{
					this.OnTaskIDChanging(value);
					this.SendPropertyChanging();
					this._TaskID = value;
					this.SendPropertyChanged("TaskID");
					this.OnTaskIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromBoardID", DbType="INT NOT NULL")]
		public int FromBoardID
		{
			get
			{
				return this._FromBoardID;
			}
			set
			{
				if ((this._FromBoardID != value))
				{
					this.OnFromBoardIDChanging(value);
					this.SendPropertyChanging();
					this._FromBoardID = value;
					this.SendPropertyChanged("FromBoardID");
					this.OnFromBoardIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToBoardID", DbType="INT NOT NULL")]
		public int ToBoardID
		{
			get
			{
				return this._ToBoardID;
			}
			set
			{
				if ((this._ToBoardID != value))
				{
					this.OnToBoardIDChanging(value);
					this.SendPropertyChanging();
					this._ToBoardID = value;
					this.SendPropertyChanged("ToBoardID");
					this.OnToBoardIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MovementTimestamp", DbType="DATETIME")]
		public System.DateTime MovementTimestamp
		{
			get
			{
				return this._MovementTimestamp;
			}
			set
			{
				if ((this._MovementTimestamp != value))
				{
					this.OnMovementTimestampChanging(value);
					this.SendPropertyChanging();
					this._MovementTimestamp = value;
					this.SendPropertyChanged("MovementTimestamp");
					this.OnMovementTimestampChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TaskMovements_Boards", Storage="_Boards", ThisKey="FromBoardID", OtherKey="BoardID")]
		public EntitySet<Boards> Boards
		{
			get
			{
				return this._Boards;
			}
			set
			{
				this._Boards.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TaskMovements_Boards1", Storage="_Boards1", ThisKey="ToBoardID", OtherKey="BoardID")]
		public EntitySet<Boards> Boards1
		{
			get
			{
				return this._Boards1;
			}
			set
			{
				this._Boards1.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TaskMovements_Tasks", Storage="_Tasks", ThisKey="TaskID", OtherKey="TaskID")]
		public EntitySet<Tasks> Tasks
		{
			get
			{
				return this._Tasks;
			}
			set
			{
				this._Tasks.Assign(value);
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
		
		private void attach_Boards(Boards entity)
		{
			this.SendPropertyChanging();
			entity.TaskMovements = this;
		}
		
		private void detach_Boards(Boards entity)
		{
			this.SendPropertyChanging();
			entity.TaskMovements = null;
		}
		
		private void attach_Boards1(Boards entity)
		{
			this.SendPropertyChanging();
			entity.TaskMovements1 = this;
		}
		
		private void detach_Boards1(Boards entity)
		{
			this.SendPropertyChanging();
			entity.TaskMovements1 = null;
		}
		
		private void attach_Tasks(Tasks entity)
		{
			this.SendPropertyChanging();
			entity.TaskMovements = this;
		}
		
		private void detach_Tasks(Tasks entity)
		{
			this.SendPropertyChanging();
			entity.TaskMovements = null;
		}
	}
}
#pragma warning restore 1591