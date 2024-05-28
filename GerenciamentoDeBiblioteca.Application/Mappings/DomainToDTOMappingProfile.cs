﻿using AutoMapper;
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
            CreateMap<Emprestimo, EmprestimoDTO>().ReverseMap()
                .ForMember(dest => dest.Livro, options => options.MapFrom(x => x.LivroDTO))
                .ForMember(dest => dest.Cliente, options => options.MapFrom(x => x.ClienteDTO));

        }
    }
}
