using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.Alarme;
using Domain.Entities;
using Domain.Enum;
using Domain.Filtros;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Domain.Models;

namespace Services.Services
{
    public class AlarmeService : IAlarmeService
    {
        private IAlarmeRepository _repository;
        private IEquipamentoRepository _equipamentoRepository;
        private IAlarmeAtuadoService _alarmeAtuadoService;
        private IEmailService _emailService;
        private readonly IMapper _mapper;

        public AlarmeService(IMapper mapper, 
                IAlarmeRepository repository, 
                IEquipamentoRepository equipamentoRepository,
                IEmailService emailService, 
                IAlarmeAtuadoRepository alarmeAtuadoRepository,
                IAlarmeAtuadoService alarmeAtuadoService)
        {
            _mapper = mapper;
            _emailService = emailService;
            _alarmeAtuadoService = alarmeAtuadoService;
            _repository = repository;
            _equipamentoRepository = equipamentoRepository;
        }
        
        public async Task<AlarmeDTO> BuscarPorId(Guid id)
        {
            var entity = await _repository.BuscarAsync(id);
            entity.Equipamento = await _equipamentoRepository.BuscarAsync(entity.IdEquipamento);
            return _mapper.Map<AlarmeDTO>(entity);
        }

        public async Task<IEnumerable<AlarmeDTO>> BuscarTodos()
        {
            var entities = await _repository.BuscarAsync();
            var alarmesList = entities.ToList();

            if (alarmesList.Any())
                await BuscarEquipamentoPorId(alarmesList);
            
            return _mapper.Map<IEnumerable<AlarmeDTO>>(entities);
        }

        public async Task<AlarmeDTOCadastrarResult> Cadastrar(AlarmeDTOCadastrar dto)
        {
            var model = _mapper.Map<AlarmeModel>(dto);
            var entity = _mapper.Map<Alarme>(model);
            
            var result = await _repository.CadastrarAsync(entity);
            
            return _mapper.Map<AlarmeDTOCadastrarResult>(result);
        }

        public async Task<AlarmeDTOAtualizarResult> Atualizar(AlarmeDTOAtualizar dto)
        {
            var model = _mapper.Map<AlarmeModel>(dto);
            var entity = _mapper.Map<Alarme>(model);
            var result = await _repository.AtualizarAsync(entity);
            return _mapper.Map<AlarmeDTOAtualizarResult>(result);
        }

        public async Task<bool> Deletar(Guid id)
        {
            var alarme = await _repository.BuscarAsync(id);
            if (alarme.Ativo)
                return false;
            return await _repository.DeletarAsync(id);
        }
        
        public async Task<bool> AtivarOuDesativarAlarme(AlarmeDTO dto)
        {
            var model = _mapper.Map<AlarmeModel>(dto);
            model.InverterStatus();
            
            var entity = _mapper.Map<Alarme>(model);
            var result = await _repository.AtualizarAsync(entity);
            entity.Equipamento = await _equipamentoRepository.BuscarAsync(entity.IdEquipamento);

            if (model.Ativo)
            {
                await _alarmeAtuadoService.Cadastrar(entity);
                if (model.TipoAlarme == TipoAlarme.Alto && result != null)
                    return await _emailService.EnviarEmail(entity.Descricao, entity.Equipamento.NomeEquipamento);

            }
            
            return true;
        }

        public async Task<IEnumerable<AlarmeDTO>> BuscarPorFiltro(FiltroAlarme filtro)
        {
            var entities = await _repository.BuscarPorFiltro(filtro);
            var alarmesList = entities.ToList();

            if (alarmesList.Any()) await BuscarEquipamentoPorId(alarmesList);

            return _mapper.Map<IEnumerable<AlarmeDTO>>(entities);
        }

        private async Task BuscarEquipamentoPorId(List<Alarme> alarmesList)
        {
            foreach (var entity in alarmesList)
                entity.Equipamento = await _equipamentoRepository.BuscarAsync(entity.IdEquipamento);
        }
    }
}