using System;

namespace KeedoApp.Models
{


	[Serializable]
	public class NotificationMsg
	{

		private const long serialVersionUID = 1L;

		private int id;

		private string content;

		private DateTime createdAt;

		private DateTime time;

		private DateTime timeChecked;

		
		private bool isRead;

		private User userSend;


		private User userReceive;

		public NotificationMsg() : base()
		{
			// TODO Auto-generated constructor stub
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


		public virtual string Content
		{
			get
			{
				return content;
			}
			set
			{
				this.content = value;
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


		public virtual DateTime TimeChecked
		{
			get
			{
				return timeChecked;
			}
			set
			{
				this.timeChecked = value;
			}
		}


		public virtual bool Read
		{
			get
			{
				return isRead;
			}
			set
			{
				this.isRead = value;
			}
		}


		public virtual User UserSend
		{
			get
			{
				return userSend;
			}
			set
			{
				this.userSend = value;
			}
		}


		public virtual User UserReceive
		{
			get
			{
				return userReceive;
			}
			set
			{
				this.userReceive = value;
			}
		}


		public override string ToString()
		{
			return "NotificationMsg [id=" + id + ", content=" + content + ", createdAt=" + createdAt + ", time=" + time + ", timeChecked=" + timeChecked + ", isRead=" + isRead + ", userSend=" + userSend + ", userReceive=" + userReceive + "]";
		}

	}
}
