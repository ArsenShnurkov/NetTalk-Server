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
    
    public partial class TbVcard
    {
        public System.Guid UserId { get; set; }
        public string VcardURL { get; set; }
        public string VcardTitle { get; set; }
        public string VcardFirstName { get; set; }
        public string VcardLastName { get; set; }
        public string VcardPhoto { get; set; }
        public string VcardOrgName { get; set; }
        public string VcardOrgUnit { get; set; }
        public string VcardNickname { get; set; }
        public string VcardDescription { get; set; }
        public Nullable<System.DateTime> VcardBirthday { get; set; }
        public string VcardEmail { get; set; }
        public string VcardTelCell { get; set; }
        public string VcardTelFax { get; set; }
        public string VcardTelVoice { get; set; }
        public string VcardTelVoice2 { get; set; }
    
        public virtual TbUsers TbUsers { get; set; }
    }
}