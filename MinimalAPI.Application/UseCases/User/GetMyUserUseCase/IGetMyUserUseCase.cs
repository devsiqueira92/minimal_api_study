using MinimalAPI.Shared.Communication.Response;

namespace MinimalAPI.Application.UseCases.User.GetMyUserUseCase;

public interface IGetMyUserUseCase
{
    Task<UserInfoResponse> GetMyUser();
}
