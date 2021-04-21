//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per snippet.


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using tn.esprit.pi.entities;

namespace KeedoApp.Models

{


	[Serializable]
	public class User
	{

		private const long serialVersionUID = 1L;

		public int idUser;
		public string firstName = "";
		public string lastName = "";
		[NotMapped]
		public string Fullname { get { return firstName + " " + lastName; } }

		public string telNum = "";
		public DateTime birthdate;

		public string address;

		private string mail = "";

		private string login = "";

		private string password = "";

		private bool delegatee;

		private sbyte[] logo;

		private bool status;

		private Role role;
		private ISet<Kid> kids;
		private ISet<Post> posts;
		private ISet<Workshop> workshops;
		private ISet<Message> messagesS;
		private ISet<Message> messagesR;
		private ISet<Bus> bus;
		private ISet<Consultation> consultations;
		private ISet<Consultation> doctorConsultations;
		private ISet<Chat> chats;
		private ISet<ChatSuggestion> chatSuggestions;
		private ISet<NotificationMsg> notifSend;
		private ISet<NotificationMsg> notifReceive;

		private ISet<Report> reports;
		internal bool valid;
		private bool accountNonLocked;
		private int failedAttempt;
		private Nullable<DateTime> lockTime;
		private string resettoken;



		private ISet<Claim> claims;

		private ISet<Follow> follower;
		private ISet<Follow> following;

		private Kindergarden kindergarden;

		private bool isBlocked;

		private Nullable<DateTime> blockDate;
		private Nullable<DateTime> unBlockDate;
		private bool isPrivate;


		private float accBalance;

		private IList<Meeting> meetings;

		private IList<Notification> notifciations;
		//
		private ISet<Participation> participations;

		private IList<Donation> donations;

		private IList<Evaluation> evaluations;




		public User() : base()
		{
			// TODO Auto-generated constructor stub
		}

		public virtual int IdUser
		{
			get
			{
				return idUser;
			}
			set
			{
				this.idUser = value;
			}
		}


		public virtual string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				this.firstName = value;
			}
		}


		public virtual string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				this.lastName = value;
			}
		}


		public virtual string TelNum
		{
			get
			{
				return telNum;
			}
			set
			{
				this.telNum = value;
			}
		}


		public virtual DateTime Birthdate
		{
			get
			{
				return birthdate;
			}
			set
			{
				this.birthdate = value;
			}
		}


		public virtual string Address
		{
			get
			{
				return address;
			}
			set
			{
				this.address = value;
			}
		}


		public virtual string Mail
		{
			get
			{
				return mail;
			}
			set
			{
				this.mail = value;
			}
		}


		public virtual string Login
		{
			get
			{
				return login;
			}
			set
			{
				this.login = value;
			}
		}


		public virtual string Password
		{
			get
			{
				return password;
			}
			set
			{
				this.password = value;
			}
		}


		public virtual bool Delegatee
		{
			get
			{
				return delegatee;
			}
			set
			{
				this.delegatee = value;
			}
		}


		public virtual sbyte[] Logo
		{
			get
			{
				return logo;
			}
			set
			{
				this.logo = value;
			}
		}


		public virtual Role Role
		{
			get
			{
				return role;
			}
			set
			{
				this.role = value;
			}
		}


		public virtual ISet<Kid> Kids
		{
			get
			{
				return kids;
			}
			set
			{
				this.kids = value;
			}
		}


		public virtual ISet<Post> Posts
		{
			get
			{
				return posts;
			}
			set
			{
				this.posts = value;
			}
		}


		public virtual ISet<Workshop> Workshops
		{
			get
			{
				return workshops;
			}
			set
			{
				this.workshops = value;
			}
		}



		public virtual ISet<Claim> Claims
		{
			get
			{
				return claims;
			}
			set
			{
				this.claims = value;
			}
		}


		public virtual ISet<Message> MessagesS
		{
			get
			{
				return messagesS;
			}
			set
			{
				this.messagesS = value;
			}
		}


		public virtual ISet<Message> MessagesR
		{
			get
			{
				return messagesR;
			}
			set
			{
				this.messagesR = value;
			}
		}


		public virtual bool Status
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


		public virtual ISet<Bus> Bus
		{
			get
			{
				return bus;
			}
			set
			{
				this.bus = value;
			}
		}


		public virtual ISet<Consultation> Consultations
		{
			get
			{
				return consultations;
			}
			set
			{
				this.consultations = value;
			}
		}


		public virtual ISet<Consultation> DoctorConsultations
		{
			get
			{
				return doctorConsultations;
			}
			set
			{
				this.doctorConsultations = value;
			}
		}


		public virtual ISet<Chat> Chats
		{
			get
			{
				return chats;
			}
			set
			{
				this.chats = value;
			}
		}


		public virtual ISet<ChatSuggestion> ChatSuggestions
		{
			get
			{
				return chatSuggestions;
			}
			set
			{
				chatSuggestions = value;
			}
		}
		public virtual ISet<NotificationMsg> NotifReceive
		{
			get
			{
				return notifReceive;
			}
			set
			{
				this.notifReceive = value;
			}
		}


		public virtual ISet<Report> Reports
		{
			get
			{
				return reports;
			}
			set
			{
				this.reports = value;
			}
		}



		public virtual bool AccountNonLocked
		{
			get
			{
				return accountNonLocked;
			}
			set
			{
				this.accountNonLocked = value;
			}
		}


		public virtual int FailedAttempt
		{
			get
			{
				return failedAttempt;
			}
			set
			{
				this.failedAttempt = value;
			}
		}



		public virtual string Resettoken
		{
			get
			{
				return resettoken;
			}
			set
			{
				this.resettoken = value;
			}
		}


		/// <summary>
		///*** Roua ******* </summary>
		public virtual ISet<Follow> Follower
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


		public virtual ISet<Follow> Following
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


		public virtual Kindergarden Kindergarden
		{
			get
			{
				return kindergarden;
			}
			set
			{
				this.kindergarden = value;
			}
		}


		public virtual bool Blocked
		{
			get
			{
				return isBlocked;
			}
			set
			{
				this.isBlocked = value;
			}
		}


		public virtual bool Private
		{
			get
			{
				return isPrivate;
			}
			set
			{
				this.isPrivate = value;
			}
		}


		public virtual float AccBalance
		{
			get
			{
				return accBalance;
			}
			set
			{
				this.accBalance = value;
			}
		}

		public virtual bool Valid
		{
			get
			{
				return valid;
			}
			set
			{
				this.valid = value;
			}
		}
		public virtual IList<Meeting> Meetings
		{
			get
			{
				return meetings;
			}
			set
			{
				this.meetings = value;
			}
		}


		public virtual IList<Notification> Notifciations
		{
			get
			{
				return notifciations;
			}
			set
			{
				this.notifciations = value;
			}
		}


		public virtual IList<Donation> Donations
		{
			get
			{
				return donations;
			}
			set
			{
				this.donations = value;
			}
		}



		public virtual ISet<Participation> Participations
		{
			get
			{
				return participations;
			}
			set
			{
				this.participations = value;
			}
		}


		public virtual IList<Evaluation> Evaluations
		{
			get
			{
				return evaluations;
			}
			set
			{
				this.evaluations = value;
			}
		}


	}
}