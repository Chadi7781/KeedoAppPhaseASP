using KeedoApp.Models;
using System;

namespace tn.esprit.pi.entities
{



	[Serializable]
	public class FollowRequest
	{

		private const long serialVersionUID = 1L;

		private int idFollowRequest;



		private User following;

		private User follower;




		public FollowRequest() : base()
		{
		}



		public virtual int IdFollowRequest
		{
			get
			{
				return idFollowRequest;
			}
			set
			{
				this.idFollowRequest = value;
			}
		}






		public virtual User Following
		{
			get
			{
				return following;
			}
			set
			{
				this.following = value;
			}
		}


		public virtual User Follower
		{
			get
			{
				return follower;
			}
			set
			{
				this.follower = value;
			}
		}







		public override string ToString()
		{
			return "FollowRequest [idFollowRequest=" + idFollowRequest + ", follower=" + follower + "]";
		}







	}
}
