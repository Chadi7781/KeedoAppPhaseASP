using System;

namespace KeedoApp.Models
{

	[Serializable]
	public class Report
	{
		//private ReportPK reportPK;

		private DateTime reportDate;
		private User user;
		private Post post;


		public Report() : base()
		{
		}






		public virtual DateTime ReportDate
		{
			get
			{
				return reportDate;
			}
			set
			{
				this.reportDate = value;
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
		public virtual Post Post
		{
			get
			{
				return post;
			}
			set
			{
				this.post = value;
			}
		}




	}
}
