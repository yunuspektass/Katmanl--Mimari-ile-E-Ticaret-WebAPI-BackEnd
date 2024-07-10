using AutoMapper;
using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.BLL.DTOs.Category;
using Project.ENTITIES.Models;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcManager;

public class CategoryManager:ICategoryService
{
    private readonly CategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;


    public CategoryManager(CategoryRepository categoryRepository , IMapper mapper , IMailService mailService)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _mailService = mailService;
    }
    
    public async Task<IEnumerable<CategoryGetDto>> GetList()
    {
        var categories = await _categoryRepository.GetItems();

        return _mapper.Map<IEnumerable<CategoryGetDto>>(categories); 
    }

    public async Task<CategoryGetDto> GetItem(int id)
    {
        var category = await _categoryRepository.GetItem(id);

        return _mapper.Map<CategoryGetDto>(category);
    }

    public async Task<CategoryCreateDto> PostItem(CategoryCreateDto categoryCreateDto)
    {
        var category = _mapper.Map<Category>(categoryCreateDto);

        await _categoryRepository.Add(category);
        
        await _mailService.SendEmailAsync("test@gmail.com", "Kategori Ekleme",
            category.CategoryName + " İsimli kategori listenize eklenmiştir.");
        
        return _mapper.Map<CategoryCreateDto>(category);
    }

    public async Task<bool> PutItem(int id, CategoryUpdateDto categoryUpdateDto)
    {
        var existingCategory = await _categoryRepository.GetItem(id);

        if (existingCategory == null)
        {
            return false;
        }


        existingCategory.CategoryName = categoryUpdateDto.CategoryName;
        existingCategory.Description = categoryUpdateDto.Description;

        await _categoryRepository.Update(existingCategory);
        
        await _mailService.SendEmailAsync("test@gmail.com", "Kategori Güncellendi",
            id + " Numaralı kategori listenizde güncellenmiştir");
        
        return true;
    }

    public async Task<bool> DeleteItem(int id)
    {
        var existingCategory = await _categoryRepository.Find(id);

        if (existingCategory == null)
        {
            return false;
        }

        await _categoryRepository.Delete(existingCategory);

        await _mailService.SendEmailAsync("test@gmail.com", "Kategori Silindi",
            id + " Numaralı kategori listenizden silinmiştir");
        
        return true;

    }
}