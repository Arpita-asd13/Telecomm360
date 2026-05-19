
using Microsoft.AspNetCore.Mvc; 
using Telecom360.Models;
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase


{
    private static List<Product> products = new List<Product>
    {
        new Product { ProductId = 1, Name = "Product A", Category = "Category 1", PriceModel = 100, Status = "Available" },
        new Product { ProductId = 2, Name = "Product B", Category = "Category 2", PriceModel = 200, Status = "Out of Stock" },
        new Product { ProductId = 3, Name = "Product C", Category = "Category 1", PriceModel = 150, Status = "Available" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        product.ProductId = products.Max(p => p.ProductId) + 1;
        products.Add(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, Product updatedProduct)
    {
        var product = products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }
        product.Name = updatedProduct.Name;
        product.Category = updatedProduct.Category;
        product.PriceModel = updatedProduct.PriceModel;
        product.Status = updatedProduct.Status;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        var product = products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }
        products.Remove(product);
        return NoContent();
    }
}