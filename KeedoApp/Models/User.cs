
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using tn.esprit.pi.entities;

namespace KeedoApp.Models

{

	public class User
	{

		public int idUser { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		
		public string FirstNameLastName { get { return firstName + " " + lastName; } }
		
		public string telNum { get; set; }
		[DataType(DataType.Date)]
		public DateTime birthdate { get; set; }

		public string address { get; set; }

		public string mail { get; set; }

		public string login { get; set; }

		public string password { get; set; }

		public bool delegatee { get; set; }

		public sbyte[] logo { get; set; }

		public bool status { get; set; }

		//public Role role { get; set; }
		public ICollection<Kid> kids { get; set; }
		//public ISet<Post> posts { get; set; }
		//public ISet<Workshop> workshops { get; set; }
		public ICollection<Message> messagesS { get; set; }
		public ICollection<Message> messagesR { get; set; }
		//public ISet<Bus> bus { get; set; }
		public ICollection<Consultation> consultations { get; set; }
		public ICollection<Consultation> doctorConsultations { get; set; }

		//public ISet<Chat> chats { get; set; }
		//public ISet<ChatSuggestion> chatSuggestions { get; set; }
		//public ISet<NotificationMsg> notifSend { get; set; }
		//public ISet<NotificationMsg> notifReceive { get; set; }

		//private ISet<Report> reports;
		//internal bool valid;
		//private bool accountNonLocked;
		//private int failedAttempt;
		//private DateTime lockTime;
		//private string resettoken;



		//private ISet<Claim> claims;

		//public ISet<Follow> follower { get; set; }
		//public ISet<Follow> following { get; set; }

		//public Kindergarden kindergarden { get; set; }

		//public bool isBlocked { get; set; }

		//public DateTime blockDate { get; set; }
		//public DateTime unBlockDate { get; set; }
		//public bool isPrivate { get; set; }


		//public float accBalance { get; set; }

		//public IList<Meeting> meetings { get; set; }

		//public IList<Notification> notifciations { get; set; }

		//public ISet<Participation> participations { get; set; }

		//public IList<Donation> donations { get; set; }

		//public IList<Evaluation> evaluations { get; set; }

	}
}