using System;

namespace KeedoApp.Models
{


	
	[Serializable]
	public class Answer
	{

		private const long serialVersionUID = 1L;

		private int idAnswer;
		private string content;

		private DateTime createdDate;
		
		private User user;
	
		private Topic topic;

		public Answer() : base()
		{
		}

		public virtual int IdAnswer
		{
			get
			{
				return idAnswer;
			}
			set
			{
				this.idAnswer = value;
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


		public virtual Topic Topic
		{
			get
			{
				return topic;
			}
			set
			{
				this.topic = value;
			}
		}


		public override string ToString()
		{
			return "Answer [idAnswer=" + idAnswer + ", content=" + content + ", createdDate=" + createdDate + ", user=" + user + ", topic=" + topic + "]";
		}

	}
}
