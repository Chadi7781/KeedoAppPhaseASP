using KeedoApp.Models;
using System;

namespace KeedoApp.Models
{


	public class Participation
	{


		/// 
		private const long serialVersionUID = 1L;


	//	private ParticipationPK participationPK;
		private float price;

		private string participationDate;

		private User user;


		private Event eventt;

		public Participation() : base()
		{
		}



	

		public virtual float Price
		{
			get
			{
				return price;
			}
			set
			{
				this.price = value;
			}
		}


		public virtual string ParticipationDate
		{
			get
			{
				return participationDate;
			}
			set
			{
				this.participationDate = value;
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


		public virtual Event Event
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





	}
}
