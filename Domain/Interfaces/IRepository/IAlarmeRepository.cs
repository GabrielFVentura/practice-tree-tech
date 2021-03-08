using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Filtros;
using Domain.Interfaces.IRepository.Base;

namespace Domain.Interfaces.IRepository
{
    public interface IAlarmeRepository :  IRepository<Alarme>
    {
        Task<IEnumerable<Alarme>> BuscarPorIdEquipamento(Guid id);
        Task<IEnumerable<Alarme>> BuscarPorFiltro(FiltroAlarme filtro);
    }
}