using FluentValidation;
using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca.Validacao
{
    public class LivroValidacao : AbstractValidator<LivroModel>
    {
        public LivroValidacao()
        {
            RuleFor(livro => livro.Titulo)
                .NotEmpty().WithMessage("O título do livro é obrigatório.")
                .MaximumLength(100).WithMessage("O título do livro deve ter no máximo 100 caracteres.");

            RuleFor(livro => livro.Autor)
                .NotEmpty().WithMessage("O autor do livro é obrigatório.")
                .MaximumLength(50).WithMessage("O autor do livro deve ter no máximo 50 caracteres.");

            

            RuleFor(livro => livro.AnoPublicacao)
                .InclusiveBetween(1900, DateTime.Now.Year).WithMessage("O ano de publicação deve ser entre 1900 e o ano atual.");

            RuleFor(livro => livro.Categoria)
                .NotEmpty().WithMessage("A categoria do livro é obrigatória.")
                .MaximumLength(50).WithMessage("A categoria do livro deve ter no máximo 50 caracteres.");
        }
    }
}
