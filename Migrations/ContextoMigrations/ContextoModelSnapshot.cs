﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RotasParaOFuturo.Models;

#nullable disable

namespace RotasParaOFuturo.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RotasParaOFuturo.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Periodo")
                        .HasColumnType("int");

                    b.Property<int>("TotalAulas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Atividades");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataMatricula")
                        .HasColumnType("datetime2");

                    b.Property<int>("Faltas")
                        .HasColumnType("int");

                    b.Property<int>("Presenca")
                        .HasColumnType("int");

                    b.Property<int>("RA")
                        .HasColumnType("int");

                    b.Property<int>("alunoID")
                        .HasColumnType("int");

                    b.Property<int>("turmaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("alunoID");

                    b.HasIndex("turmaID");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Parceiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataMatricula")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Parceiros");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("parceiroID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("parceiroID");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Responsavel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("aniversario")
                        .HasColumnType("datetime2");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("local")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("profissao")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<float>("renda")
                        .HasColumnType("real");

                    b.Property<string>("rg")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("tel")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Responsaveis");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("atividadeID")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("periodo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("atividadeID");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Visita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("datavisita")
                        .HasColumnType("datetime2");

                    b.Property<string>("descricao")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int>("responsavelID")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("responsavelID");

                    b.ToTable("Visitas");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Matricula", b =>
                {
                    b.HasOne("RotasParaOFuturo.Models.Aluno", "aluno")
                        .WithMany()
                        .HasForeignKey("alunoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RotasParaOFuturo.Models.Turma", "turma")
                        .WithMany("Matriculas")
                        .HasForeignKey("turmaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("aluno");

                    b.Navigation("turma");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Professor", b =>
                {
                    b.HasOne("RotasParaOFuturo.Models.Parceiro", "parceiro")
                        .WithMany()
                        .HasForeignKey("parceiroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("parceiro");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Turma", b =>
                {
                    b.HasOne("RotasParaOFuturo.Models.Atividade", "atividade")
                        .WithMany()
                        .HasForeignKey("atividadeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("atividade");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Visita", b =>
                {
                    b.HasOne("RotasParaOFuturo.Models.Responsavel", "responsavel")
                        .WithMany()
                        .HasForeignKey("responsavelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("responsavel");
                });

            modelBuilder.Entity("RotasParaOFuturo.Models.Turma", b =>
                {
                    b.Navigation("Matriculas");
                });
#pragma warning restore 612, 618
        }
    }
}
