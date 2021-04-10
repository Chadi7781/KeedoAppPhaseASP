using System.Collections.Generic;

namespace KeedoApp.Models
{

	public class Retour<T>
	{
		private string stringValue;
		private IList<T> objectValue = new List<T>();

		public Retour() : base()
		{
		}

		public Retour(string stringValue, IList<T> objectValue) : base()
		{
			this.stringValue = stringValue;
			this.objectValue = objectValue;
		}

		public virtual string StringValue
		{
			get
			{
				return stringValue;
			}
			set
			{
				this.stringValue = value;
			}
		}


		public virtual IList<T> ObjectValue
		{
			get
			{
				return objectValue;
			}
			set
			{
				this.objectValue = value;
			}
		}


		public override string ToString()
		{
			return "Retour [stringValue=" + stringValue + ", objectValue=" + objectValue + "]";
		}

	}
}
