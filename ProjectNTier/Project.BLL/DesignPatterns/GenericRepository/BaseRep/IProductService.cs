using Project.BLL.DTOs.Product;

namespace Project.BLL.DesignPatterns.GenericRepository.BaseRep;

public interface IProductService
{
   Task<IEnumerable<ProductGetDto>>  GetProducts();
   Task<ProductGetDto> GetProduct(int id);

   Task<ProductCreateDto> PostProduct(ProductCreateDto productUpdateDto);

   Task<bool> PutProduct(int id, ProductUpdateDto productUpdateDto);

   Task<bool> DeleteProduct(int id);
}
