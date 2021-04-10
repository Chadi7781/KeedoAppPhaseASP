using KeedoApp.Models;
using System;

namespace tn.esprit.pi.entities
{


	[Serializable]
	public class Message
	{

		private const long serialVersionUID = 1L;

		private int idMessage;


		private string content;
		private sbyte[] image;

		private DateTime date;

		private DateTime time;

	
		private User sender;

		private User receiver;

		public Message() : base()
		{
		}

		public virtual int IdMessage
		{
			get
			{
				return idMessage;
			}
			set
			{
				this.idMessage = value;
			}
		}


		public virtual User Sender
		{
			get
			{
				return sender;
			}
			set
			{
				this.sender = value;
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

		public virtual sbyte[] Image
		{
			get
			{
				return image;
			}
			set
			{
				this.image = value;
			}
		}




		public virtual User Receiver
		{
			get
			{
				return receiver;
			}
			set
			{
				this.receiver = value;
			}
		}


		public virtual DateTime Date
		{
			get
			{
				return date;
			}
			set
			{
				this.date = value;
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



	}
}
