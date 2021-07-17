using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataProvider.SqlDataProvider.Data
{
	public class Confront
	{
		public int Id
		{
			get;
			set;
		}
		public int CategoryId
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
