
using AutoMapper;
using MinimalAPI.Application.Utils.LoggedUser;
using MinimalAPI.Shared.Communication.Response;

namespace MinimalAPI.Application.UseCases.User.GetMyUserUseCase;

public class GetMyUserUseCase : IGetMyUserUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IMapper _mapper;
    public GetMyUserUseCase(IMapper mapper, ILoggedUser loggedUser)
    {
        _mapper = mapper;
        _loggedUser = loggedUser;
    }
    public async Task<UserInfoResponse> GetMyUser()
    {
        var loggedUser = await _loggedUser.GetUserInfoFromToken();

        return _mapper.Map<UserInfoResponse>(loggedUser);
    }
}
