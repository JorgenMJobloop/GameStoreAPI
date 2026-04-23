namespace GameStore.Api.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; } // number of orders
    public string Status { get; set; } = "Pending";
    public int CustomerId { get; set; } // foreign key
    public Customer? Customer { get; set; }
    public ICollection<OrderItem> Orders { get; set; } = new List<OrderItem>();
}