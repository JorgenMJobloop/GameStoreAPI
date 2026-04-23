namespace GameStore.Api.Models.DTO;

public class ProductDto
{
    /// <summary>
    /// This property holds a internal counter for a database connection primary key, and thus, it has to be hidden away in a DTO
    /// </summary>
    public int Id { get; set; } // this can be changed during testing, if we need to limit the access of this property
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    /// <summary>
    /// Holds a internal counter for the quantity currently in stock of said item/product
    /// </summary>
    public int CurrentlyInStock { get; set; }
    public string Brand { get; set; } = string.Empty;
    /// <summary>
    /// Represents the SKU number as a string, this is a alphanumeric code that is assigned by retailers to identify and track specific items within their inventory system.
    /// </summary>
    public string SKUNumber { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;
    public int CategoryId { get; set; } // foreign key
    public string CategoryName { get; set; } = string.Empty;
}