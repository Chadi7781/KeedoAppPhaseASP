using System;

namespace KeedoApp.Models
{



	[Serializable]
	public class Follow
	{

		private const long serialVersionUID = 1L;

		private int idFollow;



		private User following;

		private User follower;
		public Follow() : base()
		{
		}

		public virtual int IdFollow
		{
			get
			{
				return idFollow;
			}
			set
			{
				this.idFollow = value;
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













	}
}
