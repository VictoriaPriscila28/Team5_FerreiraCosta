using FluentValidation;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorios.Interface;
using GerenciamentoDeBiblioteca_core.Interface;

namespace GerenciamentoDeBiblioteca.Validacao
{
    public class EmprestimoValidacao : AbstractValidator<EmprestimoModel>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;

        public EmprestimoValidacao(IEmprestimoRepositorio emprestimoRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;

            RuleFor(emprestimo => emprestimo.UsuarioId)
                .MustAsync(async (usuarioId, cancellation) =>
                {
                    var emprestimosAtivos = await _emprestimoRepositorio.GetEmprestimoByUsuario(usuarioId);
                    return emprestimosAtivos.Count(e => e.DataDevolucao == null) < 3;
                })
                .WithMessage("O usuário não pode ter mais de 3 livros emprestados ao mesmo tempo.");
        }
    }
}
