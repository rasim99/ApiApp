using AutoMapper;
using Business.Dtos.Auth;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles
{
    public class UserMappingProfile :Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AuthRegisterDto, User>()
                .ForMember(dest=>dest.UserName,opt=>opt.MapFrom(src=>src.Email));

        }
    }
}
