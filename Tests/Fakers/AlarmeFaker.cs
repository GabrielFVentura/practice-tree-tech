using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Enum;

namespace Infrastructure.Test.Fakers
{
    public class AlarmeFaker
    {
        public AlarmeFaker()
        {
            
        }
        
        public static Alarme GerarEntidadeAlarme()
        {
            return new()
            {
                Descricao = Faker.Lorem.GetFirstWord(),
                TipoAlarme = (TipoAlarme)Faker.RandomNumber.Next(1,3),
                Ativo = true,
                DataAlteracao = Faker.DateOfBirth.Next(),
                DataCadastro = Faker.DateOfBirth.Next(),
                IdEquipamento = Guid.NewGuid(),
                Equipamento = new Equipamento
                {
                    Id = Guid.NewGuid(),
                    DataCadastro = Faker.DateOfBirth.Next(),
                    DataAlteracao = Faker.DateOfBirth.Next(),
                    NomeEquipamento = Faker.Lorem.GetFirstWord(),
                    NumeroSerie = Faker.RandomNumber.Next(1,200000).ToString(),
                    TipoEquipamento = (TipoEquipamento)Faker.RandomNumber.Next(1,3)
                }
            };
        }
        
        public static IList<Alarme> GerarCollectionEntidadeAlarme()
        {
            return new List<Alarme>
            {
                new()
                {
                    Descricao = Faker.Lorem.GetFirstWord(),
                    TipoAlarme = (TipoAlarme) Faker.RandomNumber.Next(1, 3),
                    Ativo = true,
                    DataAlteracao = Faker.DateOfBirth.Next(),
                    DataCadastro = Faker.DateOfBirth.Next(),
                    IdEquipamento = Guid.NewGuid(),
                    Equipamento = new Equipamento
                    {
                        Id = Guid.NewGuid(),
                        DataCadastro = Faker.DateOfBirth.Next(),
                        DataAlteracao = Faker.DateOfBirth.Next(),
                        NomeEquipamento = Faker.Lorem.GetFirstWord(),
                        NumeroSerie = Faker.RandomNumber.Next(1, 200000).ToString(),
                        TipoEquipamento = (TipoEquipamento) Faker.RandomNumber.Next(1, 3)
                    }
                },
                new()
                {
                    Descricao = Faker.Lorem.GetFirstWord(),
                    TipoAlarme = (TipoAlarme) Faker.RandomNumber.Next(1, 3),
                    Ativo = true,
                    DataAlteracao = Faker.DateOfBirth.Next(),
                    DataCadastro = Faker.DateOfBirth.Next(),
                    IdEquipamento = Guid.NewGuid(),
                    Equipamento = new Equipamento
                    {
                        Id = Guid.NewGuid(),
                        DataCadastro = Faker.DateOfBirth.Next(),
                        DataAlteracao = Faker.DateOfBirth.Next(),
                        NomeEquipamento = Faker.Lorem.GetFirstWord(),
                        NumeroSerie = Faker.RandomNumber.Next(1, 200000).ToString(),
                        TipoEquipamento = (TipoEquipamento) Faker.RandomNumber.Next(1, 3)
                    }
                },
                new()
                {
                    Descricao = Faker.Lorem.GetFirstWord(),
                    TipoAlarme = (TipoAlarme) Faker.RandomNumber.Next(1, 3),
                    Ativo = true,
                    DataAlteracao = Faker.DateOfBirth.Next(),
                    DataCadastro = Faker.DateOfBirth.Next(),
                    IdEquipamento = Guid.NewGuid(),
                    Equipamento = new Equipamento
                    {
                        Id = Guid.NewGuid(),
                        DataCadastro = Faker.DateOfBirth.Next(),
                        DataAlteracao = Faker.DateOfBirth.Next(),
                        NomeEquipamento = Faker.Lorem.GetFirstWord(),
                        NumeroSerie = Faker.RandomNumber.Next(1, 200000).ToString(),
                        TipoEquipamento = (TipoEquipamento) Faker.RandomNumber.Next(1, 3)
                    }
                }
            };
        }
    }
}