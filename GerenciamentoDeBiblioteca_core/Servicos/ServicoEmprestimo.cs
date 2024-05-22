using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorios.Interface;
using GerenciamentoDeBiblioteca.Servicos.Interface;
using GerenciamentoDeBiblioteca_core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Servicos
{
    public class ServicoEmprestimo : IServicoEmprestimo
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;

        public ServicoEmprestimo(IEmprestimoRepositorio emprestimoRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
        }

        public async Task<EmprestimoModel> RegistrarEmprestimo(EmprestimoModel emprestimo)
        {
            // Regras de negócio, como verificar se o usuário já possui 3 livros emprestados
            var emprestimosUsuario = await _emprestimoRepositorio.GetEmprestimoByUsuario(emprestimo.UsuarioId);
            if (emprestimosUsuario.Count() >= 3)
            {
                throw new InvalidOperationException("O usuário já possui 3 livros emprestados.");
            }

            await _emprestimoRepositorio.Inserir(emprestimo);
            return emprestimo;
        }

        public async Task<bool> RegistrarDevolucao(int idEmprestimo)
        {
            return await _emprestimoRepositorio.RegistrarDevolucao(idEmprestimo);
        }

        public async Task<IEnumerable<EmprestimoModel>> ObterEmprestimosPorUsuario(int usuarioId)
        {
            return await _emprestimoRepositorio.GetEmprestimoByUsuario(usuarioId);
        }

        public async Task<IEnumerable<EmprestimoModel>> ObterEmprestimosPorLivro(int livroId)
        {
            return await _emprestimoRepositorio.GetEmprestimoByLivro(livroId);
        }
    }
}
