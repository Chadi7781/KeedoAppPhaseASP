using System;
using System.Collections.Generic;

namespace tn.esprit.pi.entities
{



	[Serializable]
	public class Driver
	{

		private const long serialVersionUID = 1L;

		private int idDriver;
		private string firstName;
		private string lastName;
		private int telNum;
		private string address;
		private ISet<Bus> bus;

		public Driver() : base()
		{
		}

		public virtual int IdDriver
		{
			get
			{
				return idDriver;
			}
			set
			{
				this.idDriver = value;
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


		public virtual int TelNum
		{
			get
			{
				return telNum;
			}
			set
			{
				this.telNum = value;
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


		public virtual ISet<Bus> Bus
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
			return "Driver [idDriver=" + idDriver + ", firstName=" + firstName + ", lastName=" + lastName + ", telNum=" + telNum + ", address=" + address + ", bus=" + bus + "]";
		}

	}
}
