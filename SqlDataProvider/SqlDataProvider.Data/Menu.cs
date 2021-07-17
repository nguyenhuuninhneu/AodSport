using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataProvider.SqlDataProvider.Data
{
	public class Menu
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
		public int ParentId
		{
			get;
			set;
		}
		public int Ordering
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}
		public int? CreateById
		{
			get;
			set;
		}
		public int IsActive
		{
			get;
			set;
		}
	}
}
