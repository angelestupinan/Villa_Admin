using AutoMapper;
using VillaAPI.Models;
using VillaAPI.Models.DTO;

namespace VillaAPI
{
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {
            //primero la clase de origen y luego la de destino
            CreateMap<Villa, VillaDto>();
            CreateMap<VillaDto, Villa>();

            CreateMap<Villa, VillaCreateDto>().ReverseMap();//si se utiliza esa segundo metodo, se puede hacer todo en una sola linea

            CreateMap<Villa, VillaUpdateDto>().ReverseMap();
        }
    }
}
