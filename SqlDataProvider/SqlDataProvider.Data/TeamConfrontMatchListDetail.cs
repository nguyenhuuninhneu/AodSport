using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataProvider.SqlDataProvider.Data
{
	public class TeamConfrontMatchListDetail
	{
		public int Id
		{
			get;
			set;
		}
		public int ConfrontId
		{
			get;
			set;
		}
		public int ConfrontMatchId
		{
			get;
			set;
		}
		public int ConfrontMatchListId
		{
			get;
			set;
		}

		public int ConfrontMatchListDetailId
		{
			get;
			set;
		}
		public int TeamId
		{
			get;
			set;
		}
		public int Score
		{
			get;
			set;
		}
		public int Point
		{
			get;
			set;
		}
		public bool IsWinner
		{
			get;
			set;
		}
	}
}
