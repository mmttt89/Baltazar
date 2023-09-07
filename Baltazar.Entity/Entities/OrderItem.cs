using System;
namespace Baltazar.Entity.Entities
{
	public class OrderItem
	{
        public int OrderItemId { get; set; }
        public int OrderId { get; set; } // Reference to the order this item belongs to
        public required Order Order { get; set; }
        public int ProductId { get; set; } // Reference to the product in this item
        public required Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

