using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeedoApp.Models
{
	
	public class EmpruntCreation
	{

		private string userId;
		private string bookId;


		public virtual string UserId
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
		}

	}
}
