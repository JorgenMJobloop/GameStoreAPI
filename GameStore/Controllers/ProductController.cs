using GameStore.Api.Models.DTO;
using GameStore.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GameStore.Api.Services;
namespace GameStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    // get all the products currently in the dataset/system
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll([FromQuery] string? category, [FromQuery] string? search)
    {
        var products = await _productService.GetAllAsync(category, search);
        return Ok(products);
    }

    // get a specific item by targeting its id in the browser by its URL 
    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);

        if (product is null)
        {
            return NotFound(); // 404 not found
        }

        return Ok(product); // 200 HTTP-Ok
    }
    // create a new Product by targeting the DTO, and using the ASP.NET middleware for "parsing" the JSON-body data [FromBody] and then creating and returning a new item/product this way.
    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto dto)
    {
        var createdProduct = await _productService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }
}