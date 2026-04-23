using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Models.DTO;

public class CreateProductDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;
    [Range(0.01, 300000)]
    public decimal Price { get; set; }
    [Range(0, int.MaxValue)]
    public int CurrentlyInStock { get; set; }
    [Required]
    [StringLength(50)]
    public string Brand { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string SKUNumber { get; set; } = string.Empty;
    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }
}