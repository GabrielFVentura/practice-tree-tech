using System;
using Domain.DTOs.Alarme;

namespace Domain.DTOs.AlarmeAtuado
{
    public class AlarmeAtuadoDTOContagem
    {
        public Guid IdAlarme { get; set; }
        public int Ocorrencias { get; set; }
        public AlarmeDTO AlarmeDTO { get; set; }
    }
}