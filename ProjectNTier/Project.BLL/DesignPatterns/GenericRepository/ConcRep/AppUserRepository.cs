using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.DAL.Context;
using Project.ENTITIES.Models;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep;

public class AppUserRepository:BaseRepository<AppUser>
{
    public AppUserRepository(MyContext db) : base(db)
    {
    }
}