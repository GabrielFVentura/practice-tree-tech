using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Base;
using Domain.Enum;

namespace Domain.Entities
{
    public class Alarme : Entity
    {
        public string Descricao { get; set; }
        public TipoAlarme TipoAlarme {get; set; }
        public bool Ativo { get; set; }
        public Guid IdEquipamento { get; set; }
        public Equipamento Equipamento { get; set; }
        [ForeignKey("IdAlarme")]
        public ICollection<AlarmeAtuado> AlarmesAtuado { get; set; }

    }
}