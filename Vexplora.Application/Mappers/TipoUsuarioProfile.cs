using AutoMapper;
using Vexplora.Domain.TipoUsuarios;

namespace Vexplora.Application.Mappers;

public class TipoUsuarioProfile : Profile
{
    public TipoUsuarioProfile()
    {
        CreateMap<TipoUsuario, TipoUsuarioDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.ToString()))
        .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre!))
        ;
    }
}