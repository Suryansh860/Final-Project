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
    
    public partial class travelagent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public travelagent()
        {
            this.bookingstatus = new HashSet<bookingstatu>();
        }
    
        public int agentid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string travel_agent_password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookingstatu> bookingstatus { get; set; }
    }
}
