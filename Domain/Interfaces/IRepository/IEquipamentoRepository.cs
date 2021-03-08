using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Filtros;
using Domain.Interfaces.IRepository.Base;

namespace Domain.Interfaces.IRepository
{
    public interface IEquipamentoRepository : IRepository<Equipamento>
    {
        Task<IEnumerable<Equipamento>> BuscarPorFiltro(FiltroEquipamento filtro);

    }
}