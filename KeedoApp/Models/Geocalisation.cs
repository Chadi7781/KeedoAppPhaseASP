using System;

namespace KeedoApp.Models
{


	[Serializable]
	public class Geolocalisation { 

		private int id;

		private Kid kid;


		private double longitude;

		private double latitude;

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




		public virtual Kid Kid
		{
			get
			{
				return kid;
			}
			set
			{
				this.kid = value;
			}
		}


		public virtual double Longitude
		{
			get
			{
				return longitude;
			}
			set
			{
				this.longitude = value;
			}
		}


		public virtual double Latitude
		{
			get
			{
				return latitude;
			}
			set
			{
				this.latitude = value;
			}
		}




	}
}
