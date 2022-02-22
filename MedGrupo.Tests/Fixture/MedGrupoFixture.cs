using MedGrupo.Data.Context;
using MedGrupo.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedGrupo.Tests.Fixture
{
    public class MedGrupoFixture
    {
        public IMedGrupoContext MedGrupoContext { get; set; }

        public MedGrupoFixture()
        {
            ConfigureContext();
        }

        private void ConfigureContext()
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<MedGrupoContext>()
                            .UseInMemoryDatabase(databaseName: "MedGrupoDB")
                            .Options;

            MedGrupoContext = new MedGrupoContext(options);
        }
    }
}