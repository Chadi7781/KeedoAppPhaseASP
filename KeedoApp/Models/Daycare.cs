using KeedoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tn.esprit.pi.entities
{
	public class Daycare
	{

		public int idDaycare { get; set; }

		public double price_M { get; set; }

		public double price_T { get; set; }

		public long periode { get; set; }
		[DataType(DataType.Date)]
		public DateTime dateBegin { get; set; }
		[DataType(DataType.Date)]
		public DateTime dateEnd { get; set; }

		public int capacity { get; set; }

		public int nbInscrit { get; set; }

		public ISet<Kid> kids { get; set; }
	}
}
