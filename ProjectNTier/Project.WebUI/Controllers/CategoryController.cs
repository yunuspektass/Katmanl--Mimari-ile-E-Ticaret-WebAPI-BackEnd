using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.BLL.DTOs.Category;

namespace Project.WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryGetDto>>> GetList()
    {
        var categoriesDto = await _categoryService.GetList();

        return Ok(categoriesDto);
    }
    
    [HttpGet("{id:int}")] // GET api/Product/5
    public async Task<ActionResult<CategoryGetDto>> GetItem(int id)
    {
        var categoryDto = await _categoryService.GetItem(id);

        if (categoryDto == null)
        {
            return NotFound(); // ürün bulunmazsa HTTP 404 dönecek 
        }
        
        return Ok(categoryDto); //HTTP 200 Ok ve ürün modelini döner 
    }
    
    [HttpPost] // POST : api/Products
    public async Task<ActionResult<CategoryCreateDto>> PostItem(CategoryCreateDto categoryCreateDto)
    {
        var CreatedcategoryDto = await _categoryService.PostItem(categoryCreateDto);
     
        return Ok();
        //HTTP 201 eklendi durum kodu ile eklenen ürün modelini döndürür
    }
    
    [HttpPut("{id:int}")] // put api/Products/5 
    public async Task<IActionResult> PutItem(int id, CategoryUpdateDto categoryUpdateDto)
    {
        if (id != categoryUpdateDto.Id)
        {
            return BadRequest(); // id ler uyuşmazsa HTTP 400 bas request dönecek
        }

        var result = await _categoryService.PutItem(id, categoryUpdateDto);

        if (!result)
        {
            return NotFound(); // ürün bulunamazsa HTTP 404 not found döner 
        }
        
        return NoContent(); // HTTP 204 eklendi döndürür
    }
    
    [HttpDelete("{id:int}")] // delete api/Products/5
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _categoryService.DeleteItem(id);

        if (!result)
        {
            return NotFound(); // ürün bulunamadı 404 not found döncek 
        }
        
        return NoContent(); //HTTP 204 içeriksiz silindi. 
    }
    
}