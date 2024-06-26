﻿using GerenciamentoDeBiblioteca.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Domain.Entities
{
    public class Emprestimo
    {
        public int Id { get; private set; }
        public int IdCliente { get; private set; }
        public int IdLivro { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public bool Entregue { get; private set; }
        public Cliente Cliente { get; private set; }
        public Livro Livro { get; private set; }
        public ICollection<Multa> Multas { get; set; }


        public Emprestimo(int id, int idCliente, DateTime dataEmprestimo,
            DateTime dataEntrega, bool entregue)
        {
            DomainExceptionValidation.When(id < 0, "O Id do empréstimo deve ser positivo.");
            Id = id;
            ValidateDomain(idCliente, dataEmprestimo,dataEntrega, entregue);
        }

        public Emprestimo(int idCliente, DateTime dataEmprestimo,
            DateTime dataEntrega, bool entregue)
        {
            ValidateDomain(idCliente, dataEmprestimo, dataEntrega, entregue);
        }

        public void Update(int idCliente, DateTime dataEmprestimo, DateTime dataEntrega, bool entregue)
        {
            ValidateDomain(idCliente, dataEmprestimo, dataEntrega, entregue);
        }

        public void ValidateDomain(int idCliente, DateTime dataEmprestimo,
            DateTime dataEntrega, bool entregue)
        {
            DomainExceptionValidation.When(idCliente <= 0, "O Id do cliente deve ser maior que 0.");
            

            IdCliente = idCliente;  
            DataEmprestimo = dataEmprestimo;
            DataEntrega = dataEntrega;
            Entregue = entregue;
        }

    }
}
