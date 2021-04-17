

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KeedoApp.Models
{



	[Serializable]
	public class Event
	{

		private const long serialVersionUID = 1L;
		private int idEvenement;
		private string title;
		private DateTime date;
		private DateTime hour;
		private string description;
		private bool status;
		private string address;


		private byte[] image;



		private float ticketPrice;


		private float collAmount;


		private int participantsNbr;

		private int placesNbr;


		private bool earlyParticipants;
		private int nbrTicketEarlyParticipants;

		private EventCategory category;
		private int views;

		private List<Participation> participations;



		internal Jackpot jackpot;

		private List<Notification> notifications;


		private float discountPercentage;

		private List<Advertisement> advertisements;


		private IList<Donation> donation;


		private List<Evaluation> evaluations;


		private Kindergarden Kindergarden;


		public Event(int idEvenement, string title, DateTime date, DateTime hour, string description, bool status, string address, byte[] image, float ticketPrice, float collAmount, int participantsNbr, int placesNbr, bool earlyParticipants, int nbrTicketEarlyParticipants, EventCategory category, int views, List<Participation> participations, Jackpot jackpot, List<Notification> notifications, float discountPercentage, List<Advertisement> advertisements, List<Donation> donation) : base()
		{
			this.idEvenement = idEvenement;
			this.title = title;
			this.date = date;
			this.hour = hour;
			this.description = description;
			this.status = status;
			this.address = address;
			this.image = image;
			this.ticketPrice = ticketPrice;
			this.collAmount = collAmount;
			this.participantsNbr = participantsNbr;
			this.placesNbr = placesNbr;
			this.category = category;
			this.views = views;
			this.participations = participations;
			this.jackpot = jackpot;
			this.notifications = notifications;
			this.discountPercentage = discountPercentage;
			this.advertisements = advertisements;
			this.donation = donation;
			this.earlyParticipants = earlyParticipants;
			this.nbrTicketEarlyParticipants = nbrTicketEarlyParticipants;
		}





		public virtual IList<Donation> Donation
		{
			get
			{
				return donation;
			}
			set
			{
				this.donation = value;
			}
		}

		public int PlaceNbr { 
			get
            {
				return placesNbr;

			}
			set
            {
				this.placesNbr = value; 

			}
		
		}

		[DataType(DataType.Time)]
		public DateTime Hour
        {
			get;set;
        }









		public Event(string title, DateTime date, DateTime hour, string description, bool status, string address, byte[] image, float ticketPrice, float collAmount, int participantsNbr, int placesNbr, EventCategory category, int views, bool earlyParticipants, int nbrTicketEarlyParticipants, List<Participation> participations, Jackpot jackpot, List<Notification> notifications, float discountPercentage, List<Advertisement> advertisements, List<Donation> donation) : base()
		{
			this.title = title;
			this.date = date;
			this.hour = hour;
			this.description = description;
			this.status = status;
			this.address = address;
			this.image = image;
			this.ticketPrice = ticketPrice;
			this.collAmount = collAmount;
			this.participantsNbr = participantsNbr;
			this.placesNbr = placesNbr;
			this.category = category;
			this.views = views;
			this.participations = participations;
			this.jackpot = jackpot;
			this.notifications = notifications;
			this.discountPercentage = discountPercentage;
			this.advertisements = advertisements;
			this.donation = donation;
			this.earlyParticipants = earlyParticipants;
			this.nbrTicketEarlyParticipants = nbrTicketEarlyParticipants;
		}





		public Event() : base()
		{
		}





		public virtual float DiscountPercentage
		{
			get
			{
				return discountPercentage;
			}
			set
			{
				this.discountPercentage = value;
			}
		}

		public virtual byte[] Image
		{
			get
			{
				return image ;
			}
			set
			{
				this.image = value;
			}
		}




		public virtual List<Advertisement> Advertisements
		{
			get
			{
				return advertisements;
			}
			set
			{
				this.advertisements = value;
			}
		}


		public virtual int Views
		{
			get
			{
				return views;
			}
			set
			{
				this.views = value;
			}
		}




		public virtual int IdEvenement
		{
			get
			{
				return idEvenement;
			}
			set
			{
				this.idEvenement = value;
			}
		}


		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				this.title = value;
			}
		}





		public virtual float TicketPrice
		{
			get
			{
				return ticketPrice;
			}
			set
			{
				this.ticketPrice = value;
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


		public virtual bool Status
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


		public virtual string Address
		{
			get
			{
				return address;
			}
			set
			{
				this.address = value;
			}
		}
		public virtual List<Notification> Notifications
		{
			get
			{
				return notifications;
			}
			set
			{
				this.notifications = value;
			}
		}




		public virtual bool EarlyParticipants
		{
			get
			{
				return earlyParticipants;
			}
			set
			{
				this.earlyParticipants = value;
			}
		}










		public virtual int NbrTicketEarlyParticipants
		{
			get
			{
				return nbrTicketEarlyParticipants;
			}
			set
			{
				this.nbrTicketEarlyParticipants = value;
			}
		}


		public virtual DateTime Date
		{
			get
			{
				return date;
			}
			set
			{
				this.date = value;
			}
		}
		public virtual EventCategory Category { get; set; }
		

		public override string ToString()
		{
			return base.ToString();
		}
	}
}


