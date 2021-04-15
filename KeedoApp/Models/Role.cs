using System;
using System.Collections.Generic;

namespace KeedoApp.Models
{



	[Serializable]
	public class Role
	{

		private const long serialVersionUID = 1L;

		public int idRole;
		private string description;
		private RoleType roleType;
		private ISet<User> user;

		public Role() : base()
		{
		}

		public virtual int IdRole
		{
			get
			{
				return idRole;
			}
			set
			{
				this.idRole = value;
			}
		}


		public virtual string Description
		{
			get
			{
				return description;
			}
			set
			{
				this.description = value;
			}
		}


		public virtual RoleType RoleType
		{
			get
			{
				return roleType;
			}
			set
			{
				this.roleType = value;
			}
		}


		public virtual ISet<User> User
		{
			get
			{
				return user;
			}
			set
			{
				this.user = value;
			}
		}


		public override string ToString()
		{
			return "Role [idRole=" + idRole + ", description=" + description + ", roleType=" + roleType + "]";
		}
	}
}
