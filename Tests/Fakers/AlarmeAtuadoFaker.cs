using System;
using Domain.Entities;
using Domain.Enum;

namespace Infrastructure.Test.Fakers
{
    public class AlarmeAtuadoFaker
    {
        public AlarmeAtuadoFaker()
        {
            
        }
        
        public static AlarmeAtuado GerarEntidadeAlarmeAtuado()
        {
            return new AlarmeAtuado
            {
                Id = Guid.NewGuid(),
                DataAlteracao = DateTime.Now,
                DataCadastro = DateTime.Now,
                NomeEquipamento = Faker.Lorem.GetFirstWord(),
                NumeroSerie = Faker.RandomNumber.Next(1, 99999).ToString(),
                TipoEquipamento = (TipoEquipamento) Faker.RandomNumber.Next(1, 3),
                Descricao = Faker.Lorem.GetFirstWord(),
                TipoAlarme = (TipoAlarme)Faker.RandomNumber.Next(1,3),
                // Alarme =
                // {
                //     Id = Guid.NewGuid(),
                //     Ativo = true,
                //     Descricao = Faker.Lorem.GetFirstWord(),
                //     DataAlteracao = DateTime.Now,
                //     DataCadastro = DateTime.Now,
                //     TipoAlarme = TipoAlarme.Alto,
                //     Equipamento = new Equipamento
                //     {
                //         Id = Guid.NewGuid(),
                //         DataAlteracao = DateTime.Now,
                //         DataCadastro = DateTime.Now,
                //         NomeEquipamento = Faker.Lorem.GetFirstWord(),
                //         NumeroSerie = Faker.Lorem.GetFirstWord(),
                //         TipoEquipamento = TipoEquipamento.Corrente
                //     }
                // }
            };
        }
    }
    
}