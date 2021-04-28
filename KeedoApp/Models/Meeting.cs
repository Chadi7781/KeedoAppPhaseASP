

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeedoApp.Models

{

	[Serializable]
	public class Meeting
	{
		private const long serialVersionUID = 1L;

		private int idMeeting;

		private DateTime startDate;
		private DateTime endDate;
		private string subject;
		private bool isFullDay;
		private string themeColor;

		[DataType(DataType.Time)]


		private DateTime ?createdAt;

		private DateTime ?canceledAt;


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



		[JsonProperty("idMeeting")]

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



		[JsonProperty("allDay")]

		public virtual bool IsFullDay
		{
			get
			{
				return isFullDay;
			}
			set
			{
				this.isFullDay = value;
			}
		}

		[JsonProperty("color")]

		public virtual string ThemeColor
		{
			get
			{
				return themeColor;
			}
			set
			{
				this.themeColor = value;
			}
		}
		[JsonProperty("startDate")]

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

		[JsonProperty("endDate")]


		public virtual DateTime EndDate
		{
			get
			{
				return endDate;
			}
			set
			{
				this.endDate = value;
			}
		}
		[JsonProperty("subject")]

		public virtual string Subject
		{
			get
			{
				return subject;
			}
			set
			{
				this.subject = value;
			}
		}
	



		[JsonProperty("canceledAt")]

		

		[Column(TypeName = "datetime2")]
		public DateTime? CanceledAt { get; set; }

		[JsonProperty("canceler")]

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


		[JsonProperty("typeMeeting")]


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


	

		[JsonProperty("createdAt")]



		[Column(TypeName = "datetime2")]
		public DateTime? CreatedAt { get; set; }




	}
}

