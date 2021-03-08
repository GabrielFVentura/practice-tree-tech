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
    public class AlarmeAtuadoCrudRepositoryTest :  BaseRepositoryTest, IClassFixture<BaseRepositoryTest.DB_Teste>
    {
        private ServiceProvider _serviceProvider;

        public AlarmeAtuadoCrudRepositoryTest(DB_Teste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }
        
        [Fact]
        public async Task Cadastrar_AlarmeAtuado_Com_Sucesso()
        {
            using (var context = _serviceProvider.GetService<TreeTechContext>())
            {
                AlarmeAtuadoRepository _repository = new AlarmeAtuadoRepository(context);
                AlarmeRepository _alarmeRepository = new AlarmeRepository(context);

                var alarme = AlarmeFaker.GerarEntidadeAlarme();
                var alarmeCadastrado = await _alarmeRepository.CadastrarAsync(alarme);
                
                AlarmeAtuado _entity = AlarmeAtuadoFaker.GerarEntidadeAlarmeAtuado();
                _entity.Alarme = alarmeCadastrado;

                var _registroCriado = await _repository.CadastrarAsync(_entity);

                VerificarParametrosObrigatoriosAlarmeAtuado(_registroCriado, _entity)                                  ;
            }
        }

        private void VerificarParametrosObrigatoriosAlarmeAtuado(AlarmeAtuado _registro, AlarmeAtuado _registroTeste)
        {
            _registro.Should().NotBe(null);
            _registro.Alarme.Should().NotBe(null);
            _registro.IdAlarme.Should().NotBe(Guid.Empty);
            _registro.NomeEquipamento.Should().Be(_registroTeste.NomeEquipamento);
            _registro.NumeroSerie.Should().Be(_registroTeste.NumeroSerie);
            _registro.TipoEquipamento.Should().Be(_registroTeste.TipoEquipamento);
            _registro.DataAlteracao.Should().Be(_registroTeste.DataAlteracao);
            _registro.DataCadastro.Should().Be(_registroTeste.DataCadastro);
            _registro.Id.Should().NotBe(Guid.Empty);
        }
    }
}