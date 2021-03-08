using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.Equipamento;
using Domain.Entities;
using Domain.Filtros;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Domain.Models;

namespace Services.Services
{
    public class EquipamentoService : IEquipamentoService
    {
        private IAlarmeRepository _alarmeRepository;
        private IEquipamentoRepository _repository;
        private readonly IMapper _mapper;
        
        public EquipamentoService(IEquipamentoRepository repository, IAlarmeRepository alarmeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _alarmeRepository = alarmeRepository;
        }
        public async Task<EquipamentoDTO> BuscarPorId(Guid id)
        {
            var entity = await _repository.BuscarAsync(id);
            return _mapper.Map<EquipamentoDTO>(entity);
        }

        public async Task<IEnumerable<EquipamentoDTO>> BuscarTodos()
        {
            var listEntities = await _repository.BuscarAsync();
            return _mapper.Map<IEnumerable<EquipamentoDTO>>(listEntities);
        }

        public async Task<EquipamentoDTOCadastrarResult> Cadastrar(EquipamentoDTOCadastrar dto)
        {
            var model = _mapper.Map<EquipamentoModel>(dto);
            var entity = _mapper.Map<Equipamento>(model);

            var filtro = new FiltroEquipamento
            {
                NumeroSerie = dto.NumeroSerie
            };
            
            var equipamentos = await _repository.BuscarPorFiltro(filtro);
            if (equipamentos.Any())
                return null;

            var result = await _repository.CadastrarAsync(entity);
            return _mapper.Map<EquipamentoDTOCadastrarResult>(result);    
        }

        public async Task<EquipamentoDTOAtualizarResult> Atualizar(EquipamentoDTOAtualizar dto)
        {
            var model = _mapper.Map<EquipamentoModel>(dto);
            var entity = _mapper.Map<Equipamento>(model);
            var result = await _repository.AtualizarAsync(entity);
            return _mapper.Map<EquipamentoDTOAtualizarResult>(result);
        }

        public async Task<bool> Deletar(Guid id)
        {
            var equipamentosRelacionado = await _alarmeRepository.BuscarPorIdEquipamento(id);
            
            if (equipamentosRelacionado.Any())
                return false;
            
            return await _repository.DeletarAsync(id);
        }
        
        public async Task<IEnumerable<EquipamentoDTO>> BuscarPorFiltro(FiltroEquipamento filtro)
        {
            var listEntities = await _repository.BuscarPorFiltro(filtro);
            return _mapper.Map<IEnumerable<EquipamentoDTO>>(listEntities);
        }
    }
}