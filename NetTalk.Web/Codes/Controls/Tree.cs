using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace System.Web
{
    public partial class Html
    {
        public abstract class GenericHtmlControl
        {
            public abstract string TagName { get; }
            public abstract bool TagHasEnd { get; }
            public virtual string TagContent { set; get; }

            private Dictionary<string, string> _Attr;
            private Dictionary<string, string> Attr
            {
                get
                {
                    if (_Attr == null)
                        _Attr = new Dictionary<string, string>();
                    return _Attr;
                }
                set
                {
                    _Attr = value;
                }
            }

            #region AttributesMethods
            public virtual void SetAttribute(string Name, string Value)
            {
                if (!string.IsNullOrEmpty(Value))
                {
                    if (Attr.ContainsKey(Name))
                    {
                        Attr[Name] = Value;
                    }
                    else
                    {
                        Attr.Add(Name, Value);
                    }
                }
            }
            public void ClearAttribute(string Name)
            {
                if (Attr.ContainsKey(Name))
                    Attr.Remove(Name);
            }
            public virtual string GetAttribute(string Name)
            {
                if (Attr.ContainsKey(Name))
                    return Attr[Name];
                else
                    return string.Empty;
            }
            public string ToStringAttributes()
            {
                if (Attr.Count > 0)
                {
                    List<string> Result = new List<string>();
                    foreach (string key in Attr.Keys)
                        Result.Add(string.Format("{0}=\"{1}\"", key, Attr[key]));

                    return " " + string.Join(" ", Result.ToArray());
                }
                else
                    return string.Empty;
            }
            #endregion

            #region DefaultAttributes
            public virtual string Id
            {
                set { SetAttribute("id", value); }
                get { return GetAttribute("id"); }
            }
            public virtual string Name
            {
                set { SetAttribute("name", value); }
                get
                {
                    return GetAttribute("name");
                }
            }
            public virtual string CssClass
            {
                set
                {
                    var old = GetAttribute("class");
                    if (string.IsNullOrEmpty(old))
                        SetAttribute("class", value);
                    else
                        SetAttribute("class", value + " " + old);
                }
            }
            public virtual string Style
            {
                set { SetAttribute("style", value); }
            }
            public virtual bool ReadOnly
            {
                set { if (value) SetAttribute("readonly", "readonly"); }
            }
            public virtual bool Disable
            {
                set { if (value) SetAttribute("disabled", "disabled"); }
            }
            #endregion

            public virtual string ToHtml()
            {
                if (TagHasEnd)
                    return "<" + TagName + ToStringAttributes() + " >" + TagContent + "</" + TagName + ">";
                else
                    return "<" + TagName + ToStringAttributes() + " />";
            }
        }

        public class ImageTag : GenericHtmlControl
        {
            public override string TagName { get { return "img"; } }
            public override bool TagHasEnd { get { return false; } }

            public string Alt
            {
                set { SetAttribute("alt", value); }
                get { return GetAttribute("alt"); }
            }
            public string Src
            {
                set { SetAttribute("src", value); }
                get { return GetAttribute("src"); }
            }
        }

        public class LinkTag : GenericHtmlControl
        {
            public override string TagName { get { return "a"; } }
            public override bool TagHasEnd { get { return true; } }

            public string Href
            {
                set { SetAttribute("href", value); }
                get { return GetAttribute("href"); }
            }
        }

        public class DataBindRow
        {
            private Type RowType;
            private object RowValue;

            public DataBindRow(object rowValue)
            {
                RowType = rowValue.GetType();
                RowValue = rowValue;
            }

            public object this[string ColumnName]
            {
                get
                {
                    return RowType.GetProperty(ColumnName).GetValue(RowValue, null);
                }
            }
        }

        public class TreeNode
        {
            public string Id { get; set; }
            public string ParentId { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
            public string Title { get; set; }
            public string Target { get; set; }
            public string Icon { get; set; }
            public string IconOpen { get; set; }
            public bool Open { get; set; }
            public List<string> Keys { get; set; }

            public TreeNode()
            {
                Keys = new List<string>();
            }
        }

        public class TreeNodeBindValues
        {
            public string Id { get; set; }
            public string ParentId { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
            public string Title { get; set; }
            public string Target { get; set; }
            public string Icon { get; set; }
            public string IconOpen { get; set; }
            public string Open { get; set; }
        }

        public class ContextMenuItem
        {
            public string CssClass { get; set; }
            public string Text { get; set; }
            public string Action { get; set; }
            public bool HasSeprator { get; set; }

            public string ToHtml()
            {
                if (HasSeprator)
                {
                    if (!string.IsNullOrEmpty(CssClass))
                        CssClass += " ";
                    CssClass += "separator";
                }

                return string.Format("<li class=\"{0}\"><a href=\"#{2}\">{1}</a></li>", CssClass, Text, Action);
            }
        }

        public class ContextMenu
        {
            public List<ContextMenuItem> Items { get; set; }
            public string Id { get; set; }
            public string MenuFunction { get; set; }
            public string Element { get; set; }

            public ContextMenu(string id, string runFunction, string elementSelector)
            {
                Items = new List<ContextMenuItem>();
                this.Id = id;
                this.MenuFunction = runFunction;
                this.Element = elementSelector;
            }

            public ContextMenu Add(string Text, string Action)
            {
                return Add(Text, Action, null, false);
            }
            public ContextMenu Add(string Text, string Action, bool Seprator)
            {
                return Add(Text, Action, null, Seprator);
            }
            public ContextMenu Add(string Text, string Action, string CssClass, bool Seprator)
            {
                Items.Add(new ContextMenuItem { Action = Action, CssClass = CssClass, HasSeprator = Seprator, Text = Text });
                return this;
            }

            public string ToHtml()
            {
                string html = "<ul id=\"" + this.Id + "\" class=\"contextMenu\">\r\n";
                foreach (ContextMenuItem i in Items)
                    html += i.ToHtml() + "\r\n";
                html += "</ul>";
                html += "<script language=\"javascript\" type=\"text/javascript\">";
                html += "$(document).ready( function() {";
                html += "$(\"" + Element + "\").contextMenu({ menu: '" + Id + "' } , function(action,el,pos){ " + MenuFunction + "(action,el,pos); });";
                html += "});";
                html += "</script>";
                return html;
            }
        }

        public class Tree
        {
            public List<TreeNode> Data { get; set; }
            public ContextMenu Menu { get; set; }
            public List<string> NodeKeys { get; set; }
            public string BaseId { get; set; }
            public string BaseFolder { get; set; }
            public bool AppendData { get; set; }
            public TreeNodeBindValues BindValue { get; set; }
            public bool EnableCheckbox { get; set; }
            public bool EnableNodeImage { get; set; }

            public delegate TreeNode BindNode(DataBindRow RowData, TreeNode CurrentNode);
            public event BindNode OnBindNode;

            public delegate TreeNode RenderNodeHandler(bool IsLastNode, int Level, TreeNode CurrentNode);
            public event RenderNodeHandler OnNodeRender;

            private ImageTag OpenCloseImage;
            private ImageTag OtherImage;
            private LinkTag Text;

            private IEnumerable _DataSource;
            public object Datasource
            {
                set
                {
                    if (value != null)
                        _DataSource = (IEnumerable)value;
                }
            }

            public void Databind()
            {
                if (_DataSource != null)
                {
                    if (!AppendData)
                        Data.Clear();

                    foreach (var item in _DataSource)
                    {
                        DataBindRow RowData = new DataBindRow(item);
                        TreeNode Node = new TreeNode();

                        if (!string.IsNullOrEmpty(BindValue.Id))
                        {
                            object val = RowData[BindValue.Id];
                            if (val != null)
                                Node.Id = Convert.ToString(val);
                        }

                        if (!string.IsNullOrEmpty(BindValue.ParentId))
                        {
                            object val = RowData[BindValue.ParentId];
                            if (val != null)
                                Node.ParentId = Convert.ToString(val);
                        }

                        if (!string.IsNullOrEmpty(BindValue.Icon))
                        {
                            object val = RowData[BindValue.Icon];
                            if (val != null)
                                Node.Icon = Convert.ToString(val);
                        }

                        if (!string.IsNullOrEmpty(BindValue.IconOpen))
                        {
                            object val = RowData[BindValue.IconOpen];
                            if (val != null)
                                Node.IconOpen = Convert.ToString(val);
                        }

                        if (!string.IsNullOrEmpty(BindValue.Name))
                        {
                            object val = RowData[BindValue.Name];
                            if (val != null)
                                Node.Name = Convert.ToString(val);
                        }

                        if (!string.IsNullOrEmpty(BindValue.Open))
                        {
                            object val = RowData[BindValue.Open];
                            if (val != null)
                                Node.Open = Convert.ToBoolean(val);
                        }

                        if (!string.IsNullOrEmpty(BindValue.Target))
                        {
                            object val = RowData[BindValue.Target];
                            if (val != null)
                                Node.Target = Convert.ToString(val);
                        }

                        if (!string.IsNullOrEmpty(BindValue.Title))
                        {
                            object val = RowData[BindValue.Title];
                            if (val != null)
                                Node.Title = Convert.ToString(val);
                        }

                        if (!string.IsNullOrEmpty(BindValue.Url))
                        {
                            object val = RowData[BindValue.Url];
                            if (val != null)
                                Node.Url = Convert.ToString(val);
                        }

                        foreach (string key in NodeKeys)
                        {
                            if (RowData[key] != null)
                                Node.Keys.Add("{'key':'" + key + "','value':'" + Convert.ToString(RowData[key]) + "'}");
                            else
                                Node.Keys.Add("{'key':'" + key + "','value':''}");
                        }

                        if (OnBindNode != null)
                            Node = OnBindNode(RowData, Node);

                        Data.Add(Node);
                    }
                }
            }

            public Tree(string TreeBaseId)
            {
                Data = new List<TreeNode>();
                Menu = new ContextMenu(TreeBaseId + "_ContextMenu", TreeBaseId + ".selectNodeContext", "#" + TreeBaseId + " .TreeNode");
                NodeKeys = new List<string>();
                EnableNodeImage = true;
                BindValue = new TreeNodeBindValues();
                this.BaseId = TreeBaseId;
                this.BaseFolder = "/content/images/tree/fa/";
                OpenCloseImage = new ImageTag();
                OpenCloseImage.CssClass = "TreeImage";
                OtherImage = new ImageTag();
            }

            public string ToHtml()
            {
                List<TreeNode> RootLevel = Data.Where(c => c.ParentId == null).ToList();
                string html = "<div class=\"TreeBase\" id=\"" + BaseId + "\">";
                bool IsLastNode;
                for (int i = 0; i < RootLevel.Count; i++)
                {
                    IsLastNode = ((RootLevel.Count - 1) == i);
                    html += RenderNode("", 1, RootLevel[i], IsLastNode);
                }
                html += "\r\n";
                html += "<script language=\"javascript\" type=\"text/javascript\">";
                html += string.Format("var {0}= new Tree('{0}','{1}',{2})", BaseId, BaseFolder, EnableNodeImage.ToString().ToLower()) + "\r\n";
                html += "</script>";
                if (Menu.Items.Count > 0)
                {
                    html += Menu.ToHtml();
                }
                return html + "</div>";
            }

            private string RenderNode(string prefix, int Level, TreeNode CurrentNode, bool IsLastNode)
            {
                if (OnNodeRender != null)
                    CurrentNode = OnNodeRender(IsLastNode, Level, CurrentNode);

                Text = new LinkTag();
                List<TreeNode> ChildList = Data.Where(c => c.ParentId == CurrentNode.Id).ToList();
                bool HasChild = (ChildList.Count > 0);

                string DataAttr = "";
                if (NodeKeys.Count > 0)
                    DataAttr = " data=\"({ ids: [" + string.Join(",", CurrentNode.Keys.ToArray()) + "] })\"";

                string html = "<div class=\"TreeNode\" id=\"" + BaseId + "_TreeNode" + CurrentNode.Id + "\"" + DataAttr + "><span id=\"" + BaseId + "_TreeNodePrefix" + CurrentNode.Id + "\">" + prefix + "</span>";

                if (HasChild && IsLastNode)
                {
                    OpenCloseImage.Id = BaseId + "_TreeNodeState" + CurrentNode.Id;
                    if (CurrentNode.Open)
                        OpenCloseImage.Src = BaseFolder + "tree/minusbottom.gif";
                    else
                        OpenCloseImage.Src = BaseFolder + "tree/plusbottom.gif";

                    OpenCloseImage.SetAttribute("onclick", string.Format(BaseId + ".changeState('{0}','{1}','{2}')", CurrentNode.Id, CurrentNode.Icon, CurrentNode.IconOpen));
                    html += OpenCloseImage.ToHtml();
                }
                else if (HasChild && !IsLastNode)
                {
                    OpenCloseImage.Id = BaseId + "_TreeNodeState" + CurrentNode.Id;
                    if (CurrentNode.Open)
                        OpenCloseImage.Src = BaseFolder + "tree/minus.gif";
                    else
                        OpenCloseImage.Src = BaseFolder + "tree/plus.gif";

                    OpenCloseImage.SetAttribute("onclick", string.Format(BaseId + ".changeState('{0}','{1}','{2}',null)", CurrentNode.Id, CurrentNode.Icon, CurrentNode.IconOpen));
                    html += OpenCloseImage.ToHtml();
                }
                else if (!HasChild && IsLastNode)
                {
                    OtherImage.Src = BaseFolder + "tree/joinbottom.gif";
                    html += OtherImage.ToHtml();
                }
                else
                {
                    OtherImage.Src = BaseFolder + "tree/join.gif";
                    html += OtherImage.ToHtml();
                }

                if (EnableCheckbox)
                    html += "<input onclick=\"" + BaseId + ".checkNode(this,'" + CurrentNode.Id + "')\" type=\"checkbox\" name=\"" + BaseId + "_CHK\" value=\"" + CurrentNode.Id + "\" />";

                if (EnableNodeImage)
                {
                    OtherImage.Id = BaseId + "_TreeNodeFolder" + CurrentNode.Id;
                    if (HasChild)
                    {
                        if (CurrentNode.Open)
                            OtherImage.Src = (!string.IsNullOrEmpty(CurrentNode.IconOpen)) ? CurrentNode.IconOpen : BaseFolder + "tree/folderopen.gif";
                        else
                            OtherImage.Src = (!string.IsNullOrEmpty(CurrentNode.Icon)) ? CurrentNode.Icon : BaseFolder + "tree/folder.gif";

                        html += OtherImage.ToHtml();
                    }
                    else
                    {
                        OtherImage.Src = BaseFolder + "tree/page.gif";
                        html += OtherImage.ToHtml();
                    }
                    OtherImage.ClearAttribute("id");
                }

                Text.SetAttribute("onclick", string.Format(BaseId + ".selectNode('{0}',{1})", CurrentNode.Id, IsLastNode.ToString().ToLower()));
                Text.SetAttribute("ondblclick", string.Format(BaseId + ".selectNodeDBL('{0}',{1})", CurrentNode.Id, IsLastNode.ToString().ToLower()));

                if (!string.IsNullOrEmpty(CurrentNode.Url))
                {
                    Text.Href = CurrentNode.Url;
                    if (!string.IsNullOrEmpty(CurrentNode.Target))
                        Text.SetAttribute("target", CurrentNode.Target);
                }
                else if (HasChild)
                {
                    Text.Href = "javascript:" + string.Format(BaseId + ".changeState('{0}','{1}','{2}',null)", CurrentNode.Id, CurrentNode.Icon, CurrentNode.IconOpen);
                }
                Text.TagContent = CurrentNode.Name;

                if (!string.IsNullOrEmpty(CurrentNode.Title))
                    Text.SetAttribute("title", CurrentNode.Title);
                html += Text.ToHtml() + "</div>";

                if (HasChild)
                {
                    string ss = "";
                    if (CurrentNode.Open)
                    {
                        ss = " style=\"display:block\"";
                    }
                    html += "<div class=\"TreeNodeChilds\" id=\"" + BaseId + "_TreeNodeChilds" + CurrentNode.Id + "\"" + ss + ">";

                    if (IsLastNode)
                        OtherImage.Src = BaseFolder + "tree/empty.gif";
                    else
                        OtherImage.Src = BaseFolder + "tree/line.gif";

                    prefix += OtherImage.ToHtml();
                    for (int i = 0; i < ChildList.Count; i++)
                    {
                        IsLastNode = (i == (ChildList.Count - 1));
                        html += RenderNode(prefix, (Level + 1), ChildList[i], IsLastNode);
                    }
                    html += "</div>";
                }
                return html;
            }
        }
    }
}
