using System;

namespace KeedoApp.Models
{


	[Serializable]
	public class ChatSuggestion
	{

		private const long serialVersionUID = 1L;
private int id;
		
		private string content;

		
		private User user;

		public ChatSuggestion() : base()
		{
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


		public override string ToString()
		{
			return "ChatSuggestion [id=" + id + ", content=" + content + ", user=" + user + "]";
		}

	}
}
