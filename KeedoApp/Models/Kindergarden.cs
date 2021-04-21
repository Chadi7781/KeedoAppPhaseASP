using KeedoApp.Models;
using System;
using System.Collections.Generic;
using tn.esprit.pi.entities;

namespace KeedoApp.Models

{





	[Serializable]
	public class Kindergarden
	{
		private const long serialVersionUID = 1L;

		private int id;

		private string name;

		private ISet<Claim> claims;


		private User director;


		private DateTime createdAt;

		private Nullable<DateTime> updatedAt;



		

		public Kindergarden() : base()
		{

		}

		public Kindergarden(int id, string name) : base()
		{
			this.id = id;
			this.name = name;
		}

		public virtual int Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}


		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				this.name = value;
			}
		}




		public virtual ISet<Claim> Claims
		{
			get
			{
				return claims;
			}
			set
			{
				this.claims = value;
			}
		}




		public virtual User Director
		{
			get
			{
				return director;
			}
			set
			{
				this.director = value;
			}
		}




		public virtual DateTime CreatedAt
		{
			get
			{
				return createdAt;
			}
			set
			{
				this.createdAt = value;
			}
		}


		public virtual Nullable<DateTime> UpdatedAt
		{
			get
			{
				return updatedAt;
			}
			set
			{
				this.updatedAt = value;
			}
		}


		/*@Override
		public String toString() {
			return "Kindergarden [id=" + id + ", name=" + name + ", claims=" + claims + ", director=" + director
					+ ", createdAt=" + createdAt + ", updatedAt=" + updatedAt + "]";
		}
		*/












	}
}
