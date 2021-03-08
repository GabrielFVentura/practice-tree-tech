using System;
using Domain.DTOs.Alarme;
using Domain.Enum;

namespace Domain.DTOs.AlarmeAtuado
{
    public class AlarmeAtuadoDTO
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }

        public Guid IdAlarme { get; set; }
        public AlarmeDTO AlarmeDTO { get; set; }
        public string Descricao { get; set; }
        public TipoAlarme TipoAlarme { get; set; }
        
        public Guid IdEquipamento { get; set; }
        public string NomeEquipamento { get; set; }
        public string NumeroSerie { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }
        public string TipoAlarmeDescricao => TipoAlarme.ToString();
        public string TipoEquipamentoDescricao => TipoEquipamento.ToString();


    }
}