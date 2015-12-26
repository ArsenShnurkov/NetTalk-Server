using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;
using System.Web;

namespace DynamicSearch
{
    public enum SearchCondition
    {
        Equal = 0,
        NotEqual = 1,
        GreaterThan = 3,
        LowerThan = 5,
        Greater = 2,
        Lower = 4,
        StartsWith = 6,
        EndsWith = 7,
        Contains = 8
    }

    public class Condition
    {
        public static DateTime? ParseDate(string input)
        {
            DateTime? dt = null;
            if (!string.IsNullOrEmpty(input))
            {   
                try
                {
                    NetTalk.Common.Dates.NetTalkDate dtp;
                    if (NetTalk.Common.Dates.NetTalkDate.TryParse(input, out dtp))
                    {
                        dt = dtp.toDateTime();
                    }
                }
                catch { }
            }
            return dt;
        }

        public static ConditionList ParseSearchString(string input)
        {
            input = NetTalk.Common.Validation.Correct.Farsi(input);
            ConditionList cn = new ConditionList();
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    string[] collist = input.Split(new char[] { '|' });
                    string[] param;
                    bool IsDate;
                    foreach (string v in collist)
                    {
                        param = v.Split(new char[] { '$' });
                        IsDate = false;
                        if (!string.IsNullOrEmpty(param[1]))
                            if (param[1] == "date" || param[1] == "datetime")
                                IsDate = true;

                        if (param.Length == 6)
                        {
                            if (!string.IsNullOrEmpty(param[2]) && !string.IsNullOrEmpty(param[3]))
                            {
                                if (IsDate)
                                    cn.Add(param[0], Convert.ToInt32(param[2]), ParseDate(param[3]), param[1], true);
                                else
                                    cn.Add(param[0], Convert.ToInt32(param[2]), param[3],param[1], true);
                            }
                            if (!string.IsNullOrEmpty(param[4]) && !string.IsNullOrEmpty(param[5]))
                            {
                                if (IsDate)
                                    cn.Add(param[0], Convert.ToInt32(param[4]), ParseDate(param[5]), param[1], true);
                                else
                                    cn.Add(param[0], Convert.ToInt32(param[4]), param[5], param[1], true);
                            }
                        }
                    }
                }
            }
            catch { }
            return cn;
        }

        public static string[] ConditionArray = {"it.{0} = {1}", "it.{0} != {1}", 
                                                 "it.{0} > {1}","it.{0} >= {1}", 
                                                 "it.{0} < {1}",  "it.{0} <= {1}", 
                                                 "it.{0}.StartsWith({1})", "it.{0}.EndsWith({1})", 
                                                 "it.{0}.Contains({1})"};

        public Condition(string f, SearchCondition s, object val, string ftype, bool IsAnd)
        {
            Field = f;
            Search = s;
            this.IsAnd = IsAnd;
            Value = val;
            FieldType = ftype;
        }

        public bool IsAnd { get; set; }
        public string Field { get; set; }
        public object Value { get; set; }
        public string FieldType { get; set; }
        public SearchCondition Search { get; set; }

        public string ToString(int Index)
        {
            if (Value != null)
            {
                return string.Format(ConditionArray[(int)Search], Field, "@a_" + Index);
            }
            else
                return string.Empty;
        }
    }

    public class ConditionList : List<Condition>
    {
        private List<object> values { get; set; }

        public ConditionList()
        {
            values = new List<object>();
        }

        public void Add(string field, int condition, object value, string ftype, bool isand)
        {
            values.Add(value);
            this.Add(new Condition(field, (SearchCondition)condition, value, ftype, isand));
        }

        public void Add(string field, SearchCondition condition, object value, string ftype, bool isand)
        {
            values.Add(value);
            this.Add(new Condition(field, condition, value, ftype, isand));
        }

        public ConditionList And(string field, SearchCondition condition, object value, string ftype)
        {
            values.Add(value);
            this.Add(new Condition(field, condition, value, ftype, true));
            return this;
        }

        public ConditionList Or(string field, SearchCondition condition, object value, string ftype)
        {
            values.Add(value);
            this.Add(new Condition(field, condition, value, ftype, false));
            return this;
        }

        public ObjectParameter[] GetParam()
        {
            ObjectParameter[] paramlist = new ObjectParameter[values.Count];
            for (int i = 0; i < values.Count; i++)
            {
                paramlist[i] = new ObjectParameter("a_" + i.ToString(), values[i]);
            }
            return paramlist;
        }

        public string GetString()
        {
            string result = "";
            if (this.Count > 1)
            {
                int lastindex = this.Count - 1;
                for (int i = 0; i < this.Count; i++)
                {
                    if (i != 0)
                    {
                        result += ((this[i].IsAnd) ? " && " : " || ") + this[i].ToString(i);
                    }
                    else
                    {
                        result += this[i].ToString(i);
                    }
                }
            }
            else if (this.Count == 1)
            {
                result = this[0].ToString(0);
            }

            return result;
        }
    }
}