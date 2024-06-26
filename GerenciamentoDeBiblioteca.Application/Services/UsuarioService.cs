﻿using AutoMapper;
using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using GerenciamentoDeBiblioteca.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<UsuarioDTO> Alterar(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var usuarioAlterado = await _repository.Alterar(usuario);
            return _mapper.Map<UsuarioDTO>(usuarioAlterado);
        }

        public async Task<UsuarioPutDTO> Alterar(UsuarioPutDTO usuarioPutDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioPutDTO);

            if (usuarioPutDTO.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioPutDTO.Password));
                byte[] passwordSalt = hmac.Key;
            }

            var usuarioAlterado = await _repository.Alterar(usuario);
            return _mapper.Map<UsuarioPutDTO>(usuarioAlterado); 
        }

        public async Task<UsuarioDTO> Excluir(int id)
        {
            var usuario = await _repository.SelecionarAsync(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<bool> ExisteUsuarioCadastradoAsync()
        {
            return await _repository.ExisteUsuarioCadastradoAsync();
        }

        public async Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            if (usuarioDTO.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioDTO.Password));
                byte[] passwordSalt = hmac.Key;

                usuario.AlterarSenha(passwordHash, passwordSalt);

            }

            var usuarioIncluido = await _repository.Incluir(usuario);
            return _mapper.Map<UsuarioDTO>(usuarioIncluido);
        }

        public async Task<UsuarioDTO> SelecionarAsync(int id)
        {
            var usuario = await _repository.SelecionarAsync(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<PagedList<UsuarioDTO>> SelecionarByFiltroAsync(string nome, string email, bool? isAdmin, bool? isNotAdmin, bool? ativo, bool? inativo, int pageNumber, int pageSize)
        {
            var usuarios = await _repository.SelecionarByFiltroAsync(
            nome, email, isAdmin, isNotAdmin, ativo, inativo, pageNumber, pageSize);
            var usuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return new PagedList<UsuarioDTO>
                (usuariosDTO, pageNumber, usuarios.TotalPages, usuarios.PageSize, usuarios.TotalCount);
        }



        public async Task<PagedList<UsuarioDTO>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var usuarios = await _repository.SelecionarTodosAsync(pageNumber, pageSize);
            var usuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return new PagedList<UsuarioDTO>
                (usuariosDTO, pageNumber, usuarios.TotalPages, usuarios.PageSize, usuarios.TotalCount);
        }
    }
}
