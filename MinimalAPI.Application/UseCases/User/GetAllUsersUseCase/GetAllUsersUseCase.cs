using AutoMapper;
using MinimalAPI.Domain.RepositoryInterface;
using MinimalAPI.Shared.Communication.Response;

namespace MinimalAPI.Application.UseCases.User.GetAllUsersUseCase;

public class GetAllUsersUseCase : IGetAllUsersUseCase
{
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IMapper _mapper;
    public GetAllUsersUseCase(IUserInfoRepository userInfoRepository, IMapper mapper)
    {
        _userInfoRepository = userInfoRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserInfoResponse>> Execute()
    {
        var users = await _userInfoRepository.GetAllAsync();
        return _mapper.Map<List<UserInfoResponse>>(users);
    }
}
