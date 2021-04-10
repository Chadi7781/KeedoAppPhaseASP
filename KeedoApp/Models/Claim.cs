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
		private User user;
		private Kindergarden kindergarden;

		private DateTime createdAt;

		private DateTime updatedAt;


		private ClaimStatus status;
		private DateTime checkedAt;

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


		public virtual User User
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


		public virtual DateTime UpdatedAt
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


		public virtual DateTime CheckedAt
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


		public override string ToString()
		{
			return "Claim [idClaim=" + idClaim + ", description=" + description + ", category=" + category + ", kindergarden=" + kindergarden + ", createdAt=" + createdAt + ", updatedAt=" + updatedAt + ", status=" + status + ", checkedAt=" + checkedAt + "]";
		}









	}
}
