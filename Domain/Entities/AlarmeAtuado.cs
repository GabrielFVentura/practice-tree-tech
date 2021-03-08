using System;
using Domain.Entities.Base;
using Domain.Enum;

namespace Domain.Entities
{
    public class AlarmeAtuado : Entity
    {
        public Guid IdAlarme { get; set; }
        public Alarme Alarme { get; set; }
        public string Descricao { get; set; }
        public TipoAlarme TipoAlarme { get; set; }
        public string NomeEquipamento { get; set; }
        public string NumeroSerie { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }
    }
}