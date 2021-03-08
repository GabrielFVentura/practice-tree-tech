using System;
using System.Threading.Tasks;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.DataContext;
using Infrastructure.Repository;
using Infrastructure.Test.Fakers;
using Infrastructure.Test.Tests.Base;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Infrastructure.Test.Tests.RepositoriesTest
{
    public class EquipamentoCrudRepositoryTest :  BaseRepositoryTest, IClassFixture<BaseRepositoryTest.DB_Teste>
    {
        private ServiceProvider _serviceProvider;

        public EquipamentoCrudRepositoryTest(DB_Teste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }
        
        [Fact]
        public async Task Cadastrar_Equipamento_Com_Sucesso()
        {
            using (var context = _serviceProvider.GetService<TreeTechContext>())
            {
                EquipamentoRepository _repository = new EquipamentoRepository(context);

                Equipamento _entity = EquipamentoFaker.GerarEntidadeEquipamento();

                var _registroCriado = await _repository.CadastrarAsync(_entity);

                VerificarParametrosObrigatoriosEquipamento(_registroCriado, _entity)                                  ;
            }
        }

        private void VerificarParametrosObrigatoriosEquipamento(Equipamento _registro, Equipamento _registroTeste)
        {
            _registro.Should().NotBe(null);
            _registro.NomeEquipamento.Should().Be(_registroTeste.NomeEquipamento);
            _registro.NumeroSerie.Should().Be(_registroTeste.NumeroSerie);
            _registro.TipoEquipamento.Should().Be(_registroTeste.TipoEquipamento);
            _registro.DataAlteracao.Should().Be(_registroTeste.DataAlteracao);
            _registro.DataCadastro.Should().Be(_registroTeste.DataCadastro);
            _registro.Id.Should().NotBe(Guid.Empty);
        }
    }
}