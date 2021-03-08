using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.Alarme;
using Domain.DTOs.AlarmeAtuado;
using Domain.Entities;
using Domain.Filtros;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Domain.Models;

namespace Services.Services
{
    public class AlarmeAtuadoService : IAlarmeAtuadoService
    {
        private readonly IMapper _mapper;
        private IAlarmeAtuadoRepository _repository;
        private IEquipamentoRepository _equipamentoRepository;
        private IAlarmeRepository _alarmeRepository;

        public AlarmeAtuadoService(IMapper mapper, 
            IAlarmeAtuadoRepository repository, 
            IEquipamentoRepository equipamentoRepository,
            IAlarmeRepository alarmeRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _equipamentoRepository = equipamentoRepository;
            _alarmeRepository = alarmeRepository;
        }

        public async Task<IEnumerable<AlarmeAtuadoDTO>> BuscarPorFiltro(FiltroAlarme filtro)
        {
            var entities = await _repository.BuscarPorFiltro(filtro);
            var alarmesList = entities.ToList();
            
            // if (alarmesList.Any()) await BuscarAlarmePorId(alarmesList);
            
            return _mapper.Map<IEnumerable<AlarmeAtuadoDTO>>(alarmesList);
        }
        
        public async Task<bool> Cadastrar(Alarme alarme)
        {
            var model = new AlarmeAtuadoModel
            {
                IdAlarme = alarme.Id,
                NomeEquipamento = alarme.Equipamento.NomeEquipamento,
                NumeroSerie = alarme.Equipamento.NumeroSerie,
                TipoEquipamento = alarme.Equipamento.TipoEquipamento,
                DataCadastro = DateTime.Now,
                Descricao = alarme.Descricao,
                TipoAlarme = alarme.TipoAlarme,
                AlarmeModel = new AlarmeModel
                {
                    TipoAlarme = alarme.TipoAlarme,
                    Descricao = alarme.Descricao,
                    Ativo = alarme.Ativo,
                }
            };
            
            var entity = _mapper.Map<AlarmeAtuado>(model);
            
            var result = await _repository.CadastrarAsync(entity);
            
            return result != null;
        }

        public async Task<List<AlarmeAtuadoDTOContagem>> BuscarAlarmesMaisAtuados(int numeroOcorrencias)
        {
            var result = await _repository.BuscarAlarmesMaisAtuados(numeroOcorrencias);
            var list = new List<AlarmeAtuadoDTOContagem>();

            foreach (var dict in result)
            {
                var k = new AlarmeAtuadoDTOContagem
                {
                    IdAlarme = dict.Key,
                    Ocorrencias = dict.Value
                };
                var Dto = _mapper.Map<AlarmeDTO>(await _alarmeRepository.BuscarAsync(k.IdAlarme));
                k.AlarmeDTO = Dto;
                list.Add(k);
            }
            
            return list;
        }

        private async Task<Equipamento> BuscarEquipamentoPorId(Guid idEquipamento)
        {
            return await _equipamentoRepository.BuscarAsync(idEquipamento);
        }
        
        private async Task BuscarAlarmePorId(List<AlarmeAtuado> alarmesList)
        {
            foreach (var entity in alarmesList)
            {
                entity.Alarme = await _alarmeRepository.BuscarAsync(entity.IdAlarme);
                entity.Alarme.Equipamento = await BuscarEquipamentoPorId(entity.Alarme.IdEquipamento);
            }
        }
    }
}