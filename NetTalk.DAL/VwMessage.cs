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
    
    public partial class VwMessage
    {
        public System.Guid MessageId { get; set; }
        public System.DateTime MessageDate { get; set; }
        public Nullable<System.DateTime> MessageViewDate { get; set; }
        public System.Guid MessageFromUserId { get; set; }
        public System.Guid MessageToUserId { get; set; }
        public string MessageText { get; set; }
        public string MessageHTML { get; set; }
        public string MessageSenderIP { get; set; }
        public string MessageFromFirstName { get; set; }
        public string MessageFromLastName { get; set; }
        public string MessageFromPhoto { get; set; }
        public string MessageToFirstName { get; set; }
        public string MessageToLastName { get; set; }
        public string MessageToPhoto { get; set; }
    }
}
