using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeedoApp.LoginObject
{
    [Serializable]
    public class jwtResponse
    {
		
        public String AccessToken;
        public String username;
        public String role;

		public virtual String Token
		{
			get
			{
				return AccessToken;
			}
			set
			{
				this.AccessToken = value;
			}
		}


		public virtual String Username
		{
			get
			{
				return username;
			}
			set
			{
				this.username = value;
			}
		}

		public virtual String Roles
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
	}
}