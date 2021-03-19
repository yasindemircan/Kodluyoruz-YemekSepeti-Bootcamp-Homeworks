using System;
using AutoMapper;
using hotels.API.Entities;
using hotels.API.Models;
using hotels.API.Models.Derived;

namespace hotels.API.Infrastructure
{
    public class MappingProfile:Profile
    {
        public MappingProfile(){
           CreateMap<RoomEntity, Room>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate / 100));
            CreateMap<UserEntity, UserInfo>()
                .ForMember(desc => desc.FullName, opt => opt.MapFrom(src => string.Concat(src.Name,src.SurName)));
        }
        
    }
}
