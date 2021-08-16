using AutoMapper;
using APIMiddleware.Core.Entities;
using APIMiddleware.Core.DTO;

namespace APIMiddleware.Core.Helper
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
