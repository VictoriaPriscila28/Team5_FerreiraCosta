using AutoMapper;
using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Livro, LivroDTO>().ReverseMap();
            CreateMap<EmprestimoDTO, Emprestimo>().ReverseMap()
                .ForMember(dest => dest.LivroDTO, options => options.MapFrom(x => x.Livro))
                .ForMember(dest => dest.ClienteDTO, options => options.MapFrom(x => x.Cliente));
            CreateMap<Emprestimo, EmprestimoPostDTO>().ReverseMap();

        }
    }
}
