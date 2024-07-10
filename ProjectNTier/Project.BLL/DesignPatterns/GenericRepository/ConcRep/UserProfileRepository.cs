using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.DAL.Context;
using Project.ENTITIES.Models;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep;

public class UserProfileRepository:BaseRepository<AppUserProfile>
{
    public UserProfileRepository(MyContext db) : base(db)
    {
    }
}