using MedGrupo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedGrupo.Data.Interfaces
{
    public interface IPessoaRepository
    {
        Task<List<Pessoa>> GetAsync();

        Task<Pessoa> GetIdAsync(int? id);

        Task<Pessoa> CreateAsync(Pessoa pessoa);

        Task<Pessoa> EditAsync(Pessoa pessoa);
        
        Task<bool> DeleteAsync(Pessoa pessoa);
    }
}
