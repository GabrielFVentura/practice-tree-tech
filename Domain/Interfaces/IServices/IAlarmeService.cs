using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs.Alarme;
using Domain.Filtros;

namespace Domain.Interfaces.IServices
{
    public interface IAlarmeService
    {
        Task<AlarmeDTO> BuscarPorId(Guid id);
        Task<IEnumerable<AlarmeDTO>> BuscarTodos();
        Task<AlarmeDTOCadastrarResult> Cadastrar(AlarmeDTOCadastrar dto);
        Task<AlarmeDTOAtualizarResult> Atualizar(AlarmeDTOAtualizar dto);
        Task<bool> Deletar(Guid id);
        Task<bool> AtivarOuDesativarAlarme(AlarmeDTO dto);
        Task<IEnumerable<AlarmeDTO>> BuscarPorFiltro(FiltroAlarme filtro);
    }
}