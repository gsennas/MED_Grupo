using MedGrupo.Data.Interfaces;
using MedGrupo.Domain.Entities;
using MedGrupo.Domain.Error;
using MedGrupo.Services.DTO;
using MedGrupo.Services.Interfaces;
using MedGrupo.Services.Validations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedGrupo.Services.Services
{
    public class PessoaServices : IPessoaServices
    {
        private readonly IPessoaRepository _repo;

        public PessoaServices(IPessoaRepository repository)
        {
            _repo = repository;
        }

        public async Task<List<PessoaDTO>> GetAsync()
        {
            var pessoas = await _repo.GetAsync();
            return pessoas.Select(x => new PessoaDTO 
            {
                DataNascimento = x.DataNascimento,
                Id = x.Id,
                Idade = x.Idade,
                Nome = x.Nome,
                Sexo = x.Sexo,
                Status = x.Status
            }).ToList();
        }

        public async Task<PessoaDTO> GetIdAsync(int id)
        {
            var pessoa = await _repo.GetIdAsync(id);
            return TrasformaPessoaParaDTO(pessoa);
        }

        private PessoaDTO TrasformaPessoaParaDTO(Pessoa pessoa)
        {
            var pessoaDTO = new PessoaDTO()
            {
                Nome = pessoa.Nome,
                Idade = Validation.CalculaIdade(pessoa.DataNascimento),
                Status = pessoa.Status,
                DataNascimento = pessoa.DataNascimento,
                Sexo = pessoa.Sexo
            };
            return pessoaDTO;
        }


        private Pessoa TrasformaDTO(PessoaDTO obj)
        {
            var model = new Pessoa()
            {
                Nome = obj.Nome,
                Idade = Validation.CalculaIdade(obj.DataNascimento),
                Status = obj.Status,
                DataNascimento = obj.DataNascimento,
                Sexo = obj.Sexo
            };
            return model;
        }

        private Pessoa TrasformaDTOID(PessoaDTO obj)
        {
            var model = new Pessoa()
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Idade = Validation.CalculaIdade(obj.DataNascimento),
                Status = obj.Status,
                DataNascimento = obj.DataNascimento,
                Sexo = obj.Sexo
            };
            return model;

        }

        public async Task<PessoaDTO> CreateAsync(PessoaDTO pessoaDTO)
        {
            var pessoa = TrasformaDTO(pessoaDTO);
            pessoa.Status = true;
            pessoa.Idade = pessoa.CalculaIdade();
            var result = pessoa.ValidarDados();
            if (!result.Valido) 
            {
                pessoaDTO.MsgError = result.Erro;
                return pessoaDTO;
            }

            await _repo.CreateAsync(pessoa);
            return pessoaDTO;
        }

        public async Task<PessoaDTO> EditAsync(PessoaDTO pessoaDTO)
        {
            var pessoa = TrasformaDTOID(pessoaDTO);
            pessoa.Idade = pessoa.CalculaIdade();
            var result = pessoa.ValidarDados();
            if (!result.Valido)
            {
                pessoaDTO.MsgError = result.Erro;
                return pessoaDTO;
            }

            await _repo.EditAsync(pessoa);
            return pessoaDTO;
        }

        public async Task DeleteAsync(int pessoaId)
        {
            var pessoa = await _repo.GetIdAsync(pessoaId);
            if (pessoa == null)
                throw new NotFoundException("Pessoa com id: " + pessoaId +  " não encontrada");

            await _repo.DeleteAsync(pessoa);
        }
    }
}
