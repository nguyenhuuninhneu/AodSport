using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataProvider.SqlDataProvider.Data
{
	public class ConfrontTeam
	{
		public int ConfrontId
		{
			get;
			set;
		}
		public int TeamId
		{
			get;
			set;
		}
		public string Description
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
