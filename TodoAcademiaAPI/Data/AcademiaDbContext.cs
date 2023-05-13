using Microsoft.EntityFrameworkCore;
using TodoAcademiaAPI.Models;

namespace TodoAcademiaAPI.Data
{
    public class AcademiaDbContext : DbContext
    {
        public AcademiaDbContext(DbContextOptions<AcademiaDbContext> options) : base(options) { }

        public DbSet<AlunoUsuario> Alunos { get; set; }        
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<ProfessorUsuario> Professores { get; set; }
        public DbSet<TarefaSemanal> TarefasSemanais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
