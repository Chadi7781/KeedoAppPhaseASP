using System;

namespace KeedoApp.Models
{



	[Serializable]
	public class Consultation
	{

		private const long serialVersionUID = 1L;

			private int idConsultation;
		private DateTime dateConsultation;
		private DateTime time;
		private User director;

		private User doctor;
	
		private Kid kid;

		public Consultation() : base()
		{
		}

		public Consultation(DateTime dateConsultation, DateTime time) : base()
		{
			this.dateConsultation = dateConsultation;
			this.time = time;
		}

		public Consultation(int idConsultation, DateTime dateConsultation, DateTime time) : base()
		{
			this.idConsultation = idConsultation;
			this.dateConsultation = dateConsultation;
			this.time = time;
		}

		public virtual int IdConsultation
		{
			get
			{
				return idConsultation;
			}
			set
			{
				this.idConsultation = value;
			}
		}


		public virtual DateTime DateConsultation
		{
			get
			{
				return dateConsultation;
			}
			set
			{
				this.dateConsultation = value;
			}
		}


		public virtual DateTime Time
		{
			get
			{
				return time;
			}
			set
			{
				this.time = value;
			}
		}


		public virtual User Director
		{
			get
			{
				return director;
			}
			set
			{
				this.director = value;
			}
		}


		public virtual User Doctor
		{
			get
			{
				return doctor;
			}
			set
			{
				this.doctor = value;
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


		public override string ToString()
		{
			return "Consultation [idConsultation=" + idConsultation + ", dateConsultation=" + dateConsultation + ", time=" + time + ", director=" + director + ", doctor=" + doctor + ", kid=" + kid + "]";
		}

	}
}
