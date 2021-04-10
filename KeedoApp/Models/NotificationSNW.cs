using KeedoApp.Models;
using System;

namespace KeedoApp.Models
{


	[Serializable]
	public class NotificationSNW
	{

		private const long serialVersionUID = 1L;

			private int idNotificationsnw;
		private string subject;
		private DateTime date;
		private int sender;
		private int receiver;
		private Comment comment;
		private Liking liking;

		public NotificationSNW() : base()
		{
		}


		public virtual int IdNotificationsnw
		{
			get
			{
				return idNotificationsnw;
			}
			set
			{
				this.idNotificationsnw = value;
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


		public virtual Comment Comment
		{
			get
			{
				return comment;
			}
			set
			{
				this.comment = value;
			}
		}



		public virtual int Sender
		{
			get
			{
				return sender;
			}
			set
			{
				this.sender = value;
			}
		}


		public virtual int Receiver
		{
			get
			{
				return receiver;
			}
			set
			{
				this.receiver = value;
			}
		}


		public virtual Liking Liking
		{
			get
			{
				return liking;
			}
			set
			{
				this.liking = value;
			}
		}



		public override string ToString()
		{
			return "NotificationSNW [idNotificationsnw=" + idNotificationsnw + ", subject=" + subject + ", date=" + date + ", sender=" + sender + ", receiver=" + receiver + ", comment=" + comment + ", liking=" + liking + "]";
		}








	}
}
