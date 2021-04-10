using KeedoApp.Models;
using System;
using System.Collections.Generic;

namespace tn.esprit.pi.entities
{


	[Serializable]
	public class Daycare
	{

		private const long serialVersionUID = 1L;

		private int idDaycare;

		private double? price_M;

		private double? price_T;

		private long periode;

		private DateTime dateBegin;

		private DateTime dateEnd;

		private int capacity;

		private int nbInscrit;

		private ISet<Kid> kids;

		public Daycare() : base()
		{
		}

		public virtual int IdDaycare
		{
			get
			{
				return idDaycare;
			}
			set
			{
				this.idDaycare = value;
			}
		}


		public virtual double? Price_M
		{
			get
			{
				return price_M;
			}
			set
			{
				this.price_M = value;
			}
		}


		public virtual double? Price_T
		{
			get
			{
				return price_T;
			}
			set
			{
				this.price_T = value;
			}
		}


		public virtual long Periode
		{
			get
			{
				return periode;
			}
			set
			{
				this.periode = value;
			}
		}


		public virtual DateTime DateBegin
		{
			get
			{
				return dateBegin;
			}
			set
			{
				this.dateBegin = value;
			}
		}


		public virtual DateTime DateEnd
		{
			get
			{
				return dateEnd;
			}
			set
			{
				this.dateEnd = value;
			}
		}


		public virtual int Capacity
		{
			get
			{
				return capacity;
			}
			set
			{
				this.capacity = value;
			}
		}


		public virtual ISet<Kid> Kids
		{
			get
			{
				return kids;
			}
			set
			{
				this.kids = value;
			}
		}


		public virtual int NbInscrit
		{
			get
			{
				return nbInscrit;
			}
			set
			{
				this.nbInscrit = value;
			}
		}


		public override string ToString()
		{
			return "Daycare [idDaycare=" + idDaycare + ", price_M=" + price_M + ", price_T=" + price_T + ", periode=" + periode + ", dateBegin=" + dateBegin + ", dateEnd=" + dateEnd + ", capacity=" + capacity + ", nbInscrit=" + nbInscrit + ", kids=" + kids + "]";
		}

	}
}
