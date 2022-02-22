using MedGrupo.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedGrupo.Services.Interfaces
{
    public interface IPessoaServices
    {
        Task<List<PessoaDTO>> GetAsync();

        Task<PessoaDTO> GetIdAsync(int id);


        Task<PessoaDTO> CreateAsync(PessoaDTO pessoa);

        Task<PessoaDTO> EditAsync(PessoaDTO pessoa);

        Task DeleteAsync(int pessoaId);
    }
}
