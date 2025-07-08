

using AutoMapper;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Mappers

{

    public class RestauranteProfile : Profile
    {

        public RestauranteProfile()
        {

            CreateMap<Restaurante, RestauranteDto>()
            .ForMember(re => re.Id, op => op.MapFrom(src => src.Id!.Value.ToString()))
            .ForMember(re => re.Nombre, op => op.MapFrom(src => src.Nombre!))
            .ForMember(re => re.Descripcion, op => op.MapFrom(src => src.Descripcion!))
            .ForMember(re => re.LogoUrl, op => op.MapFrom(src => src.LogoUrl!))
            .ForMember(re => re.TiempoEntrega, op => op.MapFrom(src => src.TiempoEntrega!))
            .ForMember(re => re.Activo, op => op.MapFrom(src => src.Activo!.Value));

            


        }

    }

    
}

