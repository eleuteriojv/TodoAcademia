using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoAcademiaWEB.ViewModels
{
    public class ProfessorUsuarioViewModel
    {
        public int IdProfessorUsuario { get; set; }
        [Required(ErrorMessage = "Necessário preencher o CPF")]
        public ICollection<AlunoUsuarioViewModel> Alunos { get; set; }
    }
}
