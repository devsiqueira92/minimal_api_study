using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using MinimalAPI.Application.Utils.Token;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Domain.RepositoryInterface;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace MinimalAPI.Application.Utils.LoggedUser;

public class LoggedUser : ILoggedUser
{
    private readonly ITokenController _tokenController;
    private readonly UserManager<UserEntity> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IDistributedCache _cache;
    public LoggedUser(ITokenController tokenController, UserManager<UserEntity> userManager, IHttpContextAccessor httpContextAccessor, IUserInfoRepository userInfoRepository, IDistributedCache cache)
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

        var cachedUser = await _cache.GetStringAsync($"UserEntity:{userEmail}");

        if (!string.IsNullOrEmpty(cachedUser))
        {
            // If the user is in the cache, deserialize the cached value and return it
            var cachedValue = JsonSerializer.Deserialize<UserEntity>(cachedUser);
            return cachedValue;
        }

        //if (authorization is null || userEmail is null)
        //    throw new ValidationErrorsExceptions(ResourceErrorsMessage.INVALID_USER);

        var loggedUser = await _userManager.FindByEmailAsync(userEmail);
        if (loggedUser != null)
        {
            var cacheOptions = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(8)); // Cache the user for 8 minutes

            var serializedUser = JsonSerializer.Serialize(loggedUser);
            await _cache.SetStringAsync($"UserEntity:{userEmail}", serializedUser, cacheOptions);
        }

        return loggedUser;
    }
}
