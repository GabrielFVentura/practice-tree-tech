using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs.AlarmeAtuado;
using Domain.Entities;
using Domain.Filtros;
using Domain.Interfaces.IRepository.Base;

namespace Domain.Interfaces.IRepository
{
    public interface IAlarmeAtuadoRepository : IRepository<AlarmeAtuado>
    {
        Task<IEnumerable<AlarmeAtuado>> BuscarPorFiltro(FiltroAlarme filtro);
        Task<Dictionary<Guid, int>> BuscarAlarmesMaisAtuados(int numeroAlarme);
    }
}