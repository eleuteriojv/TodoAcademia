using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoAcademiaWEB.ViewModels
{
    public class TarefaSemanalViewModel
    {
        public int IdTarefaSemanal { get; set; }
        [Required(ErrorMessage = "Necessário preencher a data de início")]
        [DisplayName("Data de Início")]
        public DateTime DataInicio { get; set; }
        [Required(ErrorMessage = "Necessário preencher a data de fim")]
        [DisplayName("Data Final")]
        public DateTime DataFim { get; set; }
        public int IdExercicio { get; set; }
        public int IdAlunoUsuario { get; set; }
        public ExercicioViewModel Exercicio { get; set; }
        public AlunoUsuarioViewModel Aluno { get; set; }
        public ICollection<ProfessorUsuarioViewModel> Professores { get; set; }
    }
}
