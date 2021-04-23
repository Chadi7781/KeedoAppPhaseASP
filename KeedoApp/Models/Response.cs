using System;

namespace KeedoApp.Models
{



	[Serializable]
	public class Response
	{
		private const long serialVersionUID = 1L;

		private int id;

		private DateTime createdAt;

		private Nullable<DateTime> updatedAt;
		private string responses;

		private Satistfaction satisfactionDegree;

		private int rating;


		private Question question;


		public Response() : base()
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




		public virtual Question Question
		{
			get
			{
				return question;
			}
			set
			{
				this.question = value;
			}
		}

	

		

		public virtual int Rating
		{
			get
			{
				return rating;
			}
			set
			{
				this.rating = value;
			}
		}

		public virtual string Responses
		{
			get
			{
				return responses;
			}
			set
			{
				this.responses = value;
			}
		}

		public virtual Satistfaction SatisfactionDegree
		{
			get
			{
				return satisfactionDegree;
			}
			set
			{
				this.satisfactionDegree = value;
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


		public virtual Nullable<DateTime> UpdatedAt
		{
			get
			{
				return updatedAt;
			}
			set
			{
				this.updatedAt = value;
			}
		}


	}
}
