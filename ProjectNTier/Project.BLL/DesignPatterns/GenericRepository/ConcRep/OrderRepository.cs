using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.DAL.Context;
using Project.ENTITIES.Models;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep;

public class OrderRepository:BaseRepository<Order>
{
    public OrderRepository(MyContext db) : base(db)
    {
    }
}