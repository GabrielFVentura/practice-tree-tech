using Domain.Enum;

namespace Domain.DTOs.Equipamento
{
    public class EquipamentoDTOAtualizarResult
    {
        public string NomeEquipamento { get; set; }
        public string NumeroSerie { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }
    }
}