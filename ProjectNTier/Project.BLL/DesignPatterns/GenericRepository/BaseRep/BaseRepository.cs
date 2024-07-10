using System.Linq.Expressions;
using Project.BLL.DesignPatterns.GenericRepository.IntRep;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using Project.BLL.DTOs.Product;


namespace Project.BLL.DesignPatterns.GenericRepository.BaseRep;

public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly MyContext _db;

    protected BaseRepository(MyContext db)
    {
        _db = db;
    }


    async Task  Save()
    {
        await _db.SaveChangesAsync();
    }


    public async Task<List<T>> GetAll()
    {
        return  await _db.Set<T>().ToListAsync();
    }

    public async Task<List<T>> GetActives()
    {
        return await Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
    }

    public async Task<List<T>> GetModifieds()
    {
        return await Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated);
    }

    public async Task<List<T>> GetDeleteds()
    {
        return await Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
    }

    public Task Add(ProductUpdateDto item)
    {
        throw new NotImplementedException();
    }


    public async Task Add(T item)
    {
      await  _db.Set<T>().AddAsync(item);
      await  _db.SaveChangesAsync();
    }

    public async Task AddRange(List<T> list)
    {
     await   _db.Set<T>().AddRangeAsync(list);
     await   _db.SaveChangesAsync();
    }

    public async Task Delete(T item)
    {
        item.Status = ENTITIES.Enums.DataStatus.Deleted;
        item.DeletedDate = DateTime.UtcNow;
        item.Deleted = true;
       await Save();
    }

    public async Task DeleteRange(List<T> list)
    {
        foreach (T item in list)
        {
            await Delete(item);
        }
    }

    public async Task Update(T item)
    {
        item.Status = ENTITIES.Enums.DataStatus.Updated;
        item.ModifiedDate = DateTime.UtcNow;
       T? unchangedEntity = await Find(item.ID);
        _db.Entry(unchangedEntity).CurrentValues.SetValues(item);
      await Save();
    }

    public async Task UpdateRange(List<T> list)
    {
        foreach (T item in list )
        {
            await Update(item);
        }
    }

    public async Task Destroy(T item)
    {
         _db.Set<T>().Remove(item);
        await Save();
    }

    public async Task DestroyRange(List<T> list)
    {
        _db.Set<T>().RemoveRange(list);
      await Save();
    }

    public async Task<List<T>> Where(Expression<Func<T, bool>> exp)
    {
        return await _db.Set<T>().Where(exp).ToListAsync();
    }

    public async Task<bool> Any(Expression<Func<T, bool>> exp)
    {
        return await _db.Set<T>().AnyAsync(exp);
    }

    public async Task<T> FirstOrDefault(Expression<Func<T, bool>> exp)
    {
        return await _db.Set<T>().FirstOrDefaultAsync(exp);
    }

    public async Task<object> Select(Expression<Func<T, object>> exp)
    {
        return _db.Set<T>().Select(exp);
    }

    public async Task<IQueryable<X>> Select<X>(Expression<Func<T, X>> exp)
    {
        return  _db.Set<T>().Select(exp);
    }   

    public async Task<T?> Find(int id)
    {
        return await _db.Set<T>().FirstOrDefaultAsync(x => x.ID == id);
    }
}