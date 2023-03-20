using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.RepositoryInterface;
using MinimalAPI.Infrastructure.Context;

namespace MinimalAPI.Infrastructure.Repository;

public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    private readonly UserContext _db;
    public UserRepository(UserContext db) : base(db)
    {
        _db = db;
    }
}
