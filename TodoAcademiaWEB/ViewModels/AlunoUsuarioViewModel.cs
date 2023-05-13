using System.Collections.Generic;

namespace TodoAcademiaWEB.ViewModels
{
    public class AlunoUsuarioViewModel
    {
        public int IdAlunoUsuario { get; set; }
        public int IdProfessorUsuario { get; set; }
        public ProfessorUsuarioViewModel Professor { get; set; }
        public ICollection<PessoaViewModel> Pessoas { get; set; }
        public ICollection<ExercicioViewModel> Exercicios { get; set; }
        public ICollection<TarefaSemanalViewModel> Tarefas { get; set; }
    }
}
