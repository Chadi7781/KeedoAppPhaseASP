using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeedoApp.Models
{

	public class EmpruntCreation
	{

		//public string userId;
		//	public string bookId;
		public int? bookId { get; set; }
		public Book book { get; set; }

		public int? userId { get; set; }
		public User user { get; set; }

		/*public virtual string UserId
		{
			get
			{
				return userId;
			}
			set
			{
				this.userId = value;
			}
		}
		public virtual string BookId
		{
			get
			{
				return bookId;
			}
			set
			{
				this.bookId = value;
			}
		}*/

	}
}
