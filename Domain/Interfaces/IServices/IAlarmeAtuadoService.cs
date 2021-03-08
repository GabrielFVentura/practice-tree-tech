using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs.AlarmeAtuado;
using Domain.Entities;
using Domain.Filtros;

namespace Domain.Interfaces.IServices
{
    public interface IAlarmeAtuadoService
    {
        Task<IEnumerable<AlarmeAtuadoDTO>> BuscarPorFiltro(FiltroAlarme filtro);
        Task<bool> Cadastrar(Alarme alarme);
        Task<List<AlarmeAtuadoDTOContagem>> BuscarAlarmesMaisAtuados(int numeroOcorrencias);
    }
}