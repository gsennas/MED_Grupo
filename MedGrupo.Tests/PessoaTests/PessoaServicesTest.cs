using FluentAssertions;
using MedGrupo.Data.Interfaces;
using MedGrupo.Domain.Enum;
using MedGrupo.Services.DTO;
using MedGrupo.Services.Interfaces;
using MedGrupo.Services.Services;
using MedGrupo.Tests.Fixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedGrupo.Tests.PessoaTests
{
    public class PessoaServicesTest : IClassFixture<MedGrupoFixture>
    {
        MedGrupoFixture _medGrupoFixture;
        IPessoaServices _pessoaServices;
        private readonly Mock<IPessoaRepository> _pessoaRepository;
        public PessoaServicesTest()
        {
            _pessoaRepository = new Mock<IPessoaRepository>();
            _pessoaServices = new PessoaServices(_pessoaRepository.Object);
        }

        [Fact(DisplayName = "PessoaServices Create - Sucesso")]
        public async Task CreateTest()
        {
            //Arrange
            var pessoaDto = GetPessoaDTO();

            //Act
            var result = _pessoaServices.CreateAsync(pessoaDto);

            //Assert
            result.Id.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "PessoaServices Create - Erro")]
        public async Task CreateTestWithError()
        {
            //Arrange
            var pessoaDto = GetPessoaDTO();
            pessoaDto.DataNascimento = DateTime.Now;

            //Act
            var result = await _pessoaServices.CreateAsync(pessoaDto);

            //Assert
            result.Id.Should().Be(0);
        }

        private PessoaDTO GetPessoaDTO()
        {
            return new PessoaDTO
            {
                Nome = "Teste",
                DataNascimento = DateTime.Now.AddYears(-20),
                Sexo = Sexo.Masculino
            };
        }
        
    }
}
