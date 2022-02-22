using MedGrupo.Data.Interfaces;
using MedGrupo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedGrupo.Data.Context
{
    public class MedGrupoContext : DbContext, IMedGrupoContext
    {
        public MedGrupoContext(DbContextOptions<MedGrupoContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pessoa>().Property(p => p.Nome).IsRequired();
        }
    }
}
