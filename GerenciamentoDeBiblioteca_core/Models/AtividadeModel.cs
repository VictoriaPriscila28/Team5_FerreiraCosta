using GerenciamentoDeBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.Models
{
    public class AtividadeModel
    {
        public class Atividade
        {
            public int Id { get; set; }
            public int UsuarioId { get; set; }
            public int LivroId { get; set; }
            public DateTime Data { get; set; }
            public string Tipo { get; set; } // "Empréstimo" ou "Devolução"
            public bool MultaAplicada { get; set; } // Indica se houve multa
            public decimal ValorMulta { get; set; } // Valor da multa, se aplicável

            // Relacionamento com Usuario, se necessário
            public UsuarioModel Usuario { get; set; }
        }

    }
}
