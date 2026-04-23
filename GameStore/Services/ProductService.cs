using GameStore.Api.Models;
using GameStore.Api.Models.DTO;
using GameStore.Api.Services.Interfaces;

namespace GameStore.Api.Services;

public class ProductService : IProductService
{
    private static readonly List<Category> _productCategories = new List<Category>()
    {
        new Category {Id = 1, Name = "Games", Slug = "games"},
        new Category {Id = 2, Name = "Consoles", Slug = "consoles"},
        new Category {Id = 3, Name = "Components", Slug = "components"},
        new Category {Id = 4, Name = "Accessories", Slug = "accessories"}
    };

    private static readonly List<Product> _products = new List<Product>()
    {
        new Product
        {
            Id = 1,
            Name = "Playstation 5 Slim",
            Description = "Next-generation gaming console with a ultra-fast Sony SSD, following their massive hit the Playstation 4",
            Price = 6990,
            CurrentlyInStock = 15,
            Brand = "Sony",
            SKUNumber = "SONY-PS5-SLIM",
            CategoryId = 2,
            IsAvailable = true
        },
        new Product
        {
            Id = 2,
            Name = "GeForce RTX 5080",
            Description = "High-end graphics card for the gamer that wants peak performance in their system",
            Price = 15490,
            CurrentlyInStock = 15,
            Brand = "NVIDIA",
            SKUNumber = "GPU-RTX-5080",
            CategoryId = 3,
            IsAvailable = true
        },
        new Product
        {
            Id = 3,
            Name = "Elden Ring",
            Description = "Rich fantasy action RPG written by famous author George.R.R Martin (A Song Of Ice And Fire) & HBO's Game Of Thrones universe.",
            Price = 590,
            CurrentlyInStock = 32,
            Brand = "Bandai Namco",
            SKUNumber = "GAMES-ELDEN-RING",
            CategoryId = 1,
            IsAvailable = true
        }
    };

    public Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        // create a new Id for the new entry
        var newId = _products.Count == 0 ? 1 : _products.Max(p => p.Id) + 1;

        // create the new entry itself
        var product = new Product
        {
            Id = newId,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CurrentlyInStock = dto.CurrentlyInStock,
            Brand = dto.Brand,
            SKUNumber = dto.SKUNumber,
            CategoryId = dto.CategoryId,
            IsAvailable = dto.CurrentlyInStock > 0
        };

        _products.Add(product);

        return Task.FromResult(MapToDto(product));
    }

    public Task<bool> DeleteAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product is null)
        {
            return Task.FromResult(false);
        }

        _products.Remove(product);
        return Task.FromResult(true);
    }

    public Task<IEnumerable<ProductDto>> GetAllAsync(string? category, string? search)
    {
        IEnumerable<Product> searchQuery = _products;

        if (!string.IsNullOrWhiteSpace(category))
        {
            var matchingCategory = _productCategories.FirstOrDefault(c => c.Name.Equals(category, StringComparison.OrdinalIgnoreCase)
            || c.Slug.Equals(category, StringComparison.OrdinalIgnoreCase));

            if (matchingCategory is not null)
            {
                searchQuery = searchQuery.Where(p => p.CategoryId == matchingCategory.Id);
            }
            else
            {
                searchQuery = [];
            }
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            searchQuery = searchQuery.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
            || p.Description.Contains(search, StringComparison.OrdinalIgnoreCase)
            || p.Brand.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        var result = searchQuery.Select(MapToDto);

        return Task.FromResult(result);
    }

    public Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product is null)
        {
            return Task.FromResult<ProductDto?>(null);
        }

        return Task.FromResult<ProductDto?>(MapToDto(product));
    }

    public Task<bool> UpdateAsync(int id, UpdateProductDto dto)
    {
        // instead of create a new id, we get the id the product we want to update, currently holds
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product is null)
        {
            return Task.FromResult(false);
        }

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.CurrentlyInStock = dto.CurrentlyInStock;
        product.Brand = dto.Brand;
        product.SKUNumber = dto.SKUNumber;
        product.IsAvailable = dto.IsAvailable;
        product.CategoryId = dto.CategoryId;

        return Task.FromResult(true);
    }

    private ProductDto MapToDto(Product product)
    {
        var categoryName = _productCategories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name ?? "Unknown";

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CurrentlyInStock = product.CurrentlyInStock,
            Brand = product.Brand,
            SKUNumber = product.SKUNumber,
            IsAvailable = product.IsAvailable,
            CategoryName = categoryName
        };
    }
}