using Microsoft.AspNetCore.Mvc;
using RotasParaOFuturo.Models;
using Microsoft.EntityFrameworkCore;
using RotasParaOFuturo.Controllers;
using System;
using System.Collections.Generic;

namespace RotasParaOFuturo.Controllers
{
    public class DadosController : Controller
    {
        private readonly Contexto _contexto;

        // Injeção de dependência do contexto
        public DadosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Método para gerar parceiros aleatórios
        public IActionResult Parceiros()
        {
            Random rand = new Random();

            // Lista de nomes de parceiros fictícios brasileiros
            List<string> nomesParceiros = new List<string>
            {
                "Soluções Tecnológicas Brasil", "Grupo Alfa", "Indústria Verde Ltda.",
                "Tecnologia Avançada S.A.", "Inova Brasil", "Corporativo Carvalho",
                "Rede Nova Era", "Consultoria Horizonte", "Empreendimentos São Paulo",
                "Indústria Sampa", "Grupo BrasilTech", "Desenvolvimento Sustentável",
                "Net Comunicação", "Sistemas Digitais Santos", "Vanguarda Tecnologia",
                "Futuro Digital", "Soluções Digitais Nordeste", "Engenharia Inova",
                "VivaTech Soluções", "Construtora Rio"
            };

            // Limpa a tabela de Parceiros antes de adicionar novos dados
            _contexto.Database.ExecuteSqlRaw("DELETE FROM Parceiros");
            _contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Parceiros', RESEED, 0)");

            // Gera 100 parceiros aleatórios
            for (int i = 0; i < 100; i++)
            {
                // Seleciona um nome aleatório da lista
                string nomeParceiro = nomesParceiros[rand.Next(nomesParceiros.Count)];

                Parceiro parceiro = new Parceiro
                {
                    Nome = nomeParceiro,
                    Descricao = "Descrição do parceiro " + i.ToString(),
                    DataMatricula = Convert.ToDateTime("01/01/2000").AddDays(rand.Next(1, 7300)) // Data aleatória entre 2000 e 2024
                };

                // Adiciona o parceiro ao contexto
                _contexto.Parceiros.Add(parceiro);
            }

            // Salva as alterações no banco de dados
            _contexto.SaveChanges();

            // Retorna a lista de parceiros para a View
            return View(_contexto.Parceiros.ToList());
        }
    }
}
