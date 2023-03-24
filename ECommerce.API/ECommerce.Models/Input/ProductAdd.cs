using System;


namespace ECommerce.Models.Input
{
    public  class ProductAdd
    {
        public Int32 ProductId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public Int32 Discount { get; set; }
        public string Specification { get; set; }
        public Int32 QtyinStock { get; set; }
        public decimal Rating { get; set; }
        public string Colour { get; set; }
        public string Storage { get; set; }
       // public string FileName { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
    }
}
