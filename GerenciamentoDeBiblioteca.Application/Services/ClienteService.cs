using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Application.Services
{
    public class ClienteService : IClienteService
    {
        public Task<ClienteDTO> Alterar(ClienteDTO clienteDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO> Incluir(ClienteDTO clienteDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO> SelecionarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO> SelecionarByCpfAsync(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteDTO>> SelecionarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
