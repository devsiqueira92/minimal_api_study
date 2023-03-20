using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.RepositoryInterface;
using MinimalAPI.Infrastructure.Context;

namespace MinimalAPI.Infrastructure.Repository;

public class UserInfoRepository : BaseRepository<UserInfoEntity>, IUserInfoRepository
{
    private readonly UserContext _db;
    public UserInfoRepository(UserContext db) : base(db)
    {
        _db = db;
    }
}
