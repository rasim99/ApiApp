using AutoMapper;
using Business.Dtos.Auth;
using Core.Entities;
namespace Business.MappingProfiles
{
    public class UserRoleMappingProfile :Profile
    {
        public UserRoleMappingProfile()
        {
            CreateMap<AuthRegisterDto, User>()
                .ForMember(dest=>dest.UserName,opt=>opt.MapFrom(src=>src.Email));

        }
    }
}
