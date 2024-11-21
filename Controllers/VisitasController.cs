using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RotasParaOFuturo.Models;

namespace CurricularizacaoADS2024.Controllers
{
    public class VisitasController : Controller
    {
        private readonly Contexto _context;

        public VisitasController(Contexto context)
        {
            _context = context;
        }



        public IActionResult GerarDadosVisitas()
        {
            Random rand = new Random();

            // Limpa os dados existentes
            _context.Database.ExecuteSqlRaw("DELETE FROM Visitas");
            _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Visitas', RESEED, 0)");

            // Obtém a lista de responsáveis cadastrados
            var responsaveis = _context.Responsaveis.ToList();

            // Verifica se existem responsáveis no banco de dados
            if (!responsaveis.Any())
            {
                // Se não houver responsáveis, exibe uma mensagem ou lida como um erro
                return Content("Não há responsáveis cadastrados para associar às visitas.");
            }

            // Gera 100 visitas
            for (int i = 0; i < 100; i++)
            {
                Visita visita = new Visita
                {
                    // Seleciona um responsável aleatório da lista de responsáveis
                    responsavelID = responsaveis[rand.Next(responsaveis.Count)].Id,

                    // Gera uma data aleatória dentro de 50 anos a partir de 01/01/2020
                    datavisita = Convert.ToDateTime("01/01/2020").AddDays(rand.Next(1, 18260)),

                    descricao = "Descrição " + i,

                    // Gera um status aleatório entre 1 e 2
                    status = rand.Next(1, 3)
                };

                _context.Visitas.Add(visita);
            }

            // Salva as mudanças no banco de dados
            _context.SaveChanges();

            return View("Index", _context.Visitas.Include(v => v.responsavel).ToList());
        }









        // GET: Visitas
        public async Task<IActionResult> Index(string nome, DateTime? dataVisita)
        {
            var contexto = _context.Visitas.Include(v => v.responsavel).AsQueryable();

            // Filtro por nome do responsável
            if (!string.IsNullOrEmpty(nome))
            {
                contexto = contexto.Where(v => v.responsavel.nome.Contains(nome));
            }

            // Filtro por data da visita
            if (dataVisita.HasValue)
            {
                contexto = contexto.Where(v => v.datavisita.Date == dataVisita.Value.Date);
            }

            return View(await contexto.ToListAsync());
        }




        // GET: Visitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visitas
                .Include(v => v.responsavel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // GET: Visitas/Create
        public IActionResult Create()
        {
            ViewData["responsavelID"] = new SelectList(_context.Responsaveis, "Id", "nome");
            return View();
        }

        // POST: Visitas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,responsavelID,datavisita,descricao,status")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Se falhar na validação, recarregue os responsáveis para o dropdown
            ViewData["responsavelID"] = new SelectList(_context.Responsaveis, "Id", "nome", visita.responsavelID);
            return View(visita);
        }

        // GET: Visitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visitas.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }
            ViewData["responsavelID"] = new SelectList(_context.Responsaveis, "Id", "nome", visita.responsavelID);
            return View(visita);
        }

        // POST: Visitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,responsavelID,datavisita,descricao,status")] Visita visita)
        {
            if (id != visita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaExists(visita.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["responsavelID"] = new SelectList(_context.Responsaveis, "Id", "cpf", visita.responsavelID);
            return View(visita);
        }

        // GET: Visitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visitas
                .Include(v => v.responsavel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visita = await _context.Visitas.FindAsync(id);
            if (visita != null)
            {
                _context.Visitas.Remove(visita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaExists(int id)
        {
            return _context.Visitas.Any(e => e.Id == id);
        }
    }
}
