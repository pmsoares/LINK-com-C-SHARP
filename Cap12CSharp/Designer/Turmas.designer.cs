﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LINQToSQL.Designer
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
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="Turmas")]
	public partial class TurmasDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertContacto(Contacto instance);
    partial void UpdateContacto(Contacto instance);
    partial void DeleteContacto(Contacto instance);
    partial void InsertTurma(Turma instance);
    partial void UpdateTurma(Turma instance);
    partial void DeleteTurma(Turma instance);
    partial void InsertDisciplina(Disciplina instance);
    partial void UpdateDisciplina(Disciplina instance);
    partial void DeleteDisciplina(Disciplina instance);
    partial void InsertDisciplinasEstudante(DisciplinasEstudante instance);
    partial void UpdateDisciplinasEstudante(DisciplinasEstudante instance);
    partial void DeleteDisciplinasEstudante(DisciplinasEstudante instance);
    partial void InsertEstudante(Estudante instance);
    partial void UpdateEstudante(Estudante instance);
    partial void DeleteEstudante(Estudante instance);
    partial void InsertMorada(Morada instance);
    partial void UpdateMorada(Morada instance);
    partial void DeleteMorada(Morada instance);
    #endregion
		
		public TurmasDataContext() : 
				base(global::LINQToSQL.Properties.Settings.Default.TurmasConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TurmasDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TurmasDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TurmasDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TurmasDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Contacto> Contactos
		{
			get
			{
				return this.GetTable<Contacto>();
			}
		}
		
		public System.Data.Linq.Table<Turma> Turmas
		{
			get
			{
				return this.GetTable<Turma>();
			}
		}
		
		public System.Data.Linq.Table<Disciplina> Disciplinas
		{
			get
			{
				return this.GetTable<Disciplina>();
			}
		}
		
		public System.Data.Linq.Table<DisciplinasEstudante> DisciplinasEstudantes
		{
			get
			{
				return this.GetTable<DisciplinasEstudante>();
			}
		}
		
		public System.Data.Linq.Table<Estudante> Estudantes
		{
			get
			{
				return this.GetTable<Estudante>();
			}
		}
		
		public System.Data.Linq.Table<Morada> Moradas
		{
			get
			{
				return this.GetTable<Morada>();
			}
		}
		
		[Function(Name="dbo.ObtemContactos")]
		public ISingleResult<ObtemContactosResult> ObtemContactos()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<ObtemContactosResult>)(result.ReturnValue));
		}
		
		[Function(Name="dbo.ObtemContactosDoEstudante")]
		public ISingleResult<ObtemContactosDoEstudanteResult> ObtemContactosDoEstudante([Parameter(DbType="Int")] System.Nullable<int> id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((ISingleResult<ObtemContactosDoEstudanteResult>)(result.ReturnValue));
		}
	}
	
	[Table(Name="dbo.Contactos")]
	public partial class Contacto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdContacto;
		
		private int _IdEstudante;
		
		private int _Tipo;
		
		private string _Valor;
		
		private System.Data.Linq.Binary _Version;
		
		private EntityRef<Estudante> _Estudante;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdContactoChanging(int value);
    partial void OnIdContactoChanged();
    partial void OnIdEstudanteChanging(int value);
    partial void OnIdEstudanteChanged();
    partial void OnTipoChanging(int value);
    partial void OnTipoChanged();
    partial void OnValorChanging(string value);
    partial void OnValorChanged();
    partial void OnVersaoChanging(System.Data.Linq.Binary value);
    partial void OnVersaoChanged();
    #endregion
		
		public Contacto()
		{
			this._Estudante = default(EntityRef<Estudante>);
			OnCreated();
		}
		
		[Column(Storage="_IdContacto", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int IdContacto
		{
			get
			{
				return this._IdContacto;
			}
			set
			{
				if ((this._IdContacto != value))
				{
					this.OnIdContactoChanging(value);
					this.SendPropertyChanging();
					this._IdContacto = value;
					this.SendPropertyChanged("IdContacto");
					this.OnIdContactoChanged();
				}
			}
		}
		
		[Column(Storage="_IdEstudante", DbType="Int NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public int IdEstudante
		{
			get
			{
				return this._IdEstudante;
			}
			set
			{
				if ((this._IdEstudante != value))
				{
					if (this._Estudante.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdEstudanteChanging(value);
					this.SendPropertyChanging();
					this._IdEstudante = value;
					this.SendPropertyChanged("IdEstudante");
					this.OnIdEstudanteChanged();
				}
			}
		}
		
		[Column(Storage="_Tipo", DbType="Int NOT NULL", UpdateCheck=UpdateCheck.Never, IsDiscriminator=true)]
		public int Tipo
		{
			get
			{
				return this._Tipo;
			}
			set
			{
				if ((this._Tipo != value))
				{
					this.OnTipoChanging(value);
					this.SendPropertyChanging();
					this._Tipo = value;
					this.SendPropertyChanged("Tipo");
					this.OnTipoChanged();
				}
			}
		}
		
		[Column(Storage="_Valor", DbType="VarChar(100) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Valor
		{
			get
			{
				return this._Valor;
			}
			set
			{
				if ((this._Valor != value))
				{
					this.OnValorChanging(value);
					this.SendPropertyChanging();
					this._Valor = value;
					this.SendPropertyChanged("Valor");
					this.OnValorChanged();
				}
			}
		}
		
		[Column(Storage="_Version", AutoSync=AutoSync.Always, DbType="rowversion NOT NULL", CanBeNull=false, IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Versao
		{
			get
			{
				return this._Version;
			}
			set
			{
				if ((this._Version != value))
				{
					this.OnVersaoChanging(value);
					this.SendPropertyChanging();
					this._Version = value;
					this.SendPropertyChanged("Versao");
					this.OnVersaoChanged();
				}
			}
		}
		
		[Association(Name="Estudante_Contacto", Storage="_Estudante", ThisKey="IdEstudante", OtherKey="IdEstudante", IsForeignKey=true)]
		public Estudante Estudante
		{
			get
			{
				return this._Estudante.Entity;
			}
			set
			{
				Estudante previousValue = this._Estudante.Entity;
				if (((previousValue != value) 
							|| (this._Estudante.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Estudante.Entity = null;
						previousValue.Contactos.Remove(this);
					}
					this._Estudante.Entity = value;
					if ((value != null))
					{
						value.Contactos.Add(this);
						this._IdEstudante = value.IdEstudante;
					}
					else
					{
						this._IdEstudante = default(int);
					}
					this.SendPropertyChanged("Estudante");
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
	
	public partial class Telefone : Contacto
	{
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    #endregion
		
		public Telefone()
		{
			OnCreated();
		}
	}
	
	public partial class Email : Contacto
	{
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    #endregion
		
		public Email()
		{
			OnCreated();
		}
	}
	
	[Table(Name="dbo.Turmas")]
	public partial class Turma : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdTurma;
		
		private string _Designacao;
		
		private System.Data.Linq.Binary _Version;
		
		private EntitySet<Estudante> _Estudantes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdTurmaChanging(int value);
    partial void OnIdTurmaChanged();
    partial void OnDesignacaoChanging(string value);
    partial void OnDesignacaoChanged();
    partial void OnVersaoChanging(System.Data.Linq.Binary value);
    partial void OnVersaoChanged();
    #endregion
		
		public Turma()
		{
			this._Estudantes = new EntitySet<Estudante>(new Action<Estudante>(this.attach_Estudantes), new Action<Estudante>(this.detach_Estudantes));
			OnCreated();
		}
		
		[Column(Storage="_IdTurma", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int IdTurma
		{
			get
			{
				return this._IdTurma;
			}
			set
			{
				if ((this._IdTurma != value))
				{
					this.OnIdTurmaChanging(value);
					this.SendPropertyChanging();
					this._IdTurma = value;
					this.SendPropertyChanged("IdTurma");
					this.OnIdTurmaChanged();
				}
			}
		}
		
		[Column(Storage="_Designacao", DbType="VarChar(100) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Designacao
		{
			get
			{
				return this._Designacao;
			}
			set
			{
				if ((this._Designacao != value))
				{
					this.OnDesignacaoChanging(value);
					this.SendPropertyChanging();
					this._Designacao = value;
					this.SendPropertyChanged("Designacao");
					this.OnDesignacaoChanged();
				}
			}
		}
		
		[Column(Storage="_Version", AutoSync=AutoSync.Always, DbType="rowversion NOT NULL", CanBeNull=false, IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Versao
		{
			get
			{
				return this._Version;
			}
			set
			{
				if ((this._Version != value))
				{
					this.OnVersaoChanging(value);
					this.SendPropertyChanging();
					this._Version = value;
					this.SendPropertyChanged("Versao");
					this.OnVersaoChanged();
				}
			}
		}
		
		[Association(Name="Turma_Estudante", Storage="_Estudantes", ThisKey="IdTurma", OtherKey="IdTurma")]
		public EntitySet<Estudante> Estudantes
		{
			get
			{
				return this._Estudantes;
			}
			set
			{
				this._Estudantes.Assign(value);
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
		
		private void attach_Estudantes(Estudante entity)
		{
			this.SendPropertyChanging();
			entity.Turma = this;
		}
		
		private void detach_Estudantes(Estudante entity)
		{
			this.SendPropertyChanging();
			entity.Turma = null;
		}
	}
	
	[Table(Name="dbo.Disciplinas")]
	public partial class Disciplina : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdDisciplina;
		
		private string _Designacao;
		
		private System.Data.Linq.Binary _Version;
		
		private EntitySet<DisciplinasEstudante> _DisciplinasEstudantes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdDisciplinaChanging(int value);
    partial void OnIdDisciplinaChanged();
    partial void OnDesignacaoChanging(string value);
    partial void OnDesignacaoChanged();
    partial void OnVersaoChanging(System.Data.Linq.Binary value);
    partial void OnVersaoChanged();
    #endregion
		
		public Disciplina()
		{
			this._DisciplinasEstudantes = new EntitySet<DisciplinasEstudante>(new Action<DisciplinasEstudante>(this.attach_DisciplinasEstudantes), new Action<DisciplinasEstudante>(this.detach_DisciplinasEstudantes));
			OnCreated();
		}
		
		[Column(Storage="_IdDisciplina", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int IdDisciplina
		{
			get
			{
				return this._IdDisciplina;
			}
			set
			{
				if ((this._IdDisciplina != value))
				{
					this.OnIdDisciplinaChanging(value);
					this.SendPropertyChanging();
					this._IdDisciplina = value;
					this.SendPropertyChanged("IdDisciplina");
					this.OnIdDisciplinaChanged();
				}
			}
		}
		
		[Column(Storage="_Designacao", DbType="VarChar(100) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Designacao
		{
			get
			{
				return this._Designacao;
			}
			set
			{
				if ((this._Designacao != value))
				{
					this.OnDesignacaoChanging(value);
					this.SendPropertyChanging();
					this._Designacao = value;
					this.SendPropertyChanged("Designacao");
					this.OnDesignacaoChanged();
				}
			}
		}
		
		[Column(Storage="_Version", AutoSync=AutoSync.Always, DbType="rowversion NOT NULL", CanBeNull=false, IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Versao
		{
			get
			{
				return this._Version;
			}
			set
			{
				if ((this._Version != value))
				{
					this.OnVersaoChanging(value);
					this.SendPropertyChanging();
					this._Version = value;
					this.SendPropertyChanged("Versao");
					this.OnVersaoChanged();
				}
			}
		}
		
		[Association(Name="Disciplina_DisciplinasEstudante", Storage="_DisciplinasEstudantes", ThisKey="IdDisciplina", OtherKey="IdDisciplina")]
		public EntitySet<DisciplinasEstudante> DisciplinasEstudantes
		{
			get
			{
				return this._DisciplinasEstudantes;
			}
			set
			{
				this._DisciplinasEstudantes.Assign(value);
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
		
		private void attach_DisciplinasEstudantes(DisciplinasEstudante entity)
		{
			this.SendPropertyChanging();
			entity.Disciplina = this;
		}
		
		private void detach_DisciplinasEstudantes(DisciplinasEstudante entity)
		{
			this.SendPropertyChanging();
			entity.Disciplina = null;
		}
	}
	
	[Table(Name="dbo.DisciplinasEstudantes")]
	public partial class DisciplinasEstudante : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdDisciplina;
		
		private int _IdEstudante;
		
		private EntityRef<Disciplina> _Disciplina;
		
		private EntityRef<Estudante> _Estudante;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdDisciplinaChanging(int value);
    partial void OnIdDisciplinaChanged();
    partial void OnIdEstudanteChanging(int value);
    partial void OnIdEstudanteChanged();
    #endregion
		
		public DisciplinasEstudante()
		{
			this._Disciplina = default(EntityRef<Disciplina>);
			this._Estudante = default(EntityRef<Estudante>);
			OnCreated();
		}
		
		[Column(Storage="_IdDisciplina", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IdDisciplina
		{
			get
			{
				return this._IdDisciplina;
			}
			set
			{
				if ((this._IdDisciplina != value))
				{
					if (this._Disciplina.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdDisciplinaChanging(value);
					this.SendPropertyChanging();
					this._IdDisciplina = value;
					this.SendPropertyChanged("IdDisciplina");
					this.OnIdDisciplinaChanged();
				}
			}
		}
		
		[Column(Storage="_IdEstudante", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int IdEstudante
		{
			get
			{
				return this._IdEstudante;
			}
			set
			{
				if ((this._IdEstudante != value))
				{
					if (this._Estudante.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdEstudanteChanging(value);
					this.SendPropertyChanging();
					this._IdEstudante = value;
					this.SendPropertyChanged("IdEstudante");
					this.OnIdEstudanteChanged();
				}
			}
		}
		
		[Association(Name="Disciplina_DisciplinasEstudante", Storage="_Disciplina", ThisKey="IdDisciplina", OtherKey="IdDisciplina", IsForeignKey=true)]
		public Disciplina Disciplina
		{
			get
			{
				return this._Disciplina.Entity;
			}
			set
			{
				Disciplina previousValue = this._Disciplina.Entity;
				if (((previousValue != value) 
							|| (this._Disciplina.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Disciplina.Entity = null;
						previousValue.DisciplinasEstudantes.Remove(this);
					}
					this._Disciplina.Entity = value;
					if ((value != null))
					{
						value.DisciplinasEstudantes.Add(this);
						this._IdDisciplina = value.IdDisciplina;
					}
					else
					{
						this._IdDisciplina = default(int);
					}
					this.SendPropertyChanged("Disciplina");
				}
			}
		}
		
		[Association(Name="Estudante_DisciplinasEstudante", Storage="_Estudante", ThisKey="IdEstudante", OtherKey="IdEstudante", IsForeignKey=true)]
		public Estudante Estudante
		{
			get
			{
				return this._Estudante.Entity;
			}
			set
			{
				Estudante previousValue = this._Estudante.Entity;
				if (((previousValue != value) 
							|| (this._Estudante.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Estudante.Entity = null;
						previousValue.DisciplinasEstudantes.Remove(this);
					}
					this._Estudante.Entity = value;
					if ((value != null))
					{
						value.DisciplinasEstudantes.Add(this);
						this._IdEstudante = value.IdEstudante;
					}
					else
					{
						this._IdEstudante = default(int);
					}
					this.SendPropertyChanged("Estudante");
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
	
	[Table(Name="dbo.Estudantes")]
	public partial class Estudante : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdEstudante;
		
		private string _Nome;
		
		private int _IdTurma;
		
		private System.Data.Linq.Binary _Version;
		
		private EntitySet<Contacto> _Contactos;
		
		private EntitySet<DisciplinasEstudante> _DisciplinasEstudantes;
		
		private EntitySet<Morada> _Moradas;
		
		private EntityRef<Turma> _Turma;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdEstudanteChanging(int value);
    partial void OnIdEstudanteChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnIdTurmaChanging(int value);
    partial void OnIdTurmaChanged();
    partial void OnVersaoChanging(System.Data.Linq.Binary value);
    partial void OnVersaoChanged();
    #endregion
		
		public Estudante()
		{
			this._Contactos = new EntitySet<Contacto>(new Action<Contacto>(this.attach_Contactos), new Action<Contacto>(this.detach_Contactos));
			this._DisciplinasEstudantes = new EntitySet<DisciplinasEstudante>(new Action<DisciplinasEstudante>(this.attach_DisciplinasEstudantes), new Action<DisciplinasEstudante>(this.detach_DisciplinasEstudantes));
			this._Moradas = new EntitySet<Morada>(new Action<Morada>(this.attach_Moradas), new Action<Morada>(this.detach_Moradas));
			this._Turma = default(EntityRef<Turma>);
			OnCreated();
		}
		
		[Column(Storage="_IdEstudante", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int IdEstudante
		{
			get
			{
				return this._IdEstudante;
			}
			set
			{
				if ((this._IdEstudante != value))
				{
					this.OnIdEstudanteChanging(value);
					this.SendPropertyChanging();
					this._IdEstudante = value;
					this.SendPropertyChanged("IdEstudante");
					this.OnIdEstudanteChanged();
				}
			}
		}
		
		[Column(Storage="_Nome", DbType="VarChar(100) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[Column(Storage="_IdTurma", DbType="Int NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public int IdTurma
		{
			get
			{
				return this._IdTurma;
			}
			set
			{
				if ((this._IdTurma != value))
				{
					if (this._Turma.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdTurmaChanging(value);
					this.SendPropertyChanging();
					this._IdTurma = value;
					this.SendPropertyChanged("IdTurma");
					this.OnIdTurmaChanged();
				}
			}
		}
		
		[Column(Storage="_Version", AutoSync=AutoSync.Always, DbType="rowversion NOT NULL", CanBeNull=false, IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Versao
		{
			get
			{
				return this._Version;
			}
			set
			{
				if ((this._Version != value))
				{
					this.OnVersaoChanging(value);
					this.SendPropertyChanging();
					this._Version = value;
					this.SendPropertyChanged("Versao");
					this.OnVersaoChanged();
				}
			}
		}
		
		[Association(Name="Estudante_Contacto", Storage="_Contactos", ThisKey="IdEstudante", OtherKey="IdEstudante")]
		public EntitySet<Contacto> Contactos
		{
			get
			{
				return this._Contactos;
			}
			set
			{
				this._Contactos.Assign(value);
			}
		}
		
		[Association(Name="Estudante_DisciplinasEstudante", Storage="_DisciplinasEstudantes", ThisKey="IdEstudante", OtherKey="IdEstudante")]
		public EntitySet<DisciplinasEstudante> DisciplinasEstudantes
		{
			get
			{
				return this._DisciplinasEstudantes;
			}
			set
			{
				this._DisciplinasEstudantes.Assign(value);
			}
		}
		
		[Association(Name="Estudante_Morada", Storage="_Moradas", ThisKey="IdEstudante", OtherKey="IdEstudante")]
		public EntitySet<Morada> Moradas
		{
			get
			{
				return this._Moradas;
			}
			set
			{
				this._Moradas.Assign(value);
			}
		}
		
		[Association(Name="Turma_Estudante", Storage="_Turma", ThisKey="IdTurma", OtherKey="IdTurma", IsForeignKey=true)]
		public Turma Turma
		{
			get
			{
				return this._Turma.Entity;
			}
			set
			{
				Turma previousValue = this._Turma.Entity;
				if (((previousValue != value) 
							|| (this._Turma.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Turma.Entity = null;
						previousValue.Estudantes.Remove(this);
					}
					this._Turma.Entity = value;
					if ((value != null))
					{
						value.Estudantes.Add(this);
						this._IdTurma = value.IdTurma;
					}
					else
					{
						this._IdTurma = default(int);
					}
					this.SendPropertyChanged("Turma");
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
		
		private void attach_Contactos(Contacto entity)
		{
			this.SendPropertyChanging();
			entity.Estudante = this;
		}
		
		private void detach_Contactos(Contacto entity)
		{
			this.SendPropertyChanging();
			entity.Estudante = null;
		}
		
		private void attach_DisciplinasEstudantes(DisciplinasEstudante entity)
		{
			this.SendPropertyChanging();
			entity.Estudante = this;
		}
		
		private void detach_DisciplinasEstudantes(DisciplinasEstudante entity)
		{
			this.SendPropertyChanging();
			entity.Estudante = null;
		}
		
		private void attach_Moradas(Morada entity)
		{
			this.SendPropertyChanging();
			entity.Estudante = this;
		}
		
		private void detach_Moradas(Morada entity)
		{
			this.SendPropertyChanging();
			entity.Estudante = null;
		}
	}
	
	[Table(Name="dbo.Moradas")]
	public partial class Morada : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdMorada;
		
		private int _IdEstudante;
		
		private string _Rua;
		
		private string _CodigoPostal;
		
		private System.Data.Linq.Binary _Version;
		
		private EntityRef<Estudante> _Estudante;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdMoradaChanging(int value);
    partial void OnIdMoradaChanged();
    partial void OnIdEstudanteChanging(int value);
    partial void OnIdEstudanteChanged();
    partial void OnRuaChanging(string value);
    partial void OnRuaChanged();
    partial void OnCodigoPostalChanging(string value);
    partial void OnCodigoPostalChanged();
    partial void OnVersaoChanging(System.Data.Linq.Binary value);
    partial void OnVersaoChanged();
    #endregion
		
		public Morada()
		{
			this._Estudante = default(EntityRef<Estudante>);
			OnCreated();
		}
		
		[Column(Storage="_IdMorada", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, UpdateCheck=UpdateCheck.Never)]
		public int IdMorada
		{
			get
			{
				return this._IdMorada;
			}
			set
			{
				if ((this._IdMorada != value))
				{
					this.OnIdMoradaChanging(value);
					this.SendPropertyChanging();
					this._IdMorada = value;
					this.SendPropertyChanged("IdMorada");
					this.OnIdMoradaChanged();
				}
			}
		}
		
		[Column(Storage="_IdEstudante", DbType="Int NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public int IdEstudante
		{
			get
			{
				return this._IdEstudante;
			}
			set
			{
				if ((this._IdEstudante != value))
				{
					if (this._Estudante.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdEstudanteChanging(value);
					this.SendPropertyChanging();
					this._IdEstudante = value;
					this.SendPropertyChanged("IdEstudante");
					this.OnIdEstudanteChanged();
				}
			}
		}
		
		[Column(Storage="_Rua", DbType="VarChar(100) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Rua
		{
			get
			{
				return this._Rua;
			}
			set
			{
				if ((this._Rua != value))
				{
					this.OnRuaChanging(value);
					this.SendPropertyChanging();
					this._Rua = value;
					this.SendPropertyChanged("Rua");
					this.OnRuaChanged();
				}
			}
		}
		
		[Column(Storage="_CodigoPostal", DbType="VarChar(100) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string CodigoPostal
		{
			get
			{
				return this._CodigoPostal;
			}
			set
			{
				if ((this._CodigoPostal != value))
				{
					this.OnCodigoPostalChanging(value);
					this.SendPropertyChanging();
					this._CodigoPostal = value;
					this.SendPropertyChanged("CodigoPostal");
					this.OnCodigoPostalChanged();
				}
			}
		}
		
		[Column(Storage="_Version", AutoSync=AutoSync.Always, DbType="rowversion NOT NULL", CanBeNull=false, IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Versao
		{
			get
			{
				return this._Version;
			}
			set
			{
				if ((this._Version != value))
				{
					this.OnVersaoChanging(value);
					this.SendPropertyChanging();
					this._Version = value;
					this.SendPropertyChanged("Versao");
					this.OnVersaoChanged();
				}
			}
		}
		
		[Association(Name="Estudante_Morada", Storage="_Estudante", ThisKey="IdEstudante", OtherKey="IdEstudante", IsForeignKey=true)]
		public Estudante Estudante
		{
			get
			{
				return this._Estudante.Entity;
			}
			set
			{
				Estudante previousValue = this._Estudante.Entity;
				if (((previousValue != value) 
							|| (this._Estudante.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Estudante.Entity = null;
						previousValue.Moradas.Remove(this);
					}
					this._Estudante.Entity = value;
					if ((value != null))
					{
						value.Moradas.Add(this);
						this._IdEstudante = value.IdEstudante;
					}
					else
					{
						this._IdEstudante = default(int);
					}
					this.SendPropertyChanged("Estudante");
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
	
	public partial class ObtemContactosResult
	{
		
		private string _nome;
		
		private string _valor;
		
		public ObtemContactosResult()
		{
		}
		
		[Column(Storage="_nome", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string nome
		{
			get
			{
				return this._nome;
			}
			set
			{
				if ((this._nome != value))
				{
					this._nome = value;
				}
			}
		}
		
		[Column(Storage="_valor", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string valor
		{
			get
			{
				return this._valor;
			}
			set
			{
				if ((this._valor != value))
				{
					this._valor = value;
				}
			}
		}
	}
	
	public partial class ObtemContactosDoEstudanteResult
	{
		
		private string _nome;
		
		private string _valor;
		
		public ObtemContactosDoEstudanteResult()
		{
		}
		
		[Column(Storage="_nome", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string nome
		{
			get
			{
				return this._nome;
			}
			set
			{
				if ((this._nome != value))
				{
					this._nome = value;
				}
			}
		}
		
		[Column(Storage="_valor", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string valor
		{
			get
			{
				return this._valor;
			}
			set
			{
				if ((this._valor != value))
				{
					this._valor = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
