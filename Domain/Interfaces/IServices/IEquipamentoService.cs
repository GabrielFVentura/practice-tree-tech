using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs.Equipamento;
using Domain.Filtros;

namespace Domain.Interfaces.IServices
{
    public interface IEquipamentoService
    {
        Task<EquipamentoDTO> BuscarPorId(Guid id);
        Task<IEnumerable<EquipamentoDTO>> BuscarTodos();
        Task<EquipamentoDTOCadastrarResult> Cadastrar(EquipamentoDTOCadastrar dto);
        Task<EquipamentoDTOAtualizarResult> Atualizar(EquipamentoDTOAtualizar dto);
        Task<bool> Deletar(Guid id);
        Task<IEnumerable<EquipamentoDTO>> BuscarPorFiltro(FiltroEquipamento filtro);
    }
}