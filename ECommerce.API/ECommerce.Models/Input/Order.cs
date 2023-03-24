using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Models.Input
{
   public class Order
    {
        public Int32 OrderId { get; set; }
     // public Int32 UserId { get; set; }
      //public string Image { get; set; }
     // public Int32 ProductId { get; set; }
      //  public string Model { get; set; }
     //   public string Brand { get; set; }
     //   public decimal Price { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Int64 PinCode { get; set; }
        public string Email { get; set; }
        public string AddressType { get; set; }
   //   public Int16 Status { get; set; }
    }
}
