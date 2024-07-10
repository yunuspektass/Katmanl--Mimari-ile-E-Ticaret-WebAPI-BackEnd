using AutoMapper;
using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.BLL.DTOs.Product;
using Project.ENTITIES.Models;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcManager;

public class ProductManager:IProductService
{
    private readonly ProductRepository _productRepository;
    private readonly IMapper _autoMapper;
    private readonly IMailService _mailService;
    
    public ProductManager(ProductRepository productRepository , IMapper autoMapper , IMailService mailService)
    {
        _autoMapper = autoMapper; 
        _productRepository = productRepository;
        _mailService = mailService;
        // ProductRepository bağımlılığını _productRepository de kullanmak için atama yaptık

    }

    public async Task<IEnumerable<ProductGetDto>> GetProducts()
    {
        var products = await _productRepository.GetItems(); // tüm ürünleri asenkron aldık
        var productDto = _autoMapper.Map<List<ProductGetDto>>(products);
        return productDto; 
    }

   public async Task<ProductGetDto> GetProduct(int id)
    {
        // verdiğimiz id'ye göre ürünü asenkron getirir.
        var product = await _productRepository.GetItem(id);

        if (product == null)
        {
            return null; // ürün bulunmazsa HTTP 404 dönecek 
        }

        var productDto = _autoMapper.Map<ProductGetDto>(product);

        return productDto;
    }

   

    public async Task<ProductCreateDto> PostProduct(ProductCreateDto productCreateDto)
    {
        var product = _autoMapper.Map<Product>(productCreateDto);
        // yeni ürünü veritabanına asenkron olarak ekler
        await _productRepository.Add(product);

        var resultDto = _autoMapper.Map<ProductCreateDto>(product);
        
        await _mailService.SendEmailAsync("test@gmail.com", "Ürün Eklendi",
            productCreateDto.ProductName + " İsimli ürün listenize eklenmiştir.");
        
        return resultDto;
    }

    public async Task<bool> PutProduct(int id, ProductUpdateDto productUpdateDto)
    {
       
        var existingProduct = await _productRepository.GetItem(id);

        if (existingProduct == null)
        {
            return false;
        }

        existingProduct.ProductName = productUpdateDto.ProductName;
        existingProduct.UnitPrice = productUpdateDto.UnitPrice;
        existingProduct.CategoryID = productUpdateDto.CategoryID;
        
        
        // _autoMapper.Map(productDto, existingProduct);
        
        await _productRepository.Update(existingProduct);

        await _mailService.SendEmailAsync("test@gmail.com", "Ürün Güncelleme",
            productUpdateDto.ID + " Numaralı ürün listenizde güncellenmiştir.");
        
        return true;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var existingProduct = await _productRepository.Find(id);

        if (existingProduct == null)
        {
            return false;
        }

        await _productRepository.Delete(existingProduct);
      
        await _mailService.SendEmailAsync("test@gmail.com", "Ürün Silindi",
            id + " Numaralı ürün listenizden silinmiştir");
        
        return true;
    }
}