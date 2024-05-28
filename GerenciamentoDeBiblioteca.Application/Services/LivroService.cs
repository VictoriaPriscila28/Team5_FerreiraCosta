using AutoMapper;
using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;
        private readonly IMapper _mapper;

        public LivroService(ILivroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LivroDTO> Alterar(LivroDTO livroDTO)
        {
            var livro = _mapper.Map<Livro>(livroDTO);
            var livroAlterado = await _repository.Alterar(livro);
            return _mapper.Map<LivroDTO>(livroAlterado);
        }

        public async Task<LivroDTO> Excluir(int id)
        {
            var livroExcluido = await _repository.Excluir(id);
            return _mapper.Map<LivroDTO>(livroExcluido);
        }

        public async Task<LivroDTO> Incluir(LivroDTO livroDTO)
        {
            var livro = _mapper.Map<Livro>(livroDTO);
            var livroIncluido = await _repository.Incluir(livro);
            return _mapper.Map<LivroDTO>(livroIncluido);
        }

        public async Task<LivroDTO> SelecionarAsync(int id)
        {
            var livro = await _repository.SelecionarAsync(id);
            return _mapper.Map<LivroDTO>(livro);
        }

        public async Task<IEnumerable<LivroDTO>> SelecionarTodosAsync()
        {
            var livros = await _repository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<LivroDTO>>(livros);
        }
    }
}
