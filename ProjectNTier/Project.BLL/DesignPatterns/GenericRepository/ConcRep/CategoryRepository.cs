using Microsoft.EntityFrameworkCore;
using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.DAL.Context;
using Project.ENTITIES.Models;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep;

public class CategoryRepository:BaseRepository<Category>
{
    private MyContext _db;
    public CategoryRepository(MyContext db) : base(db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<Category>> GetItems()
    {
        return await _db.Categories.Include(p => p.Products).ToListAsync();
    }
 
    public async Task<Category?> GetItem(int id)
    {
        return await _db.Categories.Include(p => p.Products).SingleOrDefaultAsync(p => p.ID == id);
    }
}