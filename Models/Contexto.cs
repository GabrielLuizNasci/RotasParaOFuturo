using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace RotasParaOFuturo.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }


        //public DbSet<Parceiro> Parceiros { get; set; }
        //public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
       // public DbSet<Responsavel> Responsaveis { get; set; }
        //public DbSet<Visita> Visitas { get; set; }
       // public DbSet<Admin> Admins { get; set; }
       // public DbSet<Curso> Cursos { get; set; }
        //public DbSet<Turma> Turma { get; set; }
        //public DbSet<Atividade> Atividade { get; set; }
        //public DbSet<Professor> Professor { get; set; }




    }
}
