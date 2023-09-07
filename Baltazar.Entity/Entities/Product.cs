using System;
namespace Baltazar.Entity.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        // Navigation property for the order that contains this product
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}

