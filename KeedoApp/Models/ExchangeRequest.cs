using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeedoApp.Models
{

	

		[Serializable]
		public class ExchangeRequest
		{

			/// 
			private const long serialVersionUID = 1L;
			private int id;
			private ExchangeStatus status;

			private Meeting requestor;

			private Meeting requested;


			public ExchangeRequest()
			{

			}

			public ExchangeRequest(Meeting requestor, Meeting requested, ExchangeStatus status)
			{
				this.status = status;
				this.requestor = requestor;
				this.requested = requested;
			}

			public virtual ExchangeStatus Status
			{
				get
				{
					return status;
				}
				set
				{
					this.status = value;
				}
			}


			public virtual Meeting Requestor
			{
				get
				{
					return requestor;
				}
				set
				{
					this.requestor = value;
				}
			}


			public virtual Meeting Requested
			{
				get
				{
					return requested;
				}
				set
				{
					this.requested = value;
				}
			}

		}
	}
