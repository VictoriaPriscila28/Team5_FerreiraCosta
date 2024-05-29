using GerenciamentoDeBiblioteca.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Application.Interfaces
{
    public interface ISistemaService
    {
        Task<QuantidadeItensDTO> SelecionarQtdItens();
    }
}
