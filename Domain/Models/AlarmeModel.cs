using System;
using Domain.Enum;
using Domain.Models.Base;

namespace Domain.Models
{
    public class AlarmeModel : BaseModel
    {
        public string Descricao { get; set; }
        public TipoAlarme TipoAlarme {get; set; }
        public bool Ativo { get; set; }
        public Guid IdEquipamento { get; set; }
        public EquipamentoModel EquipamentoModel { get; set; }

        public void InverterStatus() => Ativo = !Ativo;

    }
}