
using AutoMapper;
using Delivery.Domain.Productos;

namespace Delivery.Application.Mappers

{

    public class ProductoProfile : Profile
    {

        public ProductoProfile()
        {

            CreateMap<Producto, ProductoDto>()
            .ForMember(re => re.Id, op => op.MapFrom(src => src.Id!.Value.ToString()))
            .ForMember(re => re.RestauranteId, op => op.MapFrom(src => src.RestauranteId!.Value.ToString()))
            .ForMember(re => re.CategoriaId, op => op.MapFrom(src => src.CategoriaId!.Value.ToString()))
            .ForMember(re => re.Nombre, op => op.MapFrom(src => src.Nombre!))
            .ForMember(re => re.Descripcion, op => op.MapFrom(src => src.Descripcion!))
            .ForMember(re => re.Precio, op => op.MapFrom(src => src.Precio!))
            .ForMember(re => re.ImagenUrl, op => op.MapFrom(src => src.ImagenUrl!))
            .ForMember(re => re.Activo, op => op.MapFrom(src => src.Activo!.Value));

            


        }

    }

    
}