using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeedoApp.Models
{

[Serializable]
		public class Evaluation
		{
			private int idEvalution;

			private int rate;


			private User user;

			private Event eventt;


			public Evaluation()
			{

			}


			public Evaluation(int idEvalution, int rate, User user, Event eventt) : base()
			{
				this.idEvalution = idEvalution;
				this.rate = rate;
				this.user = user;
				this.eventt = eventt;
			}


			public virtual int IdEvalution
			{
				get
				{
					return idEvalution;
				}
				set
				{
					this.idEvalution = value;
				}
			}








			public virtual int Rate
			{
				get
				{
					return rate;
				}
				set
				{
					this.rate = value;
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




			public virtual Event Eventt
			{
				get
				{
					return eventt;
				}
				set
				{
					this.eventt = value;
				}
			}







		}
	}

