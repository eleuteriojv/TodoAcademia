using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoAcademiaAPI.Models
{
    public class ProfessorUsuario
    {
        [Key]
        [DisplayName("Matrícula")]
        public int IdProfessorUsuario { get; set; }
        [Required(ErrorMessage = "Necessário preencher o CPF")]
        public ICollection<AlunoUsuario> Alunos { get; set; }
    }
}
