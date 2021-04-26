

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KeedoApp.Models
{



	public class Event
	{


		[JsonProperty("idEvenement")]
		public int IdEvenement { get; set; }

		[JsonProperty("title")]

		public string Title { get; set; }

		[JsonProperty("startDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]

        [JsonProperty("endDate")]

		public DateTime EndDate { get; set; }   
		[JsonProperty("description")]

		public string Description { get; set; }
		[JsonProperty("status")]

		public bool Status { get; set; }
		[JsonProperty("address")]

		public string Address { get; set; }

		[JsonProperty("image")]

		public byte[] Image { get; set; }


		[JsonProperty("ticketPrice")]

		public float TicketPrice { get; set; }

		[JsonProperty("collAmount")]

		public float CollAmount { get; set; }

		[JsonProperty("participantsNbr")]

		public int ParticipantsNbr { get; set; }


		[JsonProperty("placesNbr")]

		public int PlacesNbr { get; set; }


        [JsonProperty("earlyParticipants")]

        public bool EarlyParticipants { get; set; }
        [JsonProperty("nbrTicketEarlyParticipants")]

        public int NbrTicketEarlyParticipants { get; set; }
        [JsonProperty("category")]

        public EventCategory Category { get; set; }
		public int Views { get; set; }

		public List<Participation> Participations { get; set; }



		public Jackpot Jackpot { get; set; }

		public List<Notification> Notifications { get; set; }

        [JsonProperty("discountPercentage")]

        public float DiscountPercentage { get; set; }

		public List<Advertisement> Advertisements { get; set; }


		public IList<Donation> Donation { get; set; }


		public List<Evaluation> Evaluations { get; set; }


		public Kindergarden Kindergarden { get; set; }

        public Event(int idEvenement, string title, DateTime startDate, DateTime endDate, string description, bool status, string address, byte[] image, float ticketPrice, float collAmount, int participantsNbr, int placesNbr, bool earlyParticipants, int nbrTicketEarlyParticipants, EventCategory category, int views, List<Participation> participations, Jackpot jackpot, List<Notification> notifications, float discountPercentage, List<Advertisement> advertisements, IList<Donation> donation, List<Evaluation> evaluations, Kindergarden kindergarden)
        {
            IdEvenement = idEvenement;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            Status = status;
            Address = address;
            Image = image;
            TicketPrice = ticketPrice;
            CollAmount = collAmount;
            ParticipantsNbr = participantsNbr;
            PlacesNbr = placesNbr;
            EarlyParticipants = earlyParticipants;
            NbrTicketEarlyParticipants = nbrTicketEarlyParticipants;
            Category = category;
            Views = views;
            Participations = participations;
            Jackpot = jackpot;
            Notifications = notifications;
            DiscountPercentage = discountPercentage;
            Advertisements = advertisements;
            Donation = donation;
            Evaluations = evaluations;
            Kindergarden = kindergarden;
        }

        public Event(string title, DateTime startDate, DateTime endDate, string description, bool status, string address, byte[] image, float ticketPrice, float collAmount, int participantsNbr, int placesNbr, bool earlyParticipants, int nbrTicketEarlyParticipants, EventCategory category, int views, List<Participation> participations, Jackpot jackpot, List<Notification> notifications, float discountPercentage, List<Advertisement> advertisements, IList<Donation> donation, List<Evaluation> evaluations, Kindergarden kindergarden)
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            Status = status;
            Address = address;
            Image = image;
            TicketPrice = ticketPrice;
            CollAmount = collAmount;
            ParticipantsNbr = participantsNbr;
            PlacesNbr = placesNbr;
            EarlyParticipants = earlyParticipants;
            NbrTicketEarlyParticipants = nbrTicketEarlyParticipants;
            Category = category;
            Views = views;
            Participations = participations;
            Jackpot = jackpot;
            Notifications = notifications;
            DiscountPercentage = discountPercentage;
            Advertisements = advertisements;
            Donation = donation;
            Evaluations = evaluations;
            Kindergarden = kindergarden;
        }

        public Event() : base()
		{
		}





	}
}