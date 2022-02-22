using MedGrupo.Domain.Entities;
using MedGrupo.Services.DTO;
using MedGrupo.Services.Error;
using System;

namespace MedGrupo.Services.Validations
{
    public static class Validation
    {
        public static int CalculaIdade(DateTime datetime)
        {
            int idade = DateTime.Now.Year - datetime.Year;
            if (DateTime.Now.DayOfYear < datetime.DayOfYear)
            {
                return idade - 1;
            }
            return idade;
        }
        public static ErrorMessage ValidarDados(Pessoa obj)
        {
            var validacao = new ErrorMessage() { Valido = true };

            if (obj.DataNascimento > DateTime.Now)
                validacao = new ErrorMessage() { Valido = false, Erro = "Data de nascimento é maior que a data atual" };

            if (obj.Idade < 18)
                validacao = new ErrorMessage() { Valido = false, Erro = "O contato tem que ser maior de idade" };

            return validacao;
        }

    }
}
