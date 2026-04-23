using GameStore.Api.Models.DTO;

namespace GameStore.Api.Services.Interfaces;

public interface IProductService
{
    /// <summary>
    /// Get all products available by searching using a search-term as a keyword
    /// </summary>
    /// <param name="category">Category</param>
    /// <param name="search">search term</param>
    /// <returns>Task as Enumerable collection</returns>
    Task<IEnumerable<ProductDto>> GetAllAsync(string? category, string? search);
    Task<ProductDto?> GetByIdAsync(int id);
    Task<ProductDto> CreateAsync(CreateProductDto dto);
    Task<bool> UpdateAsync(int id, UpdateProductDto dto); // update a existing product targeted via an ID
    Task<bool> DeleteAsync(int id); // Delete an existing item entry
}