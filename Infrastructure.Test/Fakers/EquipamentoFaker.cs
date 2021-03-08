using System;
using Domain.Entities;
using Domain.Enum;

namespace Infrastructure.Test.Fakers
{
    public class EquipamentoFaker
    {
        public static Equipamento GerarEntidadeEquipamento()
        {
            return new Equipamento
            {
                Id = Guid.NewGuid(),
                DataAlteracao = DateTime.Now,
                DataCadastro = DateTime.Now,
                NomeEquipamento = Faker.Lorem.GetFirstWord(),
                NumeroSerie = Faker.RandomNumber.Next(1, 99999).ToString(),
                TipoEquipamento = (TipoEquipamento) Faker.RandomNumber.Next(1, 3)
            };
        }
    }
}