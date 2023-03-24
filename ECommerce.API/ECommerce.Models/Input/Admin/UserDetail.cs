using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Models.Input
{
   public class UserDetail
    {
        public Int32 UserId { get; set; } = 0;
        public Int32 UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Int32 Districk { get; set; }
        public Int32 State { get; set; }
        public Int32 Pincode { get; set; }
        public string IdentityProof { get; set; }
        public bool IsDeleted { get; set; }
    }

}
