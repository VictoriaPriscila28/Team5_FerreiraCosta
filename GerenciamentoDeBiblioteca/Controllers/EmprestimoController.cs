using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoDeBiblioteca_core.Servicos;
using GerenciamentoDeBiblioteca_core.ModificarEntidades;
using GerenciamentoDeBiblioteca_infra.Interfaces;
using Newtonsoft.Json;
using System.Net;
using GerenciamentoDeBiblioteca.Respostas;
using GerenciamentoDeBiblioteca_core.ConsultaFiltro;
using GerenciamentoDeBiblioteca_core.Interface;
using GerenciamentoDeBiblioteca_core.DTOs;

namespace GerenciamentoDeBiblioteca.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly IServicoEmprestimo _servicoEmprestimo;
        private readonly IMapper _mapper;
        private readonly IServicoUri _servicoUri;
        private readonly object _servicoEmprestimos;
        private object emprestimo;

        public EmprestimoController(IServicoEmprestimo servicoEmprestimo, IMapper mapper, IServicoUri servicoUri)
        {
            _servicoEmprestimo = servicoEmprestimo;
            _mapper = mapper;
            _servicoUri = servicoUri;
        }


        /// <summary>
        /// Retorna todos os emprestimos
        /// </summary>
        /// <param name="filtro">Filtros para aplicar</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetEmprestimos))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RespostasApi<IEnumerable<EmprestimoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(RespostasApi<IEnumerable<EmprestimoDto>>))]
        public IActionResult GetEmprestimos([FromQuery] EmprestimoConsultaFiltro filtro)
        {
            var emprestimos = _servicoEmprestimos.GetEmprestimos(filtro);
            var emprestimosDtos = _mapper.Map<IEnumerable<EmprestimoDto>>(emprestimos);

            var Metadado = new Metadado
            {
                TotalRegistros = emprestimos.TotalRegistros,
                TamanhoPaginas = emprestimos.TamanhoPaginas,
                PaginaAtual = emprestimos.PaginaAtual,
                TotalPaginas = emprestimos.TotalPaginas,
                TemPaginaSeguinte = emprestimos.TemPaginaSeguinte,
                TemPaginaAnterior = emprestimos.TemPaginaAnterior
            };

            var resposta = new RespostasApi<IEnumerable<EmprestimoDto>>(emprestimosDtos)
            {
                Meta = Metadado
            };

            Response.Headers.Add("X-Paginacao", JsonConvert.SerializeObject(Metadado));

            return Ok(resposta);

        }

        /// <summary>
        /// Retorna os emprestimos por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmprestimos(int id)
        {
            var emprestimo = await _servicoEmprestimos.GetEmprestimos(id);
            var EmprestimoDto = _mapper.Map<EmprestimoDto>(emprestimo);
            var resposta = new RespostasApi<EmprestimoDto>(EmprestimoDto);
            return Ok(resposta);

        }

        /// <summary>
        /// Insere emprestimos
        /// </summary>
        /// <param name="EmprestimoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Emprestimo(EmprestimoDto EmprestimoDto)
        {
            var prestado = _mapper.Map<Emprestimo>(EmprestimoDto);

            await _servicoEmprestimo.InserirEmprestimo(emprestimo);

            EmprestimoDto = _mapper.Map<EmprestimoDto>(prestado);
            var resposta = new RespostasApi<EmprestimoDto>(EmprestimoDto);
            return Ok(resposta);

        }

        /// <summary>
        /// Atualiza emprestimos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="EmprestimoDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EmprestimosPut(int id, EmprestimoDto EmprestimoDto)
        {
            var prestado = _mapper.Map<Emprestimo>(EmprestimoDto);
            prestado.Id = id;

            var resultado = await _servicoEmprestimo.AtualizarEmprestimo(emprestimo);
            var resposta = new RespostasApi<bool>(resultado);
            return Ok(resposta);

        }

        /// <summary>
        /// Apaga o emprestimo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> ApagarEmprestimo(int id)
        {
            var resultado = await _servicoEmprestimo.ApagarEmprestimo(id);
            var resposta = new RespostasApi<bool>(resultado);
            return Ok(resposta);

        }


    }

}
