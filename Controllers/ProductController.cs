using Microsoft.AspNetCore.Mvc;

namespace restApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Product> GetAllProducts()
    {
        // Returns a list of mock products
        return new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "A high-performance laptop", Price = 999.99m },
            new Product { Id = 2, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 199.99m }
        };
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = new Product { Id = id, Name = "Sample Product", Description = "Sample Description", Price = 9.99m };
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product newProduct)
    {
        newProduct.Id = new Random().Next(1000);
        return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct); 
    }
}
