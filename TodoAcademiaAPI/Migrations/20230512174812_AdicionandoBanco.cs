using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoAcademiaAPI.Migrations
{
    public partial class AdicionandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    IdExercicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.IdExercicio);
                });

            migrationBuilder.CreateTable(
                name: "AlunoUsuarioExercicio",
                columns: table => new
                {
                    AlunosIdAlunoUsuario = table.Column<int>(type: "int", nullable: false),
                    ExerciciosIdExercicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoUsuarioExercicio", x => new { x.AlunosIdAlunoUsuario, x.ExerciciosIdExercicio });
                    table.ForeignKey(
                        name: "FK_AlunoUsuarioExercicio_Exercicios_ExerciciosIdExercicio",
                        column: x => x.ExerciciosIdExercicio,
                        principalTable: "Exercicios",
                        principalColumn: "IdExercicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<int>(type: "int", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IdAlunoUsuario = table.Column<int>(type: "int", nullable: false),
                    IdProfessorUsuario = table.Column<int>(type: "int", nullable: false),
                    AlunoIdAlunoUsuario = table.Column<int>(type: "int", nullable: true),
                    ProfessorIdProfessorUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "TarefasSemanais",
                columns: table => new
                {
                    IdTarefaSemanal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdExercicio = table.Column<int>(type: "int", nullable: false),
                    IdAlunoUsuario = table.Column<int>(type: "int", nullable: false),
                    ExercicioIdExercicio = table.Column<int>(type: "int", nullable: true),
                    AlunoIdAlunoUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarefasSemanais", x => x.IdTarefaSemanal);
                    table.ForeignKey(
                        name: "FK_TarefasSemanais_Exercicios_ExercicioIdExercicio",
                        column: x => x.ExercicioIdExercicio,
                        principalTable: "Exercicios",
                        principalColumn: "IdExercicio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    IdProfessorUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarefaSemanalIdTarefaSemanal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.IdProfessorUsuario);
                    table.ForeignKey(
                        name: "FK_Professores_TarefasSemanais_TarefaSemanalIdTarefaSemanal",
                        column: x => x.TarefaSemanalIdTarefaSemanal,
                        principalTable: "TarefasSemanais",
                        principalColumn: "IdTarefaSemanal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAlunoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfessorUsuario = table.Column<int>(type: "int", nullable: false),
                    ProfessorIdProfessorUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAlunoUsuario);
                    table.ForeignKey(
                        name: "FK_Alunos_Professores_ProfessorIdProfessorUsuario",
                        column: x => x.ProfessorIdProfessorUsuario,
                        principalTable: "Professores",
                        principalColumn: "IdProfessorUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ProfessorIdProfessorUsuario",
                table: "Alunos",
                column: "ProfessorIdProfessorUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoUsuarioExercicio_ExerciciosIdExercicio",
                table: "AlunoUsuarioExercicio",
                column: "ExerciciosIdExercicio");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_AlunoIdAlunoUsuario",
                table: "Pessoas",
                column: "AlunoIdAlunoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_ProfessorIdProfessorUsuario",
                table: "Pessoas",
                column: "ProfessorIdProfessorUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_TarefaSemanalIdTarefaSemanal",
                table: "Professores",
                column: "TarefaSemanalIdTarefaSemanal");

            migrationBuilder.CreateIndex(
                name: "IX_TarefasSemanais_AlunoIdAlunoUsuario",
                table: "TarefasSemanais",
                column: "AlunoIdAlunoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TarefasSemanais_ExercicioIdExercicio",
                table: "TarefasSemanais",
                column: "ExercicioIdExercicio");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoUsuarioExercicio_Alunos_AlunosIdAlunoUsuario",
                table: "AlunoUsuarioExercicio",
                column: "AlunosIdAlunoUsuario",
                principalTable: "Alunos",
                principalColumn: "IdAlunoUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Alunos_AlunoIdAlunoUsuario",
                table: "Pessoas",
                column: "AlunoIdAlunoUsuario",
                principalTable: "Alunos",
                principalColumn: "IdAlunoUsuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Professores_ProfessorIdProfessorUsuario",
                table: "Pessoas",
                column: "ProfessorIdProfessorUsuario",
                principalTable: "Professores",
                principalColumn: "IdProfessorUsuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TarefasSemanais_Alunos_AlunoIdAlunoUsuario",
                table: "TarefasSemanais",
                column: "AlunoIdAlunoUsuario",
                principalTable: "Alunos",
                principalColumn: "IdAlunoUsuario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Professores_ProfessorIdProfessorUsuario",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "AlunoUsuarioExercicio");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "TarefasSemanais");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Exercicios");
        }
    }
}
