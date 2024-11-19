using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace RotasParaOFuturo.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<Visita> Visitas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Professor> Professores { get; set; }
    }
}
