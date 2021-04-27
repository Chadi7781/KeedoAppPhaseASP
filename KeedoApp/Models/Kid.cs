using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tn.esprit.pi.entities;

namespace KeedoApp.Models
{

	public class Kid
	{

		public int idKid { get; set; }
		public string firstName { get; set; }

		public string lastName { get; set; }
		public string FirstNameLastName { get { return firstName + " " + lastName; } }
		[DataType(DataType.Date)]
		public DateTime birthDate { get; set; }

		public string gender { get; set; }

		public string address { get; set; }

		public string affect { get; set; }

		public int? DaycareFk { get; set; }
		public Daycare Daycare { get; set; }
		public ICollection<Consultation> consultations { get; set; }
		public int? userFk { get; set; }
		public virtual User user { get; set; }

		//public Daycare daycare { get; set; }



		//public Bus bus { get; set; }

	}
}
