using System;
using System.Collections.Generic;

namespace NetTalk.Common.Pager
{
	/// <summary>
	/// hold information about a page
	/// </summary>
	public class NetTalkPagerItem
	{
		private string _url, _label, _index, _number;

		public string Url
		{
			get { return _url; }
			set { _url = value; }
		}
		public string Label
		{
			get { return _label; }
			set { _label = value; }
		}
		public string Index
		{
			get { return _index; }
			set { _index = value; }
		}
		public string Number
		{
			get { return _number; }
			set { _number = value; }
		}
	}

	/// <summary>
	/// Pager item collection
	/// </summary>
	public class NetTalkPagerCollection : List<NetTalkPagerItem>
	{ }
}
