using MinimalAPI.Shared.Communication.Request;
using MinimalAPI.Shared.Communication.Response;

namespace MinimalAPI.Application.UseCases.User.RegisterUserUseCase;

public interface IRegisterUserUseCase
{
    Task<UserRegisterResponse> Execute(UserRegisterRequest request);
}
