using MedGrupo.Data.Interfaces;
using MedGrupo.Data.Repositories;
using MedGrupo.Domain.Entities;
using MedGrupo.Domain.Enum;
using MedGrupo.Tests.Fixture;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace MedGrupo.Tests.PessoaTests
{
    public class PessoaTest : IClassFixture<MedGrupoFixture>
    {
        MedGrupoFixture _medGrupoFixture;
        IPessoaRepository _pessoaRepository;

        public PessoaTest(MedGrupoFixture medGrupoFixture)
        {
            _medGrupoFixture = medGrupoFixture;
            _pessoaRepository = new PessoaRepository(_medGrupoFixture.MedGrupoContext);
        }

        [Fact(DisplayName = "PessoaRepository Create - Sucesso")]
        public async Task CreateTest()
        {
            //Arrange
            var pessoa = GetPessoaObject();

            //Act
            var result = await _pessoaRepository.CreateAsync(pessoa);

            //Assert
            result.Id.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "PessoaRepository Edit - Sucesso")]
        public async Task CreateTestWithError()
        {
            // Arrange
            var pessoa = GetPessoaObject();
            pessoa.Nome = "Nome alterado";

            //Act
            var result = await _pessoaRepository.EditAsync(pessoa);

            //Assert
            result.Nome.Should().Be("Nome alterado");
        }
       
        private Pessoa GetPessoaObject()
        {
            return new Pessoa
            {
                Nome = "Teste",
                DataNascimento = DateTime.Now.AddYears(-20),
                Sexo = Sexo.Masculino
            };
        }
       
    }
}
