using System.Linq.Expressions;
using Project.BLL.DTOs.Product;
using Project.ENTITIES.Models;

namespace Project.BLL.DesignPatterns.GenericRepository.IntRep;

public interface IRepository<T> where T : BaseEntity
{
    // List Commands 
    Task<List<T>> GetAll();

    Task<List<T>> GetActives();

    Task<List<T>> GetModifieds();

    Task<List<T>> GetDeleteds();


    //Modify Commands
    Task Add(ProductUpdateDto item);
    Task AddRange(List<T> list);
    Task Delete(T item); // pasife çekmek 
    Task DeleteRange(List<T> list);
    Task Update(T item);
    Task UpdateRange(List<T> list);
    Task Destroy(T item);
    Task DestroyRange(List<T> list);

    //Linq Command
    // _db.Products.Where(x=>x.ProductName.Contains("be").ToList;
    
    Task<List<T>> Where(Expression<Func<T,bool>> exp );

    Task<bool> Any(Expression<Func<T, bool>> exp);
    
    Task<T> FirstOrDefault(Expression<Func<T, bool>> exp);

    Task<object> Select(Expression<Func<T, object>> exp);

    Task<IQueryable<X>> Select<X>(Expression<Func<T, X>> exp);

 //Find Command

 Task<T?> Find(int id);

}