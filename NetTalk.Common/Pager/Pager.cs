using System;
using System.Collections.Generic;

namespace NetTalk.Common.Pager
{
	public class NetTalkPager
	{
        private static string[] numarr = { "٠", "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" };

        public static string PersianNumber(string num)
        {
            string res = "";
            foreach (char ch in num.ToCharArray())
            {
                res += numarr[Convert.ToInt32(ch + "")];
            }
            return res;
        }
        public static int CalculatePageCount(int TotalItem, int PageSize)
        {
            if (PageSize != 0)
                return Convert.ToInt32(Math.Ceiling((float)TotalItem / (float)PageSize));
            else
                return 0;
        }

		private NetTalkPagerSetting _setting;

		/// <summary>
		/// Setting of pager
		/// </summary>
		public NetTalkPagerSetting Setting
		{
			get { return _setting; }
			set { _setting = value; }
		}

		public NetTalkPager(NetTalkPagerSetting setting)
		{
			Setting = setting;
		}
        public NetTalkPager(int PagesCount, int CurrentPage, int Size)
		{
			Setting = new NetTalkPagerSetting(PagesCount, CurrentPage, Size);
		}

		/// <summary>
		/// Main function for getting result
		/// </summary>
		/// <returns>all pages information</returns>
		public NetTalkPagerCollection Get()
		{
            NetTalkPagerCollection result = new NetTalkPagerCollection();

			int mod = Setting.CurrentPage % Setting.Size;
			int div = Setting.CurrentPage / Setting.Size;

			if (mod > 0) div++;

			int LastPage = (Setting.Size * div);
			int FirstPage = (LastPage - Setting.Size) + 1;

			NetTalkPagerItem pg;
			if (Setting.CurrentPage > 1)
			{
				if (Setting.ShowFirstLast)
				{
                    pg = new NetTalkPagerItem();
					pg.Label = Setting.First;
					pg.Index = "0";
					pg.Number = "1";
					pg.Url = Setting.Format(Setting.First, "1", "0");
					result.Add(pg);
				}

				if (Setting.ShowNextPrev)
				{
                    pg = new NetTalkPagerItem();
					pg.Label = Setting.Prev;
					pg.Index = Convert.ToString(Setting.CurrentPage - 2);
					pg.Number = Convert.ToString(Setting.CurrentPage - 1);
					pg.Url = Setting.Format(Setting.Prev, pg.Number, pg.Index);
					result.Add(pg);
				}
			}

			if (Setting.ShowNextPrevSection && (div > 1))
			{
                pg = new NetTalkPagerItem();
				pg.Label = Setting.PrevSection;
				pg.Index = Convert.ToString(FirstPage - 2);
				pg.Number = Convert.ToString(FirstPage - 1);
				pg.Url = Setting.Format(Setting.PrevSection, pg.Number, pg.Index);
				result.Add(pg);
			}

			int iLoop = FirstPage;
			while (iLoop <= Setting.PageCount && iLoop <= LastPage)
			{
                pg = new NetTalkPagerItem();
				pg.Label = PersianNumber(iLoop.ToString());
				pg.Number = pg.Label;
				pg.Index = Convert.ToString(iLoop - 1);
				if (iLoop == Setting.CurrentPage)
				{
					pg.Url = Setting.CurrentPageTemplate
						.Replace("@label", pg.Label)
						.Replace("@number", pg.Number)
						.Replace("@index", pg.Index);
				}
				else
				{
					pg.Url = Setting.Format(pg.Label, pg.Number, pg.Index);
				}
				result.Add(pg);
				iLoop++;
			}

			int modTotal = Setting.PageCount % Setting.Size;
            int divTotal = Setting.PageCount / Setting.Size;

			if (modTotal > 0) divTotal++;

			if (Setting.ShowNextPrevSection && (div < divTotal))
			{
                pg = new NetTalkPagerItem();
				pg.Label = Setting.NextSection;
				pg.Index = LastPage.ToString();
				pg.Number = Convert.ToString(LastPage + 1);
				pg.Url = Setting.Format(pg.Label, pg.Number, pg.Index);
				result.Add(pg);
			}

			if (Setting.CurrentPage < Setting.PageCount)
			{
				if (Setting.ShowNextPrev)
				{
                    pg = new NetTalkPagerItem();
					pg.Label = Setting.Next;
					pg.Index = Setting.CurrentPage.ToString();
					pg.Number = Convert.ToString(Setting.CurrentPage + 1);
					pg.Url = Setting.Format(pg.Label, pg.Number, pg.Index);
					result.Add(pg);
				}

				if (Setting.ShowFirstLast)
				{
                    pg = new NetTalkPagerItem();
					pg.Label = Setting.Last;
					pg.Index = Convert.ToString(Setting.PageCount - 1);
					pg.Number = Setting.PageCount.ToString();
					pg.Url = Setting.Format(pg.Label, pg.Number, pg.Index);
					result.Add(pg);
				}
			}

			return result;
		}

		/// <summary>
		/// If you need to get result as a string
		/// </summary>
		/// <param name="Seprator">join parameter</param>
		/// <returns>all pages information as string</returns>
		public string GetString(string Seprator)
		{
			List<string> StringResult = new List<string>();
			NetTalkPagerCollection Cols = Get();
			for (int i = 0; i < Cols.Count; i++)
			{
				StringResult.Add(Cols[i].Url);
			}
			string result = string.Join(Seprator, StringResult.ToArray());
			return result;
		}

	}
}
