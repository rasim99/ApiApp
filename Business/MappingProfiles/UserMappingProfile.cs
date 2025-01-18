
using AutoMapper;
using Business.Dtos.User;
using Core.Entities;

namespace Business.MappingProfiles
{
    public class UserMappingProfile :Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User,UserDto>();
        }
    }
}
