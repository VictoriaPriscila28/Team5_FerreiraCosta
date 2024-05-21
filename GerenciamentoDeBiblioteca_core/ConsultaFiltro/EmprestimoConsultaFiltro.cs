using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.ConsultaFiltro
{
    public class EmprestimoConsultaFiltro
    {
        public int? IdUsuario { get; set; }
        public int? IdLivro { get; set; }
        public DateTime? DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string Devolucao { get; set; }

        public DateTime? DataInicialEmprestimo { get; set; }
        public DateTime? PrazoDevolucao { get; set; }

        public int TamanhoPagina { get; set; }

        public int NumeroPagina { get; set; }
    }
}
