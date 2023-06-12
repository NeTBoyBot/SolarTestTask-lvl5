using AutoMapper;
using SolarTestTask_lvl5.Contracts.User;
using SolarTestTask_lvl5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarTestTask_lvl5.Infrastructure.MapProfiles
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<User,InfoUserResponse>().ReverseMap();
            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<User, EditUserRequest>().ReverseMap();
        }
    }
}
