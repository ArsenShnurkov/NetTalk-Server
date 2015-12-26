using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections;
using System.Web.Script.Serialization;
using System.Reflection;
using System.Xml;

namespace System.Web
{
    public partial class Html
    {
        public enum SortTypes
        {
            @string = 0,
            number = 1,
            guid = 2,
            date = 3,
            @bool = 4,
            datetime = 5
        }

        public class GridColumn
        {
            public delegate string Render(GridColumn sender, DataBindRow RowValues, object Value);
            private Dictionary<string, string> _Attributes;
            public event Render OnRender;
            public string BindRow { get; set; }
            public string DefaultValue { get; set; }
            public string Name { get; set; }
            public bool EnableSort { get; set; }

            private SortTypes _SortType;
            public SortTypes SortType
            {
                get
                {
                    return _SortType;
                }
                set
                {
                    EnableSort = true;
                    _SortType = value;
                }
            }

            public GridColumn()
            {
                SortType = SortTypes.@string;
                _Attributes = new Dictionary<string, string>();
                EnableSort = true;
            }

            public string Id
            {
                get
                {
                    return GetAttribute("id");
                }
                set
                {
                    SetAttribute("id", value);
                }
            }

            public string Style
            {
                get
                {
                    return GetAttribute("style");
                }
                set
                {
                    SetAttribute("style", value);
                }
            }

            public string Class
            {
                get
                {
                    return GetAttribute("class");
                }
                set
                {
                    SetAttribute("class", value);
                }
            }

            public GridColumn SetAttribute(string Name, string Value)
            {
                if (_Attributes.ContainsKey(Name))
                {
                    _Attributes[Name] = Value;
                }
                else
                {
                    _Attributes.Add(Name, Value);
                }
                return this;
            }

            public string GetAttribute(string Name)
            {
                if (_Attributes.ContainsKey(Name))
                    return _Attributes[Name];
                else
                    return string.Empty;
            }

            private string _gattr = null;
            public string GetAttributes()
            {
                if (string.IsNullOrEmpty(_gattr))
                {
                    if (_Attributes.Keys.Count > 0)
                    {
                        string[] att = new string[_Attributes.Keys.Count];
                        int index = 0;
                        foreach (string key in _Attributes.Keys)
                        {
                            att[index] = string.Format("{0}=\"{1}\"", key, _Attributes[key]);
                            index++;
                        }
                        _gattr = " " + string.Join(" ", att);
                    }
                    else
                        _gattr = string.Empty;
                }
                return _gattr;
            }

            public virtual string ToString(DataBindRow RowValues, object Value)
            {
                if (OnRender != null)
                {
                    return OnRender(this, RowValues, Value);
                }
                else if (Value != null)
                {
                    //اخطار : همین طوری اینجا رو تغییر ندهید
                    if ((this.EnableSort) && (this.SortType == SortTypes.date))
                        return (new NetTalk.Common.Dates.NetTalkDate((DateTime)Value)).ToString("$yyyy/$MM/$dd");
                    else if ((this.EnableSort) && (this.SortType == SortTypes.datetime))
                        return (new NetTalk.Common.Dates.NetTalkDate((DateTime)Value)).ToString("$dd $MMMM $yyyy $HH:$mm");
                    else if ((this.EnableSort) && (this.SortType == SortTypes.@bool))
                        return string.Format("<div style=\"text-align:center\"><img src=\"/Content/images/{0}\" alt=\"{1}\" /></div>", ((bool)Value) ? "Tick25.png" : "Error25.png", ((bool)Value) ? "بله" : "خیر");
                    else
                        return Convert.ToString(Value);
                }
                else
                    return DefaultValue;
            }
        }

        public class GridColumns : List<GridColumn>
        {
            public override string ToString()
            {
                JavaScriptSerializer api = new JavaScriptSerializer();
                return api.Serialize(
                    this.Select(c => new
                    {
                        name = c.Name,
                        sort = (c.EnableSort) ? c.SortType.ToString() : "",
                        bind = c.BindRow
                    }));
            }
        }

        public class HtmlGrid
        {
            public string OddRowCssClass { get; set; }
            public string EvenRowCssClass { get; set; }

            public string Title { get; set; }
            public string DefaultSort { get; set; }
            public bool EnableRowNo { get; set; }
            public GridColumns Columns { get; set; }
            public List<string> GridKeys;
            public object Data { get; set; }
            public int TotalRecords { get; set; }

            public void BLL(Type BLLClass, string MethodName, string DefaultSort, params object[] otherparam)
            {
                this.DefaultSort = DefaultSort;
                object[] MethodData = new object[5 + otherparam.Length];
                MethodData[0] = DefaultSort;
                DynamicSearch.ConditionList SearchData = DynamicSearch.Condition.ParseSearchString(HttpContext.Current.Request.Form["Filter"]);
                MethodData[1] = SearchData;
                MethodData[2] = HttpContext.Current.Request.Form["Sort"];
                MethodData[3] = Convert.ToInt32(HttpContext.Current.Request.Form["PageIndex"]);
                MethodData[4] = Convert.ToInt32(HttpContext.Current.Request.Form["PageSize"]);
                for (int i = 0; i < otherparam.Length; i++)
                    MethodData[(5 + i)] = otherparam[i];

                var obj = Activator.CreateInstance(BLLClass);
                Data = BLLClass.InvokeMember(MethodName,
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null, obj, MethodData);


                MethodData = new object[1 + otherparam.Length];
                MethodData[0] = SearchData;
                for (int i = 0; i < otherparam.Length; i++)
                    MethodData[(1 + i)] = otherparam[i];

                TotalRecords = (int)BLLClass.InvokeMember(MethodName + "Count",
                    BindingFlags.Default | BindingFlags.InvokeMethod,
                    null, obj, MethodData);
            }

            public void BLL(Type BLLClass, string DefaultSort)
            {
                BLL(BLLClass, "List", DefaultSort);
            }

            public bool AutoGenerateColumn
            {
                set
                {
                    if (value)
                        GenerateColumns();
                }
            }

            private void GenerateColumns()
            {
                Columns = new GridColumns();
                if (Data != null)
                {
                    var items = (IEnumerable)Data;
                    object fitem = null;
                    foreach (var item in items)
                    {
                        fitem = item;
                        break;
                    }
                    string[] collist = fitem.GetType().GetProperties().Select(col => col.Name).ToArray();
                    foreach (string col in collist)
                        Columns.Add(new GridColumn
                        {
                            BindRow = col,
                            DefaultValue = string.Empty,
                            Name = col,
                            EnableSort = false
                        });
                }
            }

            public HtmlGrid()
            {
                Columns = new GridColumns();
                GridKeys = new List<string>();
                EnableRowNo = true;
            }

            public object ToJson(int TotalRecord, int PageSize)
            {
                this.TotalRecords = TotalRecords;
                string[] tt;
                if (!string.IsNullOrEmpty(DefaultSort))
                {
                    tt = DefaultSort.Split(new char[] { ',' });
                    tt = tt[0].Split(new char[] { ' ' });
                    if (tt.Length == 1)
                    {
                        tt = new string[] { tt[0], "" };
                    }
                }
                else
                {
                    tt = new string[2];
                    tt[0] = "";
                    tt[1] = "";
                }
                int TotalPages = NetTalk.Common.Pager.NetTalkPager.CalculatePageCount(TotalRecord, PageSize);
                return new
                {
                    Title = Title,
                    Html = this.ToHtml(),
                    Columns = this.Columns.ToString(),
                    TotalRecords = TotalRecord,
                    TotalPages = TotalPages,
                    SortF = tt[0],
                    SortD = tt[1]
                };
            }

            public object ToJson()
            {
                return ToJson(TotalRecords, Convert.ToInt32(HttpContext.Current.Request.Form["PageSize"]));
            }

            public string ToHtml()
            {
                if (Data != null)
                {
                    int BeginIndex = (Convert.ToInt32(HttpContext.Current.Request.Form["PageSize"])
                        * Convert.ToInt32(HttpContext.Current.Request.Form["PageIndex"]));
                    BeginIndex++;
                    StringBuilder sb = new StringBuilder();
                    var items = (IEnumerable)Data;
                    if (Columns.Count == 0)
                    {
                        GenerateColumns();
                    }

                    if (EnableRowNo)
                        Columns.Insert(0, new GridColumn { BindRow = "RowNo", EnableSort = false, Name = "" });

                    List<string> RowKey = new List<string>();
                    object tmp;
                    string rowcss;
                    bool addCssRow = (!string.IsNullOrEmpty(OddRowCssClass) || !string.IsNullOrEmpty(EvenRowCssClass));
                    foreach (var row in items)
                    {
                        RowKey = new List<string>();
                        rowcss = "";
                        DataBindRow RowData = new DataBindRow(row);

                        foreach (string key in GridKeys)
                        {
                            tmp = RowData[key];
                            if (tmp == null)
                                RowKey.Add("{'key':'" + key + "','value':''}");
                            else
                                RowKey.Add("{'key':'" + key + "','value':'" + Convert.ToString(tmp) + "'}");
                        }
                        if (addCssRow)
                        {
                            if ((BeginIndex % 2) == 0)
                                rowcss = " class=\"" + EvenRowCssClass + "\"";
                            else
                                rowcss = " class=\"" + OddRowCssClass + "\"";
                        }
                        sb.Append("<tr" + rowcss + " data=\"({ ids:[ " + string.Join(",", RowKey.ToArray()) + " ] })\">");
                        foreach (var col in Columns)
                        {
                            if (col.BindRow != "RowNo")
                            {
                                var value = RowData[col.BindRow];
                                sb.AppendFormat("<td{1}>{0}</td>", col.ToString(RowData, value), col.GetAttributes());
                            }
                            else
                            {
                                sb.AppendFormat("<td style=\"width:20px\">" + BeginIndex + "</td>");
                            }
                        }
                        sb.Append("</tr>");
                        BeginIndex++;
                    }
                    return sb.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            public XmlDocument ToXml()
            {
                if (Data != null)
                {
                    int BeginIndex = (Convert.ToInt32(HttpContext.Current.Request.Form["PageSize"])
                        * Convert.ToInt32(HttpContext.Current.Request.Form["PageIndex"]));
                    BeginIndex++;

                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.AppendChild(xmldoc.CreateXmlDeclaration("1.0", "utf-8", null));
                    XmlElement DatasetRoot = xmldoc.CreateElement("dataset");
                    XmlElement XmlRow, XmlCol;

                    XmlAttribute attr;
                    attr = xmldoc.CreateAttribute("name");
                    if (!string.IsNullOrEmpty(this.Title))
                    {
                        attr.Value = HttpUtility.HtmlEncode(this.Title);
                        DatasetRoot.Attributes.Append(attr);
                    }
                    attr = xmldoc.CreateAttribute("index");
                    attr.Value = HttpContext.Current.Request.Form["PageIndex"];
                    DatasetRoot.Attributes.Append(attr);

                    attr = xmldoc.CreateAttribute("total");
                    attr.Value = TotalRecords.ToString();
                    DatasetRoot.Attributes.Append(attr);

                    StringBuilder sb = new StringBuilder();
                    var items = (IEnumerable)Data;
                    if (Columns.Count == 0)
                    {
                        GenerateColumns();
                    }

                    if (EnableRowNo)
                        Columns.Insert(0, new GridColumn { BindRow = "RowNo", EnableSort = false, Name = "" });

                    XmlCDataSection cda;
                    foreach (var row in items)
                    {
                        DataBindRow RowData = new DataBindRow(row);
                        XmlRow = xmldoc.CreateElement("row");
                        foreach (var col in Columns)
                        {
                            XmlCol = xmldoc.CreateElement("col");
                            attr = xmldoc.CreateAttribute("name");
                            attr.Value = col.Name;
                            XmlCol.Attributes.Append(attr);

                            attr = xmldoc.CreateAttribute("field");
                            attr.Value = col.BindRow;
                            XmlCol.Attributes.Append(attr);

                            var value = RowData[col.BindRow];
                            cda = xmldoc.CreateCDataSection(col.ToString(RowData, value));
                            XmlCol.AppendChild(cda);

                            if (col.BindRow == "RowNo")
                            {
                                attr = xmldoc.CreateAttribute("no");
                                attr.Value = BeginIndex.ToString();
                                XmlRow.Attributes.Append(attr);
                                BeginIndex++;
                            }
                            XmlRow.AppendChild(XmlCol);
                        }
                        DatasetRoot.AppendChild(XmlRow);
                    }

                    xmldoc.AppendChild(DatasetRoot);
                    return xmldoc;
                }
                else
                {
                    return new XmlDocument();
                }
            }

            public string HtmlTable()
            {
                List<string> Tmp = GridKeys;
                GridKeys.Clear();
                string result = "<table border=\"1\" style=\"border:1px solid black;border-collapse:collapse;\"><thead>";

                if (EnableRowNo)
                    result += "<th>&nbsp;</th>";

                foreach (var col in Columns)
                {
                    result += "<th>" + col.Name + "</th>";
                }
                result += "</thead><tbody>";
                result += ToHtml();
                GridKeys = Tmp;
                return result + "</tbody></table>";
            }
        }
    }
}