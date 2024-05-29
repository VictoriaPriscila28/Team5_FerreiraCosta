using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeBiblioteca.Application.DTOs
{
    public class MultaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo dias de atraso é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O campo dias de atraso deve ser um número inteiro não negativo.")]
        public int DiasAtraso { get; set; }

        [Required(ErrorMessage = "O campo valor da multa é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O campo valor da multa deve ser um número não negativo.")]
        public decimal ValorMulta { get; set; }

        [Required(ErrorMessage = "O campo ID do empréstimo é obrigatório.")]
        public int EmprestimoId { get; set; }
    }
}
