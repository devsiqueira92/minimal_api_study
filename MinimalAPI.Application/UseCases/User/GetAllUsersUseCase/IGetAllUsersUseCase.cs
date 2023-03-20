using MinimalAPI.Shared.Communication.Response;

namespace MinimalAPI.Application.UseCases.User.GetAllUsersUseCase;

public interface IGetAllUsersUseCase
{
    Task<IEnumerable<UserInfoResponse>> Execute();
}
