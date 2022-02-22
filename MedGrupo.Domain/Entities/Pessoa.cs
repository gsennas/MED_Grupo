using MedGrupo.Domain.Enum;
using System;

namespace MedGrupo.Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public Sexo Sexo { get; set; }
        public bool Status { get; set; }

     
    }
}
