using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs.AlarmeAtuado;
using Domain.Entities;
using Domain.Enum;
using Domain.Filtros;
using Domain.Interfaces.IRepository;
using Infrastructure.DataContext;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class AlarmeAtuadoRepository : BaseRepository<AlarmeAtuado>, IAlarmeAtuadoRepository
    {
        protected readonly TreeTechContext _context;
        private DbSet<AlarmeAtuado> _dataSet;

        public AlarmeAtuadoRepository(TreeTechContext context) : base(context)
        {
            _context = context;
            _dataSet = _context.Set<AlarmeAtuado>();
        }

        public async Task<IEnumerable<AlarmeAtuado>> BuscarPorFiltro(FiltroAlarme filtro)
        {
            var result = _dataSet.AsQueryable();
            
            if (!string.IsNullOrEmpty(filtro.Descricao))
                result = result.Where(x => x.Descricao.Contains(filtro.Descricao));
            if (filtro.TipoAlarme != null)
                result = result.Where(x => x.TipoAlarme == filtro.TipoAlarme);
            if (filtro.TipoEquipamento != TipoEquipamento.Nulo && filtro.TipoEquipamento != null)
                result = result.Where(x => x.TipoEquipamento == filtro.TipoEquipamento);
            if (!string.IsNullOrEmpty(filtro.NomeEquipamento))
                result = result.Where(x => x.NomeEquipamento == filtro.NomeEquipamento);
            if (!string.IsNullOrEmpty(filtro.NumeroSerie))
                result = result.Where(x => x.NumeroSerie.Contains(filtro.NumeroSerie));
            // if (filtro.DataCadastro != DateTime.MinValue)
            //     result = result.Where(x => x.DataAlteracao.ToString("d") == filtro.DataCadastro.ToString("yyyy-mm-dd"));
            return await Task.FromResult(result.ToList());
        }

        public async Task<Dictionary<Guid, int>> BuscarAlarmesMaisAtuados(int numeroOcorrencias)
        {
            var query =
                _dataSet.GroupBy(k => new {k.IdAlarme})
                    .Select(g => new
                    {
                        g.Key.IdAlarme,
                        Ocorrencias = g.Count()
                    }).OrderByDescending(g => g.Ocorrencias).Take(numeroOcorrencias)
                    .ToDictionary(g => g.IdAlarme, g => g.Ocorrencias);

            return await Task.FromResult(query);
        }
    }
}