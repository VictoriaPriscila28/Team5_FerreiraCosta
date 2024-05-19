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


namespace SistemaDeTarefas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
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

            return Ok(respuesta);

        }

        /// <summary>
        /// Retorna los estudiantes por el ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstudiante(int id)
        {
            var estudiante = await _servicioEstudiante.GetEstudiante(id);
            var estudianteDto = _mapper.Map<EstudianteDto>(estudiante);
            var respuesta = new ApiRespuesta<EstudianteDto>(estudianteDto);
            return Ok(respuesta);

        }

        /// <summary>
        /// Inserta estudiante
        /// </summary>
        /// <param name="estudianteDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Estudiante(EstudianteDto estudianteDto)
        {
            var estudiante = _mapper.Map<Estudiantes>(estudianteDto);

            await _servicioEstudiante.InsertarEstudiante(estudiante);

            estudianteDto = _mapper.Map<EstudianteDto>(estudiante);
            var respuesta = new ApiRespuesta<EstudianteDto>(estudianteDto);
            return Ok(respuesta);

        }

        /// <summary>
        /// Actualiza libros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estudianteDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EstudiantePut(int id, EstudianteDto estudianteDto)
        {
            var estudiante = _mapper.Map<Estudiantes>(estudianteDto);
            estudiante.Id = id;

            var resultado = await _servicioEstudiante.ActualizarEstudiante(estudiante);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);

        }

        /// <summary>
        /// Elimina estudiante
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> EstudianteDelete(int id)
        {
            var resultado = await _servicioEstudiante.EliminarEstudiante(id);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);

        }
    }
}


