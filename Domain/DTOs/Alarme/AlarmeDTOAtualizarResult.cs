using System;
using Domain.Enum;

namespace Domain.DTOs.Alarme
{
    public class AlarmeDTOAtualizarResult
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public TipoAlarme TipoAlarme {get; set; }
        public bool Ativo { get; set; }
    }
}