using KeedoApp.Models;
using System;

namespace KeedoApp.Models
{


	[Serializable]
	public class Notification
	{

		private const long serialVersionUID = 1L;

		private int idNotif;
		private string subject;
		private string description;
		private DateTime date;
		private DateTime time;

		private string status;


		private string target;

	
		private User user;

		private Event eventt;

		public Notification() : base()
		{
		}




		public virtual int IdNotif
		{
			get
			{
				return idNotif;
			}
			set
			{
				this.idNotif = value;
			}
		}


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


		public virtual string Status
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





		public virtual string Target
		{
			get
			{
				return target;
			}
			set
			{
				this.target = value;
			}
		}







		/*
			@Override
			public String toString() {
				return "Notification [idNotif=" + idNotif + ", subject=" + subject + ", description=" + description + ", date="
						+ date + ", time=" + time + ", status=" + status + ", user=" + user + ", event=" + event + "]";
			}

		*/
	}
}
