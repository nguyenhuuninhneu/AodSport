using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataProvider.SqlDataProvider.Data
{
	public class ConfrontMatch
	{
		public int Id
		{
			get;
			set;
		}
		public string ConfrontId
		{
			get;
			set;
		}
		public string RankId
		{
			get;
			set;
		}
		public DateTime MatchDate
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
