using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataProvider.SqlDataProvider.Data
{
	public class ConfrontMatchListDetail
	{
		public int Id
		{
			get;
			set;
		}
		public string ConfrontMatchListId
		{
			get;
			set;
		}
		public string ConfrontId
		{
			get;
			set;
		}
		public DateTime ConfrontMatchId
		{
			get;
			set;
		}

		public DateTime CategoryId
		{
			get;
			set;
		}
		public int TeamId
		{
			get;
			set;
		}
		public int UserId
		{
			get;
			set;
		}
		public int RankId
		{
			get;
			set;
		}
		public bool UseLuckyStar
		{
			get;
			set;
		}
	}
}
