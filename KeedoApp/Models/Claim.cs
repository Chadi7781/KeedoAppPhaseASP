using KeedoApp.Models;
using System;

namespace tn.esprit.pi.entities
{

	[Serializable]
	public class Claim
	{

		private const long serialVersionUID = 1L;

		private int idClaim;
		private string description;
		private ClaimCategory category;
		public int? parentFk { get; set; }
		private User parent;
		public int? kindergardenFk { get; set; }
		private Kindergarden kindergarden;

		private DateTime createdAt;

		private Nullable<DateTime> updatedAt;


		private ClaimStatus status;
		private Nullable<DateTime> checkedAt;

		public Claim() : base()
		{
		}

		public virtual int IdClaim
		{
			get
			{
				return idClaim;
			}
			set
			{
				this.idClaim = value;
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


		public virtual ClaimCategory Category
		{
			get
			{
				return category;
			}
			set
			{
				this.category = value;
			}
		}


		public virtual User Parent
		{
			get
			{
				return parent;
			}
			set
			{
				this.parent = value;
			}
		}





		public virtual Kindergarden Kindergarden
		{
			get
			{
				return kindergarden;
			}
			set
			{
				this.kindergarden = value;
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


		public virtual ClaimStatus Status
		{
			get
			{
				return status;
			}
			set
			{
				this.status = value;
			}
		}


		public virtual Nullable<DateTime> CheckedAt
		{
			get
			{
				return checkedAt;
			}
			set
			{
				this.checkedAt = value;
			}
		}




	}
}
