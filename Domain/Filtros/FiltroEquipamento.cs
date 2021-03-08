using Domain.Enum;

namespace Domain.Filtros
{
    public class FiltroEquipamento
    {
        public string NomeEquipamento { get; set; }
        public string NumeroSerie { get; set; }
        public TipoEquipamento? TipoEquipamento { get; set; }
    }
}