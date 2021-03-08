using System;
using Domain.Enum;
using Domain.Models.Base;

namespace Domain.Models
{
    public class AlarmeAtuadoModel : BaseModel
    {
        public Guid Id { get; set;}
        public DateTime DataCadastro { get; set; }
        public Guid IdAlarme { get; set; }
        public string Descricao { get; set; }
        public TipoAlarme TipoAlarme { get; set; }
        public AlarmeModel AlarmeModel { get; set; }
        public string NomeEquipamento { get; set; }
        public string NumeroSerie { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }
    }
}