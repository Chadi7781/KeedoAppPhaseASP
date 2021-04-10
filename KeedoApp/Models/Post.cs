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
		private PostMediaType media;
		private DateTime createDate;
		private DateTime modifyDate;
		private int owner;
		private string mediaLink;
		private IList<Comment> comments = new List<Comment>();
		private ISet<Liking> likes = new HashSet<Liking>();
		private ISet<Report> reports;
		private User user;


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


		public virtual DateTime ModifyDate
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


		public virtual int Owner
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



		public virtual string MediaLink
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


		public override string ToString()
		{
			return "Post [idPost=" + idPost + ", postContent=" + postContent + ", media=" + media + ", createDate=" + createDate + ", modifyDate=" + modifyDate + ", owner=" + owner + ", mediaLink=" + mediaLink + ", comments=" + comments + ", likes=" + likes + ", reports=" + reports + ", user=" + user + "]";
		}

	}
}
