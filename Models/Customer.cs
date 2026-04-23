namespace GameStore.Api.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}