using KeedoApp.Models;
using System;
using System.Collections.Generic;

namespace tn.esprit.pi.entities
{


	[Serializable]
	public class Bus
	{


		private const long serialVersionUID = 1L;

			private int idBus;
		private string departure;
	private string destination;
	private DateTime timeDep;
	private DateTime timeA;
		private int capacity;
		private int disponible;



			private User user;
			private Driver driver;
	private ISet<Kid> kids;

		public Bus() : base()
		{
		}

		public virtual int IdBus
		{
			get
			{
				return idBus;
			}
			set
			{
				this.idBus = value;
			}
		}


		public virtual string Departure
		{
			get
			{
				return departure;
			}
			set
			{
				this.departure = value;
			}
		}


		public virtual string Destination
		{
			get
			{
				return destination;
			}
			set
			{
				this.destination = value;
			}
		}


		public virtual DateTime TimeDep
		{
			get
			{
				return timeDep;
			}
			set
			{
				this.timeDep = value;
			}
		}


		public virtual DateTime TimeA
		{
			get
			{
				return timeA;
			}
			set
			{
				this.timeA = value;
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


		public virtual Driver Driver
		{
			get
			{
				return driver;
			}
			set
			{
				this.driver = value;
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







		public override string ToString()
		{
			return "Bus [idBus=" + idBus + ", departure=" + departure + ", destination=" + destination + ", timeDep=" + timeDep + ", timeA=" + timeA + ", capacity=" + capacity + ", disponible=" + disponible + ", user=" + user + ", driver=" + driver + ", kids=" + kids + "]";
		}

		public virtual int Disponible
		{
			get
			{
				return disponible;
			}
			set
			{
				this.disponible = value;
			}
		}


		//methode +1 -1 
		public virtual void desaffectDispo()
		{
			this.disponible -= 1;
		}
		public virtual void affectDispo()
		{
			this.disponible += 1;
		}
	}
}
