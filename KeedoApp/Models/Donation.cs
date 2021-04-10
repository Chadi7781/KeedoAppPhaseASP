using KeedoApp.Models;
using System;
namespace KeedoApp.Models

{


	[Serializable]
	public class Donation
	{

		/// 
		private const long serialVersionUID = 1L;
		
		private int id;
	
		private Event eventt;

		private User user;
		private string contributionDate;
		private float amount;

		public Donation() : base()
		{
			// TODO Auto-generated constructor stub
		}

		public Donation(int id, Event eventt, User user, string contributionDate, float amount) : base()
		{
			this.id = id;
			this.eventt = eventt;
			this.user = user;
			this.contributionDate = contributionDate;
			this.amount = amount;
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


		public virtual Event Eventt
		{
			get
			{
				return eventt;
			}
			set
			{
				this.eventt = value;
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


		public virtual string ContributionDate
		{
			get
			{
				return contributionDate;
			}
			set
			{
				this.contributionDate = value;
			}
		}


		public virtual float Amount
		{
			get
			{
				return amount;
			}
			set
			{
				this.amount = value;
			}
		}




		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (obj == null)
			{
				return false;
			}
			if (this.GetType() != obj.GetType())
			{
				return false;
			}
			Donation other = (Donation)obj;
		
			if (string.ReferenceEquals(contributionDate, null))
			{
				if (!string.ReferenceEquals(other.contributionDate, null))
				{
					return false;
				}
			}
			else if (!contributionDate.Equals(other.contributionDate))
			{
				return false;
			}
			if (eventt == null)
			{
				if (other.eventt != null)
				{
					return false;
				}
			}
			else if (!eventt.Equals(other.eventt))
			{
				return false;
			}
			if (id != other.id)
			{
				return false;
			}
			if (user == null)
			{
				if (other.user != null)
				{
					return false;
				}
			}
			else if (!user.Equals(other.user))
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return "Donation [id=" + id + ", event=" + eventt + ", user=" + user + ", contributionDate=" + contributionDate + ", amount=" + amount + "]";
		}

	}
}
