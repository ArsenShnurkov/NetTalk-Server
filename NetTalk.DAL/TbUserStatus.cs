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
    
    public partial class TbUserStatus
    {
        public System.Guid UserId { get; set; }
        public short UserStatus { get; set; }
        public string UserStatusText { get; set; }
        public bool UserIsOnline { get; set; }
        public System.DateTime UserStatusDate { get; set; }
    
        public virtual TbUsers TbUsers { get; set; }
    }
}
