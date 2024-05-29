using AutoMapper;
using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Application.Services
{
    public class MultaService : IMultaService
    {
        private readonly IMultaRepository _multaRepository;
        private readonly IMapper _mapper;

        public MultaService(IMultaRepository multaRepository, IMapper mapper)
        {
            _multaRepository = multaRepository;
            _mapper = mapper;
        }

        public async Task<MultaDTO> IncluirAsync(MultaDTO multaDto)
        {
            var multa = _mapper.Map<Multa>(multaDto);
            var result = await _multaRepository.Incluir(multa);
            return _mapper.Map<MultaDTO>(result);
        }

        public async Task<MultaDTO> AlterarAsync(MultaDTO multaDto)
        {
            var multa = _mapper.Map<Multa>(multaDto);
            var result = await _multaRepository.Alterar(multa);
            return _mapper.Map<MultaDTO>(result);
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var result = await _multaRepository.Excluir(id);
            return result != null;
        }

        public async Task<MultaDTO> SelecionarAsync(int id)
        {
            var result = await _multaRepository.SelecionarAsync(id);
            return _mapper.Map<MultaDTO>(result);
        }

        public async Task<IEnumerable<MultaDTO>> ListarAsync()
        {
            var result = await _multaRepository.ListarAsync();
            return _mapper.Map<IEnumerable<MultaDTO>>(result);
        }
    }
}
