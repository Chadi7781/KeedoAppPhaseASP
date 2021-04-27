using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/*
namespace KeedoApp.Models
{
	public class Driver
	{

		public int idDriver { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public int telNum { get; set; }
		public string address { get; set; }
	}
}*/



namespace KeedoApp.Models
{



	[Serializable]
	public class Driver
	{

		private const long serialVersionUID = 1L;

		private int idDriver;
		[Required(ErrorMessage = "Required Field")]
		[StringLength(25, ErrorMessage = "length does not exceed 25")]
		private string firstName;
		[Required(ErrorMessage = "Required Field")]
		[StringLength(25, ErrorMessage = "length does not exceed 25")]
		private string lastName;
		[Required(ErrorMessage = "Required Field")]
		[MaxLength(8)]
		[MinLength(8)]
		private int telNum;
		[Required(ErrorMessage = "Required Field")]
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
		//public virtual ICollection<Bus> Bus { get; set; }

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
