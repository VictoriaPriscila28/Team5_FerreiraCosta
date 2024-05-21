using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorios.Interface;
using GerenciamentoDeBiblioteca_core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using GerenciamentoDeBiblioteca.Respostas;
using GerenciamentoDeBiblioteca_infra.Interfaces;
using GerenciamentoDeBiblioteca_core.Interface;
using GerenciamentoDeBiblioteca_core.ModificarEntidades;
using GerenciamentoDeBiblioteca_core.ConsultaFiltro;
using Newtonsoft.Json;
using FluentValidation;


namespace SistemaDeTarefas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase

    {
        private readonly IValidator<UsuarioModel> _usuarioValidacao;
        private readonly IMapper? _mapper;
        private readonly IServicoUri _servicoUri;
        private readonly IServicoUsuario _servicoUsuario;
        private readonly IMapper? mapper;

        public UsuarioController(IServicoUsuario servicoUsuario, IMapper mapper, IServicoUri servicoUri)
        {
            _mapper = mapper;
            _servicoUri = _servicoUri;
            _servicoUsuario = servicoUsuario;
           
        }

        /// <summary>
        /// Retorna todos os usuarios 
        /// </summary>
        /// <param name="filtro">filtro para aplicar</param>
        /// <returns></returns>

        [HttpGet(Name = nameof(GetUsuarios))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RespostasApi<IEnumerable<UsuarioDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(RespostasApi<IEnumerable<UsuarioDto>>))]
        public IActionResult GetUsuarios([FromQuery] UsuarioConsultaFiltro filtro)
        {
            var usuarios = _servicoUsuario.GetUsuario(filtro);
            var usuarioDtos = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);

            var metadado = new Metadado
            {
                TotalRegistros = usuarios.TotalRegistros,
                TamanhoPaginas = usuarios.TamanhoPagina,
                PaginaAtual = usuarios.PaginaAtual,
                TotalPaginas = usuarios.TotalPaginas,
                TemPaginaSeguinte = usuarios.TemPaginaSeguinte,
                TemPaginaAnterior = usuarios.TemPaginaAnterior
                
            };

            var resposta = new RespostasApi<IEnumerable<UsuarioDto>>(usuarioDtos)
            {
                Meta = metadado
            };

            Response.Headers.Add("X-Paginacao", JsonConvert.SerializeObject(metadado));

            return Ok(resposta);

        }

        /// <summary>
        /// Retorna todos os usuarios por  ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _servicoUsuario.GetUsuario(id);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            var resposta = new RespostasApi<UsuarioDto>(usuarioDto);
            return Ok(resposta);

        }

        /// <summary>
        /// Insere usuario
        /// </summary>
        /// <param name="usuarioDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Usuario(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioDto);

            await _servicoUsuario.InserirUsuario(usuario);

            usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            var resposta = new RespostasApi<UsuarioDto>(usuarioDto);
            return Ok(resposta);

        }

        /// <summary>
        /// Atualiza livros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UsuarioPut(int id, UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioDto);
            usuario.Id = id;

            var resultado = await _servicoUsuario.AtualizarUsuario(usuario);
            var resposta = new RespostasApi<bool>(resultado);
            return Ok(resposta);

        }

        /// <summary>
        /// Deletar usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> ApagarUsuario(int id)
        {
            var resultado = await _servicoUsuario.ApagarUsuario(id);
            var resposta = new RespostasApi<bool>(resultado);
            return Ok(resposta);

        }
    }
}


