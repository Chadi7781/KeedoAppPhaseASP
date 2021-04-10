using System;

namespace KeedoApp.Models
{


	[Serializable]
	public class ChatKeyWord
	{

		private const long serialVersionUID = 1L;

		private int id;

		private string word;

		private Chat chat;

		public ChatKeyWord() : base()
		{
		}

		public ChatKeyWord(int id, string word) : base()
		{
			this.id = id;
			this.word = word;
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


		public virtual string Word
		{
			get
			{
				return word;
			}
			set
			{
				this.word = value;
			}
		}


		public virtual Chat Chat
		{
			get
			{
				return chat;
			}
			set
			{
				this.chat = value;
			}
		}


		public override string ToString()
		{
			return "ChatKeyWord [id=" + id + ", word=" + word + ", chat=" + chat + "]";
		}

	}
}
