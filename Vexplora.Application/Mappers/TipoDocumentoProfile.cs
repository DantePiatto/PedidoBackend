using AutoMapper;
using Vexplora.Domain.TipoDocumentos;

namespace Vexplora.Application.Mappers;

public class TipoDocumentoProfile : Profile
{
    public TipoDocumentoProfile()
    {
        CreateMap<TipoDocumento, TipoDocumentoDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.ToString()))
        .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre!))
        ;
    }
}