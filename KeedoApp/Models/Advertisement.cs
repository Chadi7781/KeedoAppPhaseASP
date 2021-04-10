using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeedoApp.Models
{

	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Entity public class Advertisement implements java.io.Serializable
	[Serializable]
	public class Advertisement
	{


		private const long serialVersionUID = 2329896158303253039L;

		private int Id_Conflict;
		private string canal;

		private DateTime beginningDate;
		private DateTime endDate;
		private int targetViews;
		private int views;

		private TypeAd typeAd;
	
		private Event @event;
		public Advertisement() : base()
		{
		}

		public Advertisement(int id, string canal, DateTime beginningDate, DateTime endDate, int targetViews, int views) : base()
		{
			Id_Conflict = id;
			canal = canal;
			this.beginningDate = beginningDate;
			this.endDate = endDate;
			this.targetViews = targetViews;
			this.views = views;
		}

		public Advertisement(string canal, DateTime beginningDate, DateTime endDate, int targetViews, int views) : base()
		{
			canal = canal;
			this.beginningDate = beginningDate;
			this.endDate = endDate;
			this.targetViews = targetViews;
			this.views = views;
		}

		public virtual int Id
		{
			get
			{
				return Id_Conflict;
			}
			set
			{
				Id_Conflict = value;
			}
		}


		public virtual string Canal
		{
			get
			{
				return canal;
			}
			set
			{
				value = value;
			}
		}


		public virtual DateTime BeginningDate
		{
			get
			{
				return beginningDate;
			}
			set
			{
				this.beginningDate = value;
			}
		}


		public virtual DateTime EndDate
		{
			get
			{
				return endDate;
			}
			set
			{
				this.endDate = value;
			}
		}


		public virtual int TargetViews
		{
			get
			{
				return targetViews;
			}
			set
			{
				this.targetViews = value;
			}
		}


		public virtual int Views
		{
			get
			{
				return views;
			}
			set
			{
				this.views = value;
			}
		}




		public virtual Event Event
		{
			get
			{
				return @event;
			}
			set
			{
				this.@event = value;
			}
		}




		public virtual TypeAd TypeAd
		{
			get
			{
				return typeAd;
			}
			set
			{
				this.typeAd = value;
			}
		}


		public override string ToString()
		{
			return "Advertisement [Id=" + Id_Conflict + ", Canal=" + canal + ", beginningDate=" + beginningDate + ", endDate=" + endDate + ", targetViews=" + targetViews + ", views=" + views + "]";
		}




	}
}
