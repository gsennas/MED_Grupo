using MedGrupo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MedGrupo.Data.Interfaces
{
    public interface IMedGrupoContext
    {
        DbSet<Pessoa> Pessoas { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
