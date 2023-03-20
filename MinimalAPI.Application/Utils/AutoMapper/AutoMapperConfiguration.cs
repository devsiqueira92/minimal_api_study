using AutoMapper;
using MinimalAPI.Domain.Entities;
using MinimalAPI.Shared.Communication.Request;
using MinimalAPI.Shared.Communication.Response;

namespace VehicleManagement.Application.Utils.AutoMapper;

public class AutoMapperConfiguration : Profile
{

    public AutoMapperConfiguration()
    {
        RequestToEntity();
        EntidadeParaResposta();
    }

    private void RequestToEntity()
    {
        CreateMap<UserRegisterRequest, UserEntity>()
       .ForMember(from => from.NormalizedEmail, config => config.MapFrom(to => to.Email))
       .ForMember(from => from.PasswordHash, config => config.MapFrom(to => to.Password));
    }

    private void EntidadeParaResposta()
    {
        CreateMap<UserEntity, UserRegisterResponse>();
        CreateMap<UserInfoEntity, UserInfoResponse>();



    }
}
