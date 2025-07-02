using AutoMapper;
using Vexplora.Domain.Usuarios;

namespace Vexplora.Application.Mappers;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Usuario, UsuarioDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.ToString()))
        .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Email!))
        .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Nombre!))
        .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.Apellido!))
        .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.NroDocumento!))
        .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.RutaDocumento!))
        .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.FechaCreacion!))
        .ForMember(dest => dest.IsDefaultPassword, opt => opt.MapFrom(src => src.RecibeNotificaciones!))
        ;
    }
}