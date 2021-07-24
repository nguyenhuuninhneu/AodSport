using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AodSport.Areas.Administrator.Controllers
{
    interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email
        {
            get;
            set;
        }
        string Phone
        {
            get;
            set;
        }
        string Facebook
        {
            get;
            set;
        }
    }
}