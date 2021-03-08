using System;
using Domain.Enum;

namespace Domain.Filtros
{
    public class FiltroAlarme
    {
        public string Descricao { get; set; }
        public string IdEquipamento { get; set; }
        public TipoAlarme? TipoAlarme { get; set; }
        public TipoEquipamento? TipoEquipamento { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string? NomeEquipamento { get; set; }
        public string? NumeroSerie { get; set; }
    }
}