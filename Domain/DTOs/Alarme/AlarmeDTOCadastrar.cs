using System;
using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.DTOs.Alarme
{
    public class AlarmeDTOCadastrar
    {
        [Required(ErrorMessage = "Descrição para o Alarme é obrigatório")]
        [StringLength(50, ErrorMessage = "A Descrição para o Alarme deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "O Tipo do Alarme é obrigatório")]
        public TipoAlarme TipoAlarme {get; set; }
        
        [Required(ErrorMessage = "O Indicador de Ativo é obrigatório")]
        public bool Ativo { get; set; }
        
        [Required(ErrorMessage = "O Equipamento relacionado é obrigatório")]
        public Guid IdEquipamento { get; set; }
    }
}