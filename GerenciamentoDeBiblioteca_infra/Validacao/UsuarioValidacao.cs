using FluentValidation;
using GerenciamentoDeBiblioteca_core.DTOs;
using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca_infra.Validacao
{
    public class UsuarioValidacao : AbstractValidator<UsuarioModel>
    {
        public UsuarioValidacao()
        {
            RuleFor(usuario => usuario.Nome)
                .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
                .Length(2, 50).WithMessage("O nome do usuário deve ter entre 2 e 50 caracteres.");

            RuleFor(usuario => usuario.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail deve ser válido.");

            RuleFor(usuario => usuario.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .Must(BeAValidAge).WithMessage("O usuário deve ter pelo menos 18 anos.");

            
        }

        private bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int birthYear = date.Year;
            return currentYear - birthYear >= 18;
        }
    }
}

