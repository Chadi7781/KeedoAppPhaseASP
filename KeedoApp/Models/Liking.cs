using System;
namespace KeedoApp.Models

{




	[Serializable]
	public class Liking
	{


		private const long serialVersionUID = 1L;

		private int idLiking;
		private Post post;
		private User user;
		private DateTime likeDate;
		private NotificationSNW notificationsnw;

		public Liking() : base()
		{
		}



		public virtual int IdLiking
		{
			get
			{
				return idLiking;
			}
			set
			{
				this.idLiking = value;
			}
		}






		public virtual Post Post
		{
			get
			{
				return post;
			}
			set
			{
				this.post = value;
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






		public virtual DateTime LikeDate
		{
			get
			{
				return likeDate;
			}
			set
			{
				this.likeDate = value;
			}
		}






		public virtual NotificationSNW Notificationsnw
		{
			get
			{
				return notificationsnw;
			}
			set
			{
				this.notificationsnw = value;
			}
		}






		public override string ToString()
		{
			return "Liking [idLiking=" + idLiking + ", post=" + post + ", user=" + user + ", likeDate=" + likeDate + ", notificationsnw=" + notificationsnw + "]";
		}


	}
}
