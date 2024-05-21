using GerenciamentoDeBiblioteca_core.ConsultaFiltro;
using GerenciamentoDeBiblioteca_core.ModificarEntidades;
using GerenciamentoDeBiblioteca_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca_core.Interface
{
    public interface IServicoUsuario
    {
        ListaPaginada<UsuarioModel> GetUsuario(UsuarioConsultaFiltro filtro);

        Task<UsuarioModel> GetUsuario(int id);

        Task InserirUsuario(UsuarioModel usuario);

        Task<bool> AtualizarUsuario(UsuarioModel usuario);

        Task<bool> ApagarUsuario(int id);
    }
}


