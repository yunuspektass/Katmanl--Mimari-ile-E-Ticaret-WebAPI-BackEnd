using Project.BLL.DTOs.Category;

namespace Project.BLL.DesignPatterns.GenericRepository.BaseRep;

public interface ICategoryService
{
    Task<IEnumerable<CategoryGetDto>>  GetList();
    Task<CategoryGetDto> GetItem(int id);

    Task<CategoryCreateDto> PostItem(CategoryCreateDto categoryCreateDto);

    Task<bool> PutItem(int id, CategoryUpdateDto categoryUpdateDto);

    Task<bool> DeleteItem(int id);
}