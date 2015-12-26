using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web
{
    public partial class UIControls
    {
        private const string INPUT = "<input{0} />";
        private const string TEXTAREA = "<textarea{0}>{1}</textarea>";
        private const string IMAGE = "<img{0} />";
        private const string LINK = "<a{0}>{1}</a>";
        private const string ScriptBegin = "\r\n<script type=\"text/javascript\">\r\n";
        private const string ScriptEnd = "</script>";
        private const string LABEL = "<label{0}>{1}</label>";
        private const string SELECT = "<select{0}>{1}</select>";
        private const string OPTION = "<option{0}>{1}</option>";
    }
}
