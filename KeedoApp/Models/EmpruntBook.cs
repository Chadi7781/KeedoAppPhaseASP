using System;
using KeedoApp.Models;
namespace KeedoApp.Models

{

	[Serializable]
	public class EmpruntBook
	{
		private int idEmprunt;

		private User user;

		private Book book;

		private DateTime debutDate;

		private DateTime finDate;
		private bool isProlonge = false;
		private bool isRendu = false;
		private string detail;



		public EmpruntBook() : base()
		{
			// TODO Auto-generated constructor stub
		}



		public EmpruntBook(int idEmprunt, User user, Book book, DateTime debutDate, DateTime finDate, bool isProlonge, bool isRendu) : base()
		{
			this.idEmprunt = idEmprunt;
			this.user = user;
			this.book = book;
			this.debutDate = debutDate;
			this.finDate = finDate;
			this.isProlonge = false;
			this.isRendu = false;
		}



		/*public EmpruntPK getEmpruntPK() {
			return empruntPK;
		}
	
		public void setEmpruntPK(EmpruntPK empruntPK) {
			this.empruntPK = empruntPK;
		}
	*/
		public virtual int IdEmprunt
		{
			get
			{
				return idEmprunt;
			}
			set
			{
				this.idEmprunt = value;
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


		public virtual Book Book
		{
			get
			{
				return book;
			}
			set
			{
				this.book = value;
			}
		}


		public virtual DateTime DebutDate
		{
			get
			{
				return debutDate;
			}
			set
			{
				this.debutDate = value;
			}
		}


		public virtual DateTime FinDate
		{
			get
			{
				return finDate;
			}
			set
			{
				this.finDate = value;
			}
		}


		public virtual bool Prolonge
		{
			get
			{
				return isProlonge;
			}
			set
			{
				this.isProlonge = value;
			}
		}


		public virtual bool Rendu
		{
			get
			{
				return isRendu;
			}
			set
			{
				this.isRendu = value;
			}
		}




		public virtual string Detail
		{
			get
			{
				return detail;
			}
			set
			{
				this.detail = value;
			}
		}











	}

}
