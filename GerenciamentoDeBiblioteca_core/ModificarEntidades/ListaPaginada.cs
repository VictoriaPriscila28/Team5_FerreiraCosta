using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.ModificarEntidades
{
   
        public class ListaPaginada<T> : List<T>
        {
            public int PaginaAtual { get; set; }
            public int TotalPaginas { get; set; }
            public int TamanhoPagina { get; set; }
            public int TotalRegistros { get; set; }

            public bool TemPaginaAnterior => PaginaAtual > 1;
            public bool TemPaginaSeguinte => PaginaAtual < TotalPaginas;
            public int? NumeroPaginaSeguinte => TemPaginaSeguinte ? PaginaAtual + 1 : (int?)null;
            public int? NumeroPaginaAnterior => TemPaginaAnterior ? PaginaAtual - 1 : (int?)null;

            public ListaPaginada(List<T> itens, int quantidade, int numeroPagina, int tamanhoPagina)
            {
                TotalRegistros = quantidade;
                TamanhoPagina = tamanhoPagina;
                PaginaAtual = numeroPagina;
                TotalPaginas = (int)Math.Ceiling(quantidade / (double)tamanhoPagina);

                AddRange(itens);
            }

            public static ListaPaginada<T> Criar(IEnumerable<T> origem, int numeroPagina, int tamanhoPagina)
            {
                var quantidade = origem.Count();
                var itens = origem.Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToList();

                return new ListaPaginada<T>(itens, quantidade, numeroPagina, tamanhoPagina);
            }
        }

    }

