using AutoMapper;
using REST.Demo.DTO;
using REST.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Demo.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<CreateUserDto, User>();

            CreateMap<UpdateUserDto, User>();
        }
    }
}
