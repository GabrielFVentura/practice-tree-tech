using System;
using Domain.Enum;

namespace Domain.DTOs.Equipamento
{
    public class EquipamentoDTO
    {
        public Guid Id { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NumeroSerie { get; set; }
        public string NomeEquipamento { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }
        public string TipoEquipamentoDescricao => TipoEquipamento.ToString();
        public string DataAlteracaoToString => DataAlteracao == DateTime.MinValue ? "" : DataAlteracao.ToString("dd/MM/yyyy");
    }
}