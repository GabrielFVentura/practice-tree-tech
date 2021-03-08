using System;
using Domain.DTOs.Equipamento;
using Domain.Enum;

namespace Domain.DTOs.Alarme
{
    public class AlarmeDTO
    {
        public Guid Id { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
        public TipoAlarme TipoAlarme {get; set; }
        public bool Ativo { get; set; }
        public Guid IdEquipamento { get; set; }
        public string TipoAlarmeDescricao => TipoAlarme.ToString();
        public string DataAlteracaoToString => DataAlteracao == DateTime.MinValue ? "" : DataAlteracao.ToString("dd/MM/yyyy");
        public EquipamentoDTO EquipamentoDTO { get; set; }
    }
}