using AutoMapper;
using SportAppNet.DTO;
using SportAppNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Tool
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserPostDTO, UserEntity>();
        }
    }
}
