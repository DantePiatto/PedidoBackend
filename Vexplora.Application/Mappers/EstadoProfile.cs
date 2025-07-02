using AutoMapper;
using Vexplora.Domain.Estados;

namespace Vexplora.Application.Mappers;

public class EstadoProfile : Profile
{
    public EstadoProfile()
    {
        CreateMap<Estado, EstadoDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.ToString()))
        .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre!))
        .ForMember(dest => dest.Tabla, opt => opt.MapFrom(src => src.Tabla!))
        ;
    }
}