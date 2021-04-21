using System;
using System.Collections.Generic;

namespace KeedoApp.Models
{




	[Serializable]
	public class Feedback
	{

		private const long serialVersionUID = 1L;

		private int idFeedback;


		private string title;

		private string description;

		private DateTime createdAt;

		private Nullable<DateTime> updatedAt;



		private ISet<Question> questions;
		public int? meetingFk { get; set; }

		private Meeting meeting;

		public Feedback() : base()
		{
		}

		public virtual int IdFeedback
		{
			get
			{
				return idFeedback;
			}
			set
			{
				this.idFeedback = value;
			}
		}



		public virtual ISet<Question> Questions
		{
			get
			{
				return questions;
			}
			set
			{
				this.questions = value;
			}
		}


		public virtual Meeting Meeting
		{
			get
			{
				return meeting;
			}
			set
			{
				this.meeting = value;
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

		public virtual string Description
		{
			get
			{
				return description;
			}
			set
			{
				this.description = value;
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







		public override string ToString()
		{
			return "Feedback [idFeedback=" + idFeedback + ", title=" + title + ", createdAt=" + createdAt + ", updatedAt=" + updatedAt + ", questions=" + questions + "]";
		}





	}
}
