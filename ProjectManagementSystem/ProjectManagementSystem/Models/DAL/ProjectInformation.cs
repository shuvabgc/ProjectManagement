//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagementSystem.Models.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectInformation
    {
        public int iID { get; set; }
        public string vName { get; set; }
        public string vCodeName { get; set; }
        public string vDescription { get; set; }
        public System.DateTime dStartDate { get; set; }
        public System.DateTime dEndDate { get; set; }
        public int iDurationInDays { get; set; }
        public string vFilesName { get; set; }
        public string vStatus { get; set; }
    }
}
