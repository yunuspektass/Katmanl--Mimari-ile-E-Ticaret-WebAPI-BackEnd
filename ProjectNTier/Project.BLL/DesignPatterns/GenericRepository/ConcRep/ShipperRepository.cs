using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.DAL.Context;
using Project.ENTITIES.Models;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep;

public class ShipperRepository:BaseRepository<Shipper>
{
    public ShipperRepository(MyContext db) : base(db)
    {
    }
}