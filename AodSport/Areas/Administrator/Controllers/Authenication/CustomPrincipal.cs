using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AodSport.Areas.Administrator.Controllers
{
    public class CustomPrincipal : ICustomPrincipal
    {

        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        { 
            return false;
        }

        public CustomPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }
        public string Facebook
        {
            get;
            set;
        }
    }
}