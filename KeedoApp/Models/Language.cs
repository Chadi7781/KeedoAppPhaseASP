namespace KeedoApp.Models
{

	public class Language
	{
		private int id;

		private string lang;

		public Language() : base()
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


		public virtual string Lang
		{
			get
			{
				return lang;
			}
			set
			{
				this.lang = value;
			}
		}


		public override string ToString()
		{
			return "Language [id=" + id + ", lang=" + lang + "]";
		}

	}
}
