using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Windows.Documents;

namespace KeedoApp.Models
{

	public class Consultation
	{
		public int idConsultation { get; set; }
		[DataType(DataType.Date)]
		public DateTime dateConsultation { get; set; }
		[DataType(DataType.Time)]
		public DateTime time { get; set; }
	
		public int? directorFk { get; set; }
		public User director { get; set; }
		
		public int? doctorFk { get; set; }
		public User doctor { get; set; }
	
		public int? kidFk { get; set; }
		public Kid kid { get; set; }

	}
}
