using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoAcademiaWEB.ViewModels
{
    public class ExercicioViewModel
    {
        public int IdExercicio { get; set; }
        [Required(ErrorMessage = "É necessário preencher o nome do exercício")]
        [DisplayName("Nome do Exercício")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "É necessário preencher o tipo do exercício")]
        [DisplayName("Tipo")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "É necessário preencher a descrição do exercício")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "É necessário preencher a serie")]
        [DisplayName("Serie")]
        public string Serie { get; set; }
        public ICollection<AlunoUsuarioViewModel> Alunos { get; set; }
        public ICollection<TarefaSemanalViewModel> Tarefas { get; set; }
    }
}
