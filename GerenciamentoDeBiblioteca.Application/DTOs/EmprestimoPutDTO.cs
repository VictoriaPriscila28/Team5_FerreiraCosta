using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Application.DTOs
{
    public class EmprestimoPutDTO
    {
        [Required(ErrorMessage ="O identificador do empréstimo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage ="O identificador do empréstimo é inválido.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "A data de entrega é obrigatória.")]
        public DateTime DataEntrega { get; set; }
        [Required(ErrorMessage = "O status da entrega é obrigatório.")]
        public bool Entregue { get; set; }
    }
}
