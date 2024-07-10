using AutoMapper;
using Project.BLL.DTOs.Product;
using Project.ENTITIES.Models;

namespace Project.BLL.Mapper;

public class MappingProduct : Profile
{
    public MappingProduct()
    {
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
        
        CreateMap<Product , ProductGetDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        
    }
        
}