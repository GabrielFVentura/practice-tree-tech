using System;
using Domain.Enum;

namespace Domain.DTOs.Equipamento
{
    public class EquipamentoDTOCadastrarResult
    {
        public Guid Id { get; set; }
        public string NomeEquipamento { get; set; }
        public string NumeroSerie { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }
    }
}