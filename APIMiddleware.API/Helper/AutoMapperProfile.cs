using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Entities;
using AutoMapper;

namespace APIMiddleware.API.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
