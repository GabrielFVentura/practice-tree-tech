using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Filtros;
using FluentAssertions;
using Infrastructure.DataContext;
using Infrastructure.Repository;
using Infrastructure.Test.Fakers;
using Infrastructure.Test.Tests.Base;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Infrastructure.Test.Tests.RepositoriesTest
{
    public class AlarmeCrudRepositoryTest : BaseRepositoryTest, IClassFixture<BaseRepositoryTest.DB_Teste>
    {
        private ServiceProvider _serviceProvider;

        public AlarmeCrudRepositoryTest(DB_Teste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }
        
        [Fact]
        public async Task Cadastrar_Alarme_Com_Sucesso()
        {
            using (var context = _serviceProvider.GetService<TreeTechContext>())
            {
                AlarmeRepository _repository = new AlarmeRepository(context);

                Alarme _entity = AlarmeFaker.GerarEntidadeAlarme();

                var _registroCriado = await _repository.CadastrarAsync(_entity);

                VerificarParametrosObrigatoriosAlarme(_registroCriado, _entity)                                  ;
            }
        }
        
        [Fact]
        public async Task Buscar_Alarme_Com_Sucesso()
        {
            using (var context = _serviceProvider.GetService<TreeTechContext>())
            {
                AlarmeRepository _repository = new AlarmeRepository(context);

                Alarme _entity = AlarmeFaker.GerarEntidadeAlarme();
                var _registroCadastrado = await _repository.CadastrarAsync(_entity);
    
                var _registroBuscado = await _repository.BuscarAsync(_registroCadastrado.Id);

                VerificarParametrosObrigatoriosAlarme(_registroBuscado, _registroCadastrado);
            }
        }
        
        [Fact]
        public async Task Atualizar_Alarme_Com_Sucesso()
        {
            using (var context = _serviceProvider.GetService<TreeTechContext>())
            {
                AlarmeRepository _repository = new AlarmeRepository(context);

                Alarme _entity = AlarmeFaker.GerarEntidadeAlarme();
                await _repository.CadastrarAsync(_entity);
    
                _entity.Descricao = Faker.Lorem.GetFirstWord();
                var _registroAtualizado = await _repository.AtualizarAsync(_entity);

                VerificarParametrosObrigatoriosAlarme(_registroAtualizado, _entity);
            }
        }
        
        [Fact]
        public async Task Deletar_Alarme_Com_Sucesso()
        {
            using (var context = _serviceProvider.GetService<TreeTechContext>())
            {
                AlarmeRepository _repository = new AlarmeRepository(context);

                Alarme _entity = AlarmeFaker.GerarEntidadeAlarme();
                await _repository.CadastrarAsync(_entity);
    
                _entity.Descricao = Faker.Lorem.GetFirstWord();
                var _removido = await _repository.DeletarAsync(_entity.Id);
                var _registroBuscado = await _repository.BuscarAsync(_entity.Id);
                
                _removido.Should().BeTrue();
                _registroBuscado.Should().Be(null);
            }
        }
        
        [Fact]
        public async Task Buscar_Alarme_Por_Id_Equipamento_Deve_Retornar_Alarme()
        {
            using (var context = _serviceProvider.GetService<TreeTechContext>())
            {
                AlarmeRepository _repository = new AlarmeRepository(context);

                Alarme _entity = AlarmeFaker.GerarEntidadeAlarme();
                await _repository.CadastrarAsync(_entity);
    
                var _registroBuscado = _repository.BuscarPorIdEquipamento(_entity.Equipamento.Id).Result.First();

                VerificarParametrosObrigatoriosAlarme(_registroBuscado, _entity);
            }
        }
        
        [Fact]
        public async Task Buscar_Alarme_Com_Filtro_Com_Sucesso()
        {
            using (var context = _serviceProvider.GetService<TreeTechContext>())
            {
                AlarmeRepository _repository = new AlarmeRepository(context);

                Alarme _entity = AlarmeFaker.GerarEntidadeAlarme();
                var filtro = new FiltroAlarme();
                
                var _registroCadastrado = await _repository.CadastrarAsync(_entity);
                var _registroBuscado = _repository.BuscarPorFiltro(filtro).Result.First();
                
                VerificarParametrosObrigatoriosAlarme(_registroBuscado, _registroCadastrado);

                filtro.Ativo = true;
                _registroBuscado = _repository.BuscarPorFiltro(filtro).Result.First();
                VerificarParametrosObrigatoriosAlarme(_registroBuscado, _registroCadastrado);
                
                filtro.Descricao = _entity.Descricao;
                _registroBuscado = _repository.BuscarPorFiltro(filtro).Result.First();
                VerificarParametrosObrigatoriosAlarme(_registroBuscado, _registroCadastrado);
                
                filtro.DataCadastro = _entity.DataCadastro;
                _registroBuscado = _repository.BuscarPorFiltro(filtro).Result.First();
                VerificarParametrosObrigatoriosAlarme(_registroBuscado, _registroCadastrado);
                
                filtro.NomeEquipamento = _entity.Equipamento.NomeEquipamento;
                _registroBuscado = _repository.BuscarPorFiltro(filtro).Result.First();
                VerificarParametrosObrigatoriosAlarme(_registroBuscado, _registroCadastrado);
                
                filtro.NumeroSerie = _entity.Equipamento.NumeroSerie;
                _registroBuscado = _repository.BuscarPorFiltro(filtro).Result.First();
                VerificarParametrosObrigatoriosAlarme(_registroBuscado, _registroCadastrado);
                
                filtro.TipoAlarme = _entity.TipoAlarme;
                _registroBuscado = _repository.BuscarPorFiltro(filtro).Result.First();
                VerificarParametrosObrigatoriosAlarme(_registroBuscado, _registroCadastrado);
                
                filtro.TipoEquipamento = _entity.Equipamento.TipoEquipamento;
                _registroBuscado = _repository.BuscarPorFiltro(filtro).Result.First();
                VerificarParametrosObrigatoriosAlarme(_registroBuscado, _registroCadastrado);
            }
        }

        private static void VerificarParametrosObrigatoriosAlarme(Alarme _registro, Alarme _registroTeste)
        {
            _registro.Should().NotBe(null);
            _registro.Descricao.Should().Be(_registroTeste.Descricao);
            _registro.TipoAlarme.Should().Be(_registroTeste.TipoAlarme);
            _registro.Ativo.Should().Be(_registroTeste.Ativo);
            _registro.DataAlteracao.Should().Be(_registroTeste.DataAlteracao);
            _registro.DataCadastro.Should().Be(_registroTeste.DataCadastro);
            _registro.IdEquipamento.Should().Be(_registroTeste.IdEquipamento);
            _registro.Id.Should().NotBe(Guid.Empty);

            _registro.Equipamento.Id.Should().NotBe(Guid.Empty);
            _registro.Equipamento.DataCadastro.Should().Be(_registroTeste.Equipamento.DataCadastro);
            _registro.Equipamento.DataAlteracao.Should().Be(_registroTeste.Equipamento.DataAlteracao);
            _registro.Equipamento.NomeEquipamento.Should().Be(_registroTeste.Equipamento.NomeEquipamento);
            _registro.Equipamento.NumeroSerie.Should().Be(_registroTeste.Equipamento.NumeroSerie);
            _registro.Equipamento.TipoEquipamento.Should().Be(_registroTeste.Equipamento.TipoEquipamento);
        }
    }
}