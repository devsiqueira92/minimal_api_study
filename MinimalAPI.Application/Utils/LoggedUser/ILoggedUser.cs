using MinimalAPI.Domain.Entities;

namespace MinimalAPI.Application.Utils.LoggedUser;

public interface ILoggedUser
{
    Task<UserEntity> GetUserFromToken();
    Task<UserInfoEntity> GetUserInfoFromToken();
}
