using System.Collections.Generic;
using Domain.Entities.Base;
using Domain.Enum;

namespace Domain.Entities
{
    public class Equipamento : Entity
    {
        public string NomeEquipamento { get; set; }
        public string NumeroSerie { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }
        public ICollection<Alarme> Alarmes { get; set; }
    }
}