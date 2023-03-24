using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Models.Input.Vendor
{
    public class ProductDetails
    {
        public Int32 ProductId { get; set; } 
        public Int32 VendorId { get; set; }
        public Int32 CategoryId { get; set; }  
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public decimal Price { get; set; }
        public Int32 Discount { get; set; }
        public decimal ShippingCharge { get; set; }
        public bool IsDelete { get; set; }
    }
}
