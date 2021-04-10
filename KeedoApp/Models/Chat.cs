using System;
using System.Collections.Generic;
namespace KeedoApp.Models

{


	[Serializable]
	public class Chat
	{

		private const long serialVersionUID = 1L;
	private int id;

		private string respense;

			private IList<ChatKeyWord> chatKeyWord;

			private int nbRequest;

		private User user;

		public Chat() : base()
		{
		}

		public Chat(int id, string respense, IList<ChatKeyWord> chatKeyWord)
		{
			this.id = id;
			this.respense = respense;
			this.chatKeyWord = chatKeyWord;
		}

		public Chat(int id, string respense) : base()
		{
			this.id = id;
			this.respense = respense;
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


		public virtual string Respense
		{
			get
			{
				return respense;
			}
			set
			{
				this.respense = value;
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


		public virtual IList<ChatKeyWord> ChatKeyWord
		{
			get
			{
				return chatKeyWord;
			}
			set
			{
				this.chatKeyWord = value;
			}
		}


		public virtual int NbRequest
		{
			get
			{
				return nbRequest;
			}
			set
			{
				this.nbRequest = value;
			}
		}


		public override string ToString()
		{
			return "Chat [id=" + id + ", respense=" + respense + ", chatKeyWord=" + chatKeyWord + ", nbRequest=" + nbRequest + ", user=" + user + "]";
		}

	}
}
