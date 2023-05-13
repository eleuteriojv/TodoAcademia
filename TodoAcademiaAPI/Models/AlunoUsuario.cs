using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoAcademiaAPI.Models
{
    public class AlunoUsuario
    {
        [Key]
        [DisplayName("Matrícula")]
        public int IdAlunoUsuario { get; set; }
        public int IdProfessorUsuario { get; set; }
        public ProfessorUsuario Professor { get; set; }
        public ICollection<Pessoa> Pessoas { get; set; }
        public ICollection<Exercicio> Exercicios { get; set; }
        public ICollection<TarefaSemanal> Tarefas { get; set; }
        

    }
}
