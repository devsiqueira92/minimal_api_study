using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MinimalAPI.Application.Utils.Token;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Shared.Communication.Request;
using MinimalAPI.Shared.Communication.Response;

namespace MinimalAPI.Application.UseCases.User.RegisterUserUseCase;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly UserManager<UserEntity> _userManager; 
    private readonly ITokenController _tokenController;
    private readonly IMapper _mapper;
    public RegisterUserUseCase(IMapper mapper,
            UserManager<UserEntity> userManager, ITokenController tokenController)
    {
        _mapper = mapper;
        _userManager = userManager;
        _tokenController = tokenController;
    }
    public async Task<UserRegisterResponse> Execute(UserRegisterRequest request)
    {
        UserEntity entity = _mapper.Map<UserEntity>(request);

        IdentityResult isCreated = await _userManager.CreateAsync(entity, entity.PasswordHash);

        string token = _tokenController.GenerateToken(entity.Email);

        return new UserRegisterResponse
        {
            Token = token,
            Email = entity.Email
        };
    }
}
