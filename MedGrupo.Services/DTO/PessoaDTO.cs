using MedGrupo.Domain.Entities;
using MedGrupo.Domain.Enum;
using MedGrupo.Services.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace MedGrupo.Services.DTO
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public Sexo Sexo { get; set; }
        public bool Status { get; set; }

        public string MsgError { get; set; }


        
    }
}
