﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataProvider.SqlDataProvider.Data
{
	public class Team
	{
		public int Id
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
		public string Slogan
		{
			get;
			set;
		}
		public string Description
		{
			get;
			set;
		}
		public string ImageUrl
		{
			get;
			set;
		}
		public DateTime CreatedDate
		{
			get;
			set;
		}

		public DateTime ModifiedDate
		{
			get;
			set;
		}
		public int? CreateById
		{
			get;
			set;
		}
		public int? ModifiedId
		{
			get;
			set;
		}
	}
}
