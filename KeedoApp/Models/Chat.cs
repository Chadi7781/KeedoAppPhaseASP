using System;
using System.Collections.Generic;
namespace KeedoApp.Models

{
	public class Chat
	{
		public int id { get; set; }

		public string respense { get; set; }

		public ICollection<ChatKeyWord> chatKeyWord { get; set; }

		public int nbRequest { get; set; }
		public int? userFk { get; set; }
		public User user { get; set; }

	}
}
