using GerenciamentoDeBiblioteca.API.Extensions;
using GerenciamentoDeBiblioteca.API.Models;
using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using GerenciamentoDeBiblioteca.Domain.Account;
using GerenciamentoDeBiblioteca.Infra.Data.Identity;
using GerenciamentoDeBiblioteca.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.API.Controllers
{
    /// <summary>
    /// Controlador responsável por operações relacionadas aos usuários.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IAuthenticate authenticateService, IUsuarioService usuarioService)
        {
            _authenticateService = authenticateService;
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Registra um novo usuário no sistema.
        /// </summary>
        /// <param name="usuarioDTO">Dados do usuário para registro.</param>
        /// <returns>Um token de autenticação se o registro for bem-sucedido.</returns>
        [HttpPost("register")]
        public async Task<ActionResult<UserToken>>Incluir(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("Dados inválidos");
            }
            var emailExiste = await _authenticateService.UserExists(usuarioDTO.Email);

            if (emailExiste) 
            {
                return BadRequest("Este email já possui um cadastro.");
            }

            var existeUsuarioSistema = await _usuarioService.ExisteUsuarioCadastradoAsync();
            if (!existeUsuarioSistema)
            {
                usuarioDTO.IsAdmin = true;
            }
            else
            {
                if(User.FindFirst("id") == null)
                {
                    return Unauthorized();
                }

                var userId = User.GetId();
                var user = await _usuarioService.SelecionarAsync(userId);
                if (!user.IsAdmin)
                {
                    return Unauthorized("Você não tem permissão para incluir novos usuários.");
                }
            }

            var usuario = await _usuarioService.Incluir(usuarioDTO);
            if (usuario == null)
            {
                return BadRequest("Ocorreu um erro ao cadastrar.");
            }
            //var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);
            //return new UserToken
            //{
            // Token = token,
            //};

            return Ok(new { message = "Usuário incluído com sucesso!" });

        }

        /// <summary>
        /// Autentica um usuário no sistema e gera um token de autenticação.
        /// </summary>
        /// <param name="loginModel">Dados do login do usuário.</param>
        /// <returns>Um token de autenticação se o login for bem-sucedido.</returns>
        [HttpPost("login")]

        public async Task<ActionResult<UserToken>>Selecionar(LoginModel loginModel)
        {
            var existe = await _authenticateService.UserExists(loginModel.Email);
            if (!existe)
            {
                return Unauthorized("Usuário não existe.");
            }

            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (!result)
            {
                return Unauthorized("Usuário ou senha inválido.");
            }

            var usuario = await _authenticateService.GetUserByEmail(loginModel.Email);

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token,
                IsAdmin = usuario.IsAdmin,
                Email = usuario.Email
            };




        }

        /// <summary>
        /// Recupera todos os usuários do sistema com paginação.
        /// </summary>
        /// <param name="paginationParams">Parâmetros de paginação (número da página e tamanho da página).</param>
        /// <returns>Uma lista paginada de usuários.</returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> SelecionarTodos([FromQuery] PaginationParams paginationParams)
        {
            var userId = User.GetId();
            var user = await _usuarioService.SelecionarAsync(userId);

            if (!user.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }

            var usuarios = await _usuarioService.SelecionarTodosAsync(paginationParams.PageNumber, paginationParams.PageSize);
            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, usuarios.PageSize,
                usuarios.TotalCount, usuarios.TotalPages));
            return Ok(usuarios);
        }

        /// <summary>
        /// Recupera um usuário específico pelo Id.
        /// </summary>
        /// <param name="id">O identificador do usuário.</param>
        /// <returns>Um usuário específico.</returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> SelecionarById(int id)
        {
            var userId = User.GetId();
            var user = await _usuarioService.SelecionarAsync(userId);

            if (id == 0)
            {
                id = userId;
            }

            if (!user.IsAdmin && user.Id != id)
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }

            var usuario = await _usuarioService.SelecionarAsync((int)id);
            return Ok(usuario);
        }

        /// <summary>
        /// Exclui um usuário específico pelo Id.
        /// </summary>
        /// <param name="id">O identificador do usuário a ser excluído.</param>
        /// <returns>Um ActionResult indicando o resultado da operação.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int id)
        {
            var userId = User.GetId();
            var user = await _usuarioService.SelecionarAsync(userId);

            if (!user.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para excluir os usuários do sistema.");
            }

            var usuario = await _usuarioService.Excluir(id);
            return Ok(usuario);
        }

        /// <summary>
        /// Altera os dados de um usuário específico.
        /// </summary>
        /// <param name="usuarioPutDTO">Objeto DTO contendo os dados do usuário a serem alterados.</param>
        /// <returns>Um ActionResult indicando o resultado da operação.</returns>
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Alterar(UsuarioPutDTO usuarioPutDTO)
        {
            var userId = User.GetId();
            var user = await _usuarioService.SelecionarAsync(userId);


            if (!user.IsAdmin && usuarioPutDTO.Id != userId)
            {
                return Unauthorized("Você não tem permissão para alterar os usuários do sistema.");
            }

            if (!user.IsAdmin && usuarioPutDTO.Id == userId && usuarioPutDTO.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para definir você mesmo como administrador.");
            }
            var usuario = await _usuarioService.Alterar(usuarioPutDTO);

            return Ok(new { message = "Usuário alterado com sucesso!" });
        }

        /// <summary>
        /// Seleciona todos os usuários do sistema com base nos filtros fornecidos.
        /// </summary>
        /// <param name="filtroUsuario">Objeto contendo os critérios de filtro para a seleção de usuários.</param>
        /// <returns>Um ActionResult contendo a lista de usuários filtrados.</returns>
        [HttpGet("filtrar")]
        [Authorize]
        public async Task<ActionResult> SelecionarTodosByFiltro([FromQuery] FiltroUsuario filtroUsuario)
        {
            var userId = User.GetId();
            var user = await _usuarioService.SelecionarAsync(userId);

            if (!user.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }

            var usuarios = await _usuarioService.SelecionarByFiltroAsync(filtroUsuario.Nome, filtroUsuario.Email,
                filtroUsuario.IsAdmin, filtroUsuario.IsNotAdmin, filtroUsuario.Ativo, filtroUsuario.Inativo, filtroUsuario.PageNumber, filtroUsuario.PageSize);
            Response.AddPaginationHeader(new PaginationHeader(filtroUsuario.PageNumber, usuarios.PageSize,
                usuarios.TotalCount, usuarios.TotalPages));
            return Ok(usuarios);
        }




    }
}
