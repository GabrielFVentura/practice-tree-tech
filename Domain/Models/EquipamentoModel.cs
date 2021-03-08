using Domain.Enum;
using Domain.Models.Base;

namespace Domain.Models
{
    public class EquipamentoModel : BaseModel
    {
        public string NomeEquipamento { get; set; }
        public string NumeroSerie { get; set; }
        public TipoEquipamento TipoEquipamento {get; set; }
    }
}