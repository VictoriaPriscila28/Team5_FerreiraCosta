using GerenciamentoDeBiblioteca.Core.Models;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca_core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace GerenciamentoDeBiblioteca_infra.Profile
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // Definir os mapeamentos
            CreateMap<UsuarioModel, UsuarioDto>();
            CreateMap<UsuarioDto, UsuarioModel>();

            CreateMap<LivroModel, LivroDto>();
            CreateMap<LivroDto, LivroModel>();

            CreateMap<Emprestimos, EmprestimoDto>();
            CreateMap<EmprestimoDto, Emprestimos>();
        }
    }
}
