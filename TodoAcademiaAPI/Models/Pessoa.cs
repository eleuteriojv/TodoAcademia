using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TodoAcademiaAPI.Models
{
    public class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }
        public string NomeCompleto { get; set; }
        [Required(ErrorMessage = "Necessário preencher o CEP")]
        [DisplayName("CEP")]
        public int Cep { get; set; }
        [Required(ErrorMessage = "Necessário preencher logradouro")]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }
        [DisplayName("Complemento")]
        public string Rua { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Necessário preencher o CPF")]
        [DisplayName("CPF")]
        public int Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Necessário escolher seu perfil")]
        [DisplayName("Tipo de Perfil")]
        public string Tipo { get; set; }
        public bool Status { get; set; }
        public int IdAlunoUsuario { get; set; }
        public int IdProfessorUsuario { get; set; }
        public AlunoUsuario Aluno { get; set; } 
        public ProfessorUsuario Professor { get; set; } 
    }
}
