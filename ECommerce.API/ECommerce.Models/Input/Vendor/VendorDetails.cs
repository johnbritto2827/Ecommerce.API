using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Models.Input.Vendor
{
    public class VendorDetails
    {
        public Int32 VendorId { get; set; }
        public string VendorName { get; set; }
        public Int32 TypeofProduct { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public Int32 City { get; set; }
        public Int32 Districk { get; set; }
        public Int32 State { get; set; }
        public Int32 Pincode { get; set; }
        public DateTime RegisterOn { get; set; }
        public DateTime ActivatedOn { get; set; }
        public Decimal YearlySubscription { get; set; }
        public Int32 Status { get; set; }
        public Decimal  Nextdue { get; set; }
        public bool IsDelete { get; set; }
    }
}
