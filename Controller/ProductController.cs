
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
     public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet("/getImages")]
    public async Task<ActionResult<IEnumerable<ProductModel>>> GetImages()
    {
        var products = await _productService.GetProducts();
        return Ok(products);
    }
    
}