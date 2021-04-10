using System;
using System.Collections.Generic;

namespace KeedoApp.Models
{



	[Serializable]
	public class Topic
	{

		private const long serialVersionUID = 1L;

		private int idTopic;
	private string title;
		private DateTime createdDate;
		private User user;
		private ISet<Answer> answers;

		public Topic() : base()
		{
		}

		public virtual int IdTopic
		{
			get
			{
				return idTopic;
			}
			set
			{
				this.idTopic = value;
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


		public virtual DateTime CreatedDate
		{
			get
			{
				return createdDate;
			}
			set
			{
				this.createdDate = value;
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


		public virtual ISet<Answer> Answers
		{
			get
			{
				return answers;
			}
			set
			{
				this.answers = value;
			}
		}


		public override string ToString()
		{
			return "Topic [idTopic=" + idTopic + ", title=" + title + ", createdDate=" + createdDate + ", user=" + user + ", answers=" + answers + "]";
		}

	}
}
