using System;

namespace KeedoApp.Models
{


	public class UnhealthyWord
	{

		private int id;

		private string word;

		public UnhealthyWord() : base()
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


		public override string ToString()
		{
			return "UnhealthyWord [id=" + id + ", word=" + word + "]";
		}

	}
}
