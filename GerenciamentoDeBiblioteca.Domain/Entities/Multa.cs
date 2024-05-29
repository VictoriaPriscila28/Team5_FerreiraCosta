using GerenciamentoDeBiblioteca.Domain.Validations;
using System;

namespace GerenciamentoDeBiblioteca.Domain.Entities
{
    public class Multa
    {
        public int Id { get; private set; }
        public int DiasAtraso { get; private set; }
        public decimal ValorMulta { get; private set; }
        public int EmprestimoId { get; private set; }
        public Emprestimo Emprestimo { get; private set; }

       
        public Multa(int id, int diasAtraso, decimal valorMulta, int emprestimoId)
        {
            DomainExceptionValidation.When(id < 0, "O id da multa deve ser positivo");
            Id = id;
            ValidateDomain(diasAtraso, valorMulta, emprestimoId);
        }

       
        public Multa(int diasAtraso, decimal valorMulta, int emprestimoId)
        {
            ValidateDomain(diasAtraso, valorMulta, emprestimoId);
        }

        public void Update(int diasAtraso, decimal valorMulta, int emprestimoId)
        {
            ValidateDomain(diasAtraso, valorMulta, emprestimoId);
        }

        private void ValidateDomain(int diasAtraso, decimal valorMulta, int emprestimoId)
        {
            DomainExceptionValidation.When(diasAtraso < 0, "Os dias de atraso devem ser não-negativos");
            DomainExceptionValidation.When(valorMulta < 0, "O valor da multa deve ser não-negativo");
            DomainExceptionValidation.When(emprestimoId < 0, "O id do empréstimo deve ser positivo");

            DiasAtraso = diasAtraso;
            ValorMulta = valorMulta;
            EmprestimoId = emprestimoId;
        }
    }
}
