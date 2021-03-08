using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.DTOs.Equipamento
{
    public class EquipamentoDTOAtualizar
    {
        [Required(ErrorMessage = "Id do Equipamento é obrigatório")]
        public Guid Id { get; set; }
        public string NomeEquipamento { get; set; }
        public string NumeroSerie { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }
    }
}

