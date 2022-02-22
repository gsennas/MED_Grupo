using MedGrupo.Data.Context;
using MedGrupo.Data.Interfaces;
using MedGrupo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MedGrupo.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IMedGrupoContext _context;

        public PessoaRepository(IMedGrupoContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> GetAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }


        public async Task<Pessoa> GetIdAsync(int? id)
        {
            return await _context.Pessoas.FirstOrDefaultAsync(m => m.Id == id && m.Status == true);
        }


        public async Task<Pessoa> CreateAsync(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync(new CancellationToken());
            return pessoa;
        }

        public async Task<Pessoa> EditAsync(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync(new CancellationToken());
            return pessoa;
        }
        public async Task<bool> DeleteAsync(Pessoa pessoa)
        {
            
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync(new CancellationToken());
            var teste = GetIdAsync(pessoa.Id);

            if (teste == null)
                return true;
            return false;
        }
    }
}
