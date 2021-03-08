using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
        
        private DateTime? _dataCadastro;
        public DateTime? DataCadastro
        {
            get => _dataCadastro;
            set => _dataCadastro = value ?? DateTime.Now;
        }
        public DateTime DataAlteracao { get; set; }
    }
}