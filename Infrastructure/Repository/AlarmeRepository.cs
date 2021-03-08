using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enum;
using Domain.Filtros;
using Domain.Interfaces.IRepository;
using Infrastructure.DataContext;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class AlarmeRepository : BaseRepository<Alarme>, IAlarmeRepository
    {
        protected readonly TreeTechContext _context;
        private DbSet<Alarme> _dataSet;
        
        public AlarmeRepository(TreeTechContext context) : base(context)
        {
            _context = context;
            _dataSet = _context.Set<Alarme>();
        }

        public async Task<IEnumerable<Alarme>> BuscarPorIdEquipamento(Guid id)
        {
            return await Task.FromResult(_dataSet.AsQueryable().Where(x => x.Equipamento.Id == id));
        }

        public async Task<IEnumerable<Alarme>> BuscarPorFiltro(FiltroAlarme filtro)
        {
            var result = _dataSet.AsQueryable();
            
            if (!string.IsNullOrEmpty(filtro.Descricao))
                result = result.Where(x => x.Descricao.Contains(filtro.Descricao));
            if (filtro.Ativo != null)
                result = result.Where(x => x.Ativo == filtro.Ativo);
            if (filtro.IdEquipamento != null)
                result = result.Where(x => x.IdEquipamento == Guid.Parse(filtro.IdEquipamento));
            if (filtro.TipoAlarme != TipoAlarme.Nulo && filtro.TipoAlarme != null)
                result = result.Where(x => x.TipoAlarme == filtro.TipoAlarme);

            return await Task.FromResult(result.ToList());
        }
    }
}