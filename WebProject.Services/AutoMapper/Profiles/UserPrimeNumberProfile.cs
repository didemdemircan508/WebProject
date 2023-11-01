using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Entities.Dtos;
using WebProject.Entities.Entities.Entity;
using WebProject.Entities.Entities.Identity;

namespace WebProject.Services.AutoMapper.Profiles
{
    public class UserPrimeNumberProfile: Profile
    {
        public UserPrimeNumberProfile()
        {
           CreateMap<UserPrimeAddDto, UserPrimeNumber>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
           CreateMap<UserPrimeDto,UserPrimeNumber>().ReverseMap();

        }
    }
}
