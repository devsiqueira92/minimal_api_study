using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using MinimalAPI.Application.Utils.Token;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.RepositoryInterface;

namespace MinimalAPI.Application.Utils.LoggedUser;

public class LoggedUser : ILoggedUser
{
    private readonly ITokenController _tokenController;
    private readonly UserManager<UserEntity> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserInfoRepository _userInfoRepository;
    public LoggedUser(ITokenController tokenController, UserManager<UserEntity> userManager, IHttpContextAccessor httpContextAccessor, IUserInfoRepository userInfoRepository)
    {
        _tokenController = tokenController;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _userInfoRepository = userInfoRepository;
    }
    public async Task<UserEntity> GetUserFromToken()
    {

        return await GetUser();
    }

    public async Task<UserInfoEntity> GetUserInfoFromToken()
    {
        var internalUser = await GetUser();
        return await _userInfoRepository.GetAsync(user => user.UserEntityId == internalUser.Id);
    }

    private async Task<UserEntity> GetUser()
    {
        string authorization = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

        string token = authorization["Bearer".Length..].Trim();

        string userEmail = _tokenController.GetEmailFromToken(token);

        var loggedUser = await _userManager.FindByEmailAsync(userEmail);

        return loggedUser;
    }
}
