namespace GameStore.Api.Models;
/// <summary>
/// Category model
/// </summary>
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// This has to do with "SEO"(search-engine-optimization) and business logic. A url-slug targets a primary keyword for a product.
    /// </summary>
    public string Slug { get; set; } = string.Empty;
    /// <summary>
    /// Circular reference back to Products, the category stores a circular reference to the product itself within a specific category.
    /// </summary>
    public ICollection<Product> Products { get; set; } = new List<Product>();
}