using System;
using Domain.DTOs.Alarme;
using Domain.DTOs.Equipamento;

namespace Domain.DTOs.AlarmeAtuado
{
    public class AlarmeAtuadoDTOCadastrarResult
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public EquipamentoDTO EquipamentoDTO { get; set; }
        public AlarmeDTO AlarmeDTO { get; set; }
        public bool Cadastrou { get; set; }
    }
}