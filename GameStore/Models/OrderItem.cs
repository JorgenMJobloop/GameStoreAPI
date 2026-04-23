namespace GameStore.Api.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public int ProductId { get; set; } // foreign key
    public Product? Product { get; set; }
    public int OrderId { get; set; } // foreign key
    public Order? Order { get; set; }
}