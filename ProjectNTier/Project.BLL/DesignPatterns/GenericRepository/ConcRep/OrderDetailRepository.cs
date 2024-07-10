using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.DAL.Context;
using Project.ENTITIES.Models;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep;

public class OrderDetailRepository:BaseRepository<OrderDetail>
{
    public OrderDetailRepository(MyContext db) : base(db)
    {
    }
}