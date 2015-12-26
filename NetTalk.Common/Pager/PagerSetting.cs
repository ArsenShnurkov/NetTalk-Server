using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace NetTalk.Common.Pager
{
	public class NetTalkPagerSetting
	{
		private bool _show_f_l, _show_n_p, _show_n_p_s;
		private string _template_item, _template_c_page;
		private string _st_next, _st_prev, _st_first, _st_last, _st_next_s, _st_prev_s;
		private int _total, _c_page, _size;

		public bool ShowFirstLast
		{
			get { return _show_f_l; }
			set { _show_f_l = value; }
		}
		public bool ShowNextPrev
		{
			get { return _show_n_p; }
			set { _show_n_p = value; }
		}
		public bool ShowNextPrevSection
		{
			get { return _show_n_p_s; }
			set { _show_n_p_s = value; }
		}

		public string ItemTemplate
		{
			get { return _template_item; }
			set { _template_item = value; }
		}
		public string CurrentPageTemplate
		{
			get { return _template_c_page; }
			set { _template_c_page = value; }
		}

		public string Next
		{
			get { return _st_next; }
			set { _st_next = value; }
		}
		public string Prev
		{
			get { return _st_prev; }
			set { _st_prev = value; }
		}

		public string First
		{
			get { return _st_first; }
			set { _st_first = value; }
		}
		public string Last
		{
			get { return _st_last; }
			set { _st_last = value; }
		}

		public string NextSection
		{
			get { return _st_next_s; }
			set { _st_next_s = value; }
		}
		public string PrevSection
		{
			get { return _st_prev_s; }
			set { _st_prev_s = value; }
		}

		public int PageCount
		{
			get { return _total; }
			set { _total = value; }
		}
		public int CurrentPage
		{
			get { return _c_page; }
			set { _c_page = value; }
		}
        /// <summary>
        /// Size of items in pager collection
        /// </summary>
		public int Size
		{
			get { return _size; }
			set { _size = value; }
		}

        public NetTalkPagerSetting(int TotalPages, int CurrentPage, int Size)
		{
			this.Size = Size;
			this.PageCount = TotalPages;
			this.CurrentPage = CurrentPage;
			ShowFirstLast = true;
			ShowNextPrev = true;
			ShowNextPrevSection = true;
			CurrentPageTemplate = "<span>@label</span>";
			Next = "&gt;";
			Prev = "&lt;";
			NextSection = "...";
			PrevSection = "...";
			First = "&lt;&lt;";
			Last = "&gt;&gt;";
			ItemTemplate = "<span title=\"@number\">@label</span>";
		}

		public string Format(string label, string number, string index)
		{
			return ItemTemplate
				.Replace("@label", label).Replace("@number", number).Replace("@index", index);
		}
	}
}
