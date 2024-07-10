using Microsoft.EntityFrameworkCore;
using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.DAL.Context;
using Project.ENTITIES.Models;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep;

public class ProductRepository:BaseRepository<Product>
{
    private MyContext _db; 
    /*public ProductRepository(MyContext db) : base(db)
    {
    }*/
    public ProductRepository(MyContext myContext):base(myContext)
    {
        _db = myContext;
    }
    public async Task<IEnumerable<Product>> GetItems()
    {
        return await _db.Products.Include(c => c.Category).ToListAsync();
    }
    
    public async Task<Product?> GetItem(int id)
    {
        return await _db.Products.Include(c => c.Category).SingleOrDefaultAsync(c => c.ID == id);
    }

}