namespace Baltazar.Entity.Entities
{
	public class Order
	{
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCompleted { get; set; }

        public required string UserId { get; set; } // Foreign key
        public required ApplicationUser User { get; set; } // Navigation property

        public ICollection<Product>? Products { get; set; }
    }
}

