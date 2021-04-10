using System;
using System.Collections.Generic;
namespace KeedoApp.Models
{




	[Serializable]
	public class Book
	{
		private int id;

	
		private string isbn;


		private string titre;

		private string auteurNom;

		private string auteurPrenom;

	
		private string collection;

		private string etiquette;

		private int stockTotal;

		private int stockDisponible;


		// méthodes d'augmentation et de diminution du stock

		public virtual void emprunterBook()
		{
			this.stockDisponible -= 1;
		}

		public virtual void restituerBook()
		{
			this.stockDisponible += 1;
		}



		public Book() : base()
		{
			// TODO Auto-generated constructor stub
		}

		public Book(int id, string isbn, string titre, string auteurNom, string auteurPrenom, string collection, string etiquette, int stockTotal, int stockDisponible, ISet<EmpruntBook> empruntBook) : base()
		{
			this.id = id;
			this.isbn = isbn;
			this.titre = titre;
			this.auteurNom = auteurNom;
			this.auteurPrenom = auteurPrenom;
			this.collection = collection;
			this.etiquette = etiquette;
			this.stockTotal = stockTotal;
			this.stockDisponible = stockDisponible;
			//	this.empruntBook = empruntBook;
		}



		public virtual int Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}


		public virtual string Isbn
		{
			get
			{
				return isbn;
			}
			set
			{
				this.isbn = value;
			}
		}


		public virtual string Titre
		{
			get
			{
				return titre;
			}
			set
			{
				this.titre = value;
			}
		}


		public virtual string AuteurNom
		{
			get
			{
				return auteurNom;
			}
			set
			{
				this.auteurNom = value;
			}
		}


		public virtual string AuteurPrenom
		{
			get
			{
				return auteurPrenom;
			}
			set
			{
				this.auteurPrenom = value;
			}
		}



		public virtual string Collection
		{
			get
			{
				return collection;
			}
			set
			{
				this.collection = value;
			}
		}


		public virtual string Etiquette
		{
			get
			{
				return etiquette;
			}
			set
			{
				this.etiquette = value;
			}
		}


		public virtual int StockTotal
		{
			get
			{
				return stockTotal;
			}
			set
			{
				this.stockTotal = value;
			}
		}


		public virtual int StockDisponible
		{
			get
			{
				return stockDisponible;
			}
			set
			{
				this.stockDisponible = value;
			}
		}



	}
}
