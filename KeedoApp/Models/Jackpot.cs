using System;

namespace KeedoApp.Models
{


	[Serializable]
	public class Jackpot
	{

		/// 
		private const long serialVersionUID = 1L;

		private int id;
		private float sum;

		public Jackpot() : base()
		{
			// TODO Auto-generated constructor stub
		}

		public Jackpot(int id, float sum) : base()
		{
			this.id = id;
			this.sum = sum;
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


		public virtual float Sum
		{
			get
			{
				return sum;
			}
			set
			{
				this.sum = value;
			}
		}






		public override int GetHashCode()
		{
			const int prime = 31;
			int result = 1;
			result = prime * result + id;
			return result;
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (obj == null)
			{
				return false;
			}
			if (this.GetType() != obj.GetType())
			{
				return false;
			}
			Jackpot other = (Jackpot)obj;
			if (id != other.id)
			{
				return false;
			}
		
			return true;
		}

		public override string ToString()
		{
			return "Jackpot [id=" + id + ", sum=" + sum + "]";
		}






	}
}
