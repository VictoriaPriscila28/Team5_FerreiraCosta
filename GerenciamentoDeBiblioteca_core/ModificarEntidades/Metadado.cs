using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.ModificarEntidades
{
    public class Metadado
    {
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanhoPaginas { get; set; }
        public int TotalRegistros { get; set; }
        public bool TemPaginaAnterior { get; set; }
        public bool TemPaginaSeguinte { get; set; }
       
    }
}

