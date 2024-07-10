using AutoMapper;
using Project.BLL.DTOs.Category;
using Project.ENTITIES.Models;

namespace Project.BLL.Mapper;

public class MappingCategory:Profile
{
    public MappingCategory()
    {
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryGetDto>().ReverseMap();
    }
}