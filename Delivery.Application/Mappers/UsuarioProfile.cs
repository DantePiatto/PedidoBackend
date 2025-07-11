
using AutoMapper;
using Delivery.Domain.Usuarios;

namespace Delivery.Application.Mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.Value.ToString()))
            .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo!))
            .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Nombres!))
            .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.Apellidos!))
            .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni!))
            .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.Celular!))
            .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo!))
            .ForMember(dest => dest.IsDefaultPassword, opt => opt.MapFrom(src => src.IsDefaultPassword!))
            .ForMember(dest => dest.IsCelularVerificado, opt => opt.MapFrom(src => src.IsCelularVerificado!))
            .ForMember(dest => dest.IsEmailVerificado, opt => opt.MapFrom(src => src.IsEmailVerificado!))

            // .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rol!))
            // .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.RolId!.Value))
            // .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente!))
            // .ForMember(dest => dest.Empleado, opt => opt.MapFrom(src => src.Empleado!))
            ;


            // CreateMap<Usuario, EmpleadoUsuarioDto>()
            // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.Value.ToString()))
            // .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo!))
            // .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Nombres!))
            // .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.Apellidos!))
            // .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni!))
            // .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.Celular!))
            // .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo!))
            // .ForMember(dest => dest.IsDefaultPassword, opt => opt.MapFrom(src => src.IsDefaultPassword!))
            // .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rol!))
            // .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.RolId!.Value))
            // ;

            // CreateMap<Usuario, ClienteUsuarioDto>()
            // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id!.Value.ToString()))
            // .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo!))
            // .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Nombres!))
            // .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.Apellidos!))
            // .ForMember(dest => dest.Dni, opt => opt.MapFrom(src => src.Dni!))
            // .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.Celular!))
            // .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo!))
            // .ForMember(dest => dest.IsDefaultPassword, opt => opt.MapFrom(src => src.IsDefaultPassword!))
            // .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rol!))
            // .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.RolId!.Value))
            // ;

        }
    }
}