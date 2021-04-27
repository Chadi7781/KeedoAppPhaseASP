using System;
using System.Collections.Generic;

namespace KeedoApp.Models
{



	[Serializable]
	public class Post
	{

		private const long serialVersionUID = 1L;

		private int idPost;
		private string postContent;
		private string login;
		private PostMediaType media;
		private DateTime createDate;
		private String modifyDate;
		private String owner;
		private String mediaLink;
		private IList<Comment> comments = new List<Comment>();
		private ISet<Liking> likes = new HashSet<Liking>();
		private ISet<Report> reports;
		private User user;
		private String likenb;
		private String cmtnb;
		public List<Comment> cmts { get; set; }



		public Post() : base()
		{
		}

		public virtual int IdPost
		{
			get
			{
				return idPost;
			}
			set
			{
				this.idPost = value;
			}
		}


		public virtual string PostContent
		{
			get
			{
				return postContent;
			}
			set
			{
				this.postContent = value;
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


		public virtual PostMediaType Media
		{
			get
			{
				return media;
			}
			set
			{
				this.media = value;
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


		public virtual String Owner
		{
			get
			{
				return owner;
			}
			set
			{
				this.owner = value;
			}
		}


		public virtual IList<Comment> Comments
		{
			get
			{
				return comments;
			}
			set
			{
				this.comments = value;
			}
		}


		public virtual ISet<Liking> Likes
		{
			get
			{
				return likes;
			}
			set
			{
				this.likes = value;
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



		public virtual String MediaLink
		{
			get
			{
				return mediaLink;
			}
			set
			{
				this.mediaLink = value;
			}
		}


		public virtual ISet<Report> Reports
		{
			get
			{
				return reports;
			}
			set
			{
				this.reports = value;
			}
		}
		public virtual String Likenb
		{
			get
			{
				return likenb;
			}
			set
			{
				this.likenb = value;
			}
		}
		public virtual String Cmtnb
		{
			get
			{
				return cmtnb;
			}
			set
			{
				this.cmtnb = value;
			}
		}

		public override string ToString()
		{
			return "Post [idPost=" + idPost + ", postContent=" + postContent + ", login=" + login + ", media = " + media + ", createDate=" + createDate + ", modifyDate=" + modifyDate + ", owner=" + owner + ", mediaLink=" + mediaLink + ", comments=" + comments + ", likes=" + likes + ", reports=" + reports + ", user=" + user + ", likenb=" + likenb + ", cmtnb=" + cmtnb + "]";
		}

	}
}