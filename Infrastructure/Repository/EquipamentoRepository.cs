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
    public class EquipamentoRepository : BaseRepository<Equipamento>, IEquipamentoRepository
    {
        protected readonly TreeTechContext _context;
        private DbSet<Equipamento> _dataSet;

        public EquipamentoRepository(TreeTechContext context) : base(context)
        {
            _context = context;
            _dataSet = _context.Set<Equipamento>();
        }

        public async Task<IEnumerable<Equipamento>> BuscarPorFiltro(FiltroEquipamento filtro)
        {
            var result = _dataSet.AsQueryable();
            
            if (!string.IsNullOrEmpty(filtro.NomeEquipamento))
                result = result.Where(x => x.NomeEquipamento.Contains(filtro.NomeEquipamento));
            if (!string.IsNullOrEmpty(filtro.NumeroSerie))
                result = result.Where(x => x.NumeroSerie.Contains(filtro.NumeroSerie));
            if (filtro.TipoEquipamento != TipoEquipamento.Nulo && filtro.TipoEquipamento != null)
                result = result.Where(x => x.TipoEquipamento == filtro.TipoEquipamento);


            return await Task.FromResult(result.ToList());
        }
    }
}