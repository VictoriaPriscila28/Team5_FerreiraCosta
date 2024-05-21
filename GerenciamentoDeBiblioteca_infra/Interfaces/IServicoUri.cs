using GerenciamentoDeBiblioteca_core.ConsultaFiltro;
using System;

namespace GerenciamentoDeBiblioteca_infra.Interfaces
{
    public interface IServicoUri
    {
        Uri ObterPaginacaoEmprestimoUri(EmprestimoConsultaFiltro filtro, string acaoUri);

        Uri ObterPaginacaoEstudanteUri(UsuarioConsultaFiltro filtro, string acaoUri);

        Uri ObterPaginacaoLivroUri(LivroConsultaFiltro filtro, string acaoUri);
    }

}