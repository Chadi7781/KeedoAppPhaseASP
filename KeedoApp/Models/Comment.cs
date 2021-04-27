using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeedoApp.Models
{

	[Serializable]
	public class Comment
	{

		private const long serialVersionUID = 1L;

		private int idComment;
		private string commentContent;
		private string login;
		private DateTime createDate;
		private String modifyDate;
		private Post post;
		private User user;
		private NotificationSNW notificationsnw;

		public Comment() : base()
		{
		}

		public virtual int IdComment
		{
			get
			{
				return idComment;
			}
			set
			{
				this.idComment = value;
			}
		}


		public virtual string CommentContent
		{
			get
			{
				return commentContent;
			}
			set
			{
				this.commentContent = value;
			}
		}
		public virtual string Login
		{
			get
			{
				return login;
			}
			set
			{
				this.login = value;
			}
		}

		public virtual DateTime CreateDate
		{
			get
			{
				return createDate;
			}
			set
			{
				this.createDate = value;
			}
		}


		public virtual String ModifyDate
		{
			get
			{
				return modifyDate;
			}
			set
			{
				this.modifyDate = value;
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
			return "Comment [idComment=" + idComment + ", commentContent=" + commentContent + ", login=" + login + ", createDate=" + createDate + ", modifyDate=" + modifyDate + ", post=" + post + ", user=" + user + ", notificationsnw=" + notificationsnw + "]";
		}





	}
}