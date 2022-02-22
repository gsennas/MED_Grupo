using MedGrupo.Domain.Enum;
using MedGrupo.Domain.Error;
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

        public ErrorMessage ValidarDados()
        {
            var validacao = new ErrorMessage() { Valido = true };

            if (DataNascimento > DateTime.Now)
                validacao = new ErrorMessage() { Valido = false, Erro = "Data de nascimento é maior que a data atual" };

            if (Idade < 18)
                validacao = new ErrorMessage() { Valido = false, Erro = "O contato tem que ser maior de idade" };

            return validacao;
        }

        public int CalculaIdade()
        {
            int idade = DateTime.Now.Year - DataNascimento.Year;
            
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
                return idade - 1;
            
            return idade;
        }
    }
}
