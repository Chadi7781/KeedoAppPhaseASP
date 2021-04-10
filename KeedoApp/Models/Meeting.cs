

using System;
using System.Collections.Generic;
namespace KeedoApp.Models

{

	[Serializable]
	public class Meeting
	{
		private const long serialVersionUID = 1L;

		private int idMeeting;

		private DateTime startDate;


		private DateTime time;

		private DateTime createdAt;

		private DateTime canceledAt;


		private User canceler;
		private ExchangeRequest exchangeRequest;

		private AppointmentStatus status;

		private string typeMeeting;
		private string description;





		private ISet<Feedback> feedbacks;

		private Kindergarden kindergarden;
		private User users;


		public Meeting() : base()
		{
		}

		

		
		public virtual int IdMeeting
		{
			get
			{
				return idMeeting;
			}
			set
			{
				this.idMeeting = value;
			}
		}




		public virtual DateTime StartDate
		{
			get
			{
				return startDate;
			}
			set
			{
				this.startDate = value;
			}
		}




		public virtual DateTime Time
		{
			get
			{
				return time;
			}
			set
			{
				this.time = value;
			}
		}




		public virtual DateTime CanceledAt
		{
			get
			{
				return canceledAt;
			}
			set
			{
				this.canceledAt = value;
			}
		}




		public virtual User Canceler
		{
			get
			{
				return canceler;
			}
			set
			{
				this.canceler = value;
			}
		}




		public virtual AppointmentStatus Status
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




		public virtual string TypeMeeting
		{
			get
			{
				return typeMeeting;
			}
			set
			{
				this.typeMeeting = value;
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




		public virtual ISet<Feedback> Feedbacks
		{
			get
			{
				return feedbacks;
			}
			set
			{
				this.feedbacks = value;
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




		public virtual User Users
		{
			get
			{
				return users;
			}
			set
			{
				this.users = value;
			}
		}




		public static long Serialversionuid
		{
			get
			{
				return serialVersionUID;
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

		public override string ToString()
		{
			return "Meeting [idMeeting=" + idMeeting + ", startDate=" + startDate + ", time=" + time + ", createdAt=" + createdAt + ", canceledAt=" + canceledAt + ", canceler=" + canceler + ", exchangeRequest=" + exchangeRequest + ", status=" + status + ", typeMeeting=" + typeMeeting + ", description=" + description + ", feedbacks=" + feedbacks + ", kindergarden=" + kindergarden + ", users=" + users + "]";
		}





	}
}

