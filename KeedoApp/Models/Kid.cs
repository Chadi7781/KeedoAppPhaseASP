using System;
using System.Collections.Generic;
using tn.esprit.pi.entities;

namespace KeedoApp.Models
{



	[Serializable]
	public class Kid
	{

		private const long serialVersionUID = 1L;

		private int idKid;

		private string firstName;

		private string lastName;

		private DateTime birthDate;

		private string gender;

		private string address;

		private User user;

		private Daycare daycare;

		private ISet<Consultation> consultations;

		private Bus bus;

		public Kid() : base()
		{
		}

		public Kid(int idKid, string firstName, string lastName, DateTime birthDate, string gender, string address) : base()
		{
			this.idKid = idKid;
			this.firstName = firstName;
			this.lastName = lastName;
			this.birthDate = birthDate;
			this.gender = gender;
			this.address = address;
		}

		public virtual int IdKid
		{
			get
			{
				return idKid;
			}
			set
			{
				this.idKid = value;
			}
		}


		public virtual string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				this.firstName = value;
			}
		}


		public virtual string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				this.lastName = value;
			}
		}


		public virtual DateTime BirthDate
		{
			get
			{
				return birthDate;
			}
			set
			{
				this.birthDate = value;
			}
		}


		public virtual string Gender
		{
			get
			{
				return gender;
			}
			set
			{
				this.gender = value;
			}
		}


		public virtual string Address
		{
			get
			{
				return address;
			}
			set
			{
				this.address = value;
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


		public virtual Daycare Daycare
		{
			get
			{
				return daycare;
			}
			set
			{
				this.daycare = value;
			}
		}

		public virtual ISet<Consultation> Consultations
		{
			get
			{
				return consultations;
			}
			set
			{
				this.consultations = value;
			}
		}



		public virtual Bus Bus
		{
			get
			{
				return bus;
			}
			set
			{
				this.bus = value;
			}
		}


		public override string ToString()
		{
			return "Kid [idKid=" + idKid + ", firstName=" + firstName + ", lastName=" + lastName + ", birthDate=" + birthDate + ", gender=" + gender + ", address=" + address + ", user=" + user + ", daycare=" + daycare + ", consultations=" + consultations + ", bus=" + bus + "]";
		}

	}
}
