﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AodSport
{
    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }
}