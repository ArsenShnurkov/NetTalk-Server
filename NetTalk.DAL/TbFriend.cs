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
    
    public partial class TbFriend
    {
        public System.Guid UserId { get; set; }
        public System.Guid FriendId { get; set; }
        public string GroupName { get; set; }
        public byte FriendStatus { get; set; }
    
        public virtual TbUsers TbUsers { get; set; }
        public virtual TbUsers TbUsers1 { get; set; }
    }
}
