using KeedoApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeedoApp.Models
{
	public class Message
	{

		public int idMessage { get; set; }

		public string content { get; set; }
		public System.Drawing.Image image { get; set; }
		[DataType(DataType.Date)]
		public DateTime date { get; set; }
		[DataType(DataType.Time)]
		public DateTime time { get; set; }
		[ForeignKey("User")]
		public int? senderFk { get; set; }
		public User sender { get; set; }
		[ForeignKey("User")]
		public int? receiverFk { get; set; }
		public User receiver { get; set; }

	}
}
