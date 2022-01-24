using AutoMapper;
using SuperTraders.Core.DTOs;
using SuperTraders.Core.Entities;

namespace SuperTraders.Core.Mapper
{
    public class MapperAuto : Profile
    {
        public MapperAuto()
        {
            CreateMap<SignUpDto, User>();
           
        }
    }
}
