using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoAcademiaAPI.Models
{
    public class Exercicio
    {
        [Key]
        [DisplayName("Identificador")]
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
        public ICollection<AlunoUsuario> Alunos { get; set; }
        public ICollection<TarefaSemanal> Tarefas { get; set; }

    }
}
