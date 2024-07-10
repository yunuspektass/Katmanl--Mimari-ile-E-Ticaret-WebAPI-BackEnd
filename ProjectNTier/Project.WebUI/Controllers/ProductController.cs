using Microsoft.AspNetCore.Mvc;
using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.BLL.DTOs.Product; // mvc için gerekli 

namespace Project.WebUI.Controllers; 

[Route("api/[controller]")] //API route tanımı. api/controller
[ApiController] // API controller olduğunu belirtir.
public class ProductController:ControllerBase
{
    private readonly IProductService _productService;
 

    public ProductController(IProductService productService)
    {

        _productService = productService;
        // ProductRepository bağımlılığını _productRepository de kullanmak için atama yaptık
    }

    [HttpGet] // Get api/Products
    public async Task<ActionResult<IEnumerable<ProductGetDto>>> GetProducts()
    {
        var productDto = await _productService.GetProducts();
        return Ok(productDto); // HTTP 200 OK durum kodu ve ürünler listesini döndük 
    }
    
    [HttpGet("{id:int}")] // GET api/Product/5
    public async Task<ActionResult<ProductGetDto>> GetProduct(int id)
    {
        var productDto = await _productService.GetProduct(id);

        if (productDto == null)
        {
            return NotFound(); // ürün bulunmazsa HTTP 404 dönecek 
        }
        
        return Ok(productDto); //HTTP 200 Ok ve ürün modelini döner 
    }

    [HttpPost] // POST : api/Products
    public async Task<ActionResult<ProductCreateDto>> PostProduct(ProductCreateDto productCreateDto)
    {
        var CreatedproductDto = await _productService.PostProduct(productCreateDto);
     
        return CreatedAtAction("GetProduct", new { id = CreatedproductDto.CategoryID }, CreatedproductDto);
        //HTTP 201 eklendi durum kodu ile eklenen ürün modelini döndürür
    }

    [HttpPut("{id:int}")] // put api/Products/5 
    public async Task<IActionResult> PutProduct(int id, ProductUpdateDto productUpdateDto)
    {
        if (id != productUpdateDto.ID)
        {
            return BadRequest(); // id ler uyuşmazsa HTTP 400 bas request dönecek
        }

        var result = await _productService.PutProduct(id, productUpdateDto);

        if (!result)
        {
            return NotFound(); // ürün bulunamazsa HTTP 404 not found döner 
        }
        
        return NoContent(); // HTTP 204 eklendi döndürür
    }

    [HttpDelete("{id:int}")] // delete api/Products/5
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteProduct(id);

        if (!result)
        {
            return NotFound(); // ürün bulunamadı 404 not found döncek 
        }


        return NoContent(); //HTTP 204 içeriksiz silindi. 
        
    }
    
    
}