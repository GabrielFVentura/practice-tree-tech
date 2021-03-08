using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.DTOs.Alarme
{
    public class AlarmeDTOAtualizar
    {
        [Required(ErrorMessage = "Id do Alarme é obrigatório")]
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public TipoAlarme TipoAlarme {get; set; }
        public bool Ativo { get; set; }
        public Guid IdEquipamento { get; set; }
    }
}