//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetTalk.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TbMessage
    {
        public System.Guid MessageId { get; set; }
        public System.DateTime MessageDate { get; set; }
        public Nullable<System.DateTime> MessageViewDate { get; set; }
        public System.Guid MessageFromUserId { get; set; }
        public System.Guid MessageToUserId { get; set; }
        public string MessageText { get; set; }
        public string MessageHTML { get; set; }
        public string MessageSenderIP { get; set; }
    
        public virtual TbUsers TbUsers { get; set; }
        public virtual TbUsers TbUsers1 { get; set; }
    }
}
