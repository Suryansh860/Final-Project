//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Emp_Travel_Booking_Sys.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bookingstatu
    {
        public int bookingid { get; set; }
        public Nullable<int> requestid { get; set; }
        public Nullable<int> agentid { get; set; }
        public string status { get; set; }
    
        public virtual travelagent travelagent { get; set; }
        public virtual travelRequest travelRequest { get; set; }
    }
}
