using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataProvider.Data
{
	public class User
	{
		public int Id
		{
			get;
			set;
		}
		public string FirstName
		{
			get;
			set;
		}
		public string LastName
		{
			get;
			set;
		}
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
		public bool IsActive
		{
			get;
			set;
		}
	}
}

