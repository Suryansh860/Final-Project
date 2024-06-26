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
    
    public partial class travelRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public travelRequest()
        {
            this.bookingstatus = new HashSet<bookingstatu>();
        }
    
        public int requestid { get; set; }
        public string employeeFirstName { get; set; }
        public string employeeLastName { get; set; }
        public string employeeEmail { get; set; }
        public Nullable<int> employeeid { get; set; }
        public string reasonForTravel { get; set; }
        public Nullable<bool> flightNeeded { get; set; }
        public Nullable<bool> hotelNeeded { get; set; }
        public string departureCity { get; set; }
        public string arrivalCity { get; set; }
        public Nullable<System.DateTime> departureDate { get; set; }
        public Nullable<System.DateTime> arrivalDate { get; set; }
        public string additionalInformation { get; set; }
        public string approvalstatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookingstatu> bookingstatus { get; set; }
        public virtual employee employee { get; set; }
    }
}
