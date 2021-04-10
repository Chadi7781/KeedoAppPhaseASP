using System;

namespace KeedoApp.Models
{

	[Serializable]
	public class Workshop
	{

		private const long serialVersionUID = 1L;

		private int idWorkshop;
		private string content;
		private string pdffile;
		private DateTime createDate;
		private DateTime modifyDate;
		private WorkshopCategory category;
		private User user;

		public Workshop() : base()
		{
		}

		public virtual int IdWorkshop
		{
			get
			{
				return idWorkshop;
			}
			set
			{
				this.idWorkshop = value;
			}
		}


		public virtual string Content
		{
			get
			{
				return content;
			}
			set
			{
				this.content = value;
			}
		}


		public virtual string Pdffile
		{
			get
			{
				return pdffile;
			}
			set
			{
				this.pdffile = value;
			}
		}


		public virtual DateTime CreateDate
		{
			get
			{
				return createDate;
			}
			set
			{
				this.createDate = value;
			}
		}


		public virtual DateTime ModifyDate
		{
			get
			{
				return modifyDate;
			}
			set
			{
				this.modifyDate = value;
			}
		}


		public virtual WorkshopCategory Category
		{
			get
			{
				return category;
			}
			set
			{
				this.category = value;
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


		public override string ToString()
		{
			return "Workshop [idWorkshop=" + idWorkshop + ", content=" + content + ", pdffile=" + pdffile + ", createDate=" + createDate + ", modifyDate=" + modifyDate + ", category=" + category + ", user=" + user + "]";
		}

	}
}
