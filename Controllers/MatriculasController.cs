using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RotasParaOFuturo.Models;

namespace RotasParaOFuturo.Controllers
{
    public class MatriculasController : Controller
    {
        private readonly Contexto _context;

        public MatriculasController(Contexto context)
        {
            _context = context;
        }

        // GET: Matriculas




        public async Task<IActionResult> Index(string nomeAluno, string ra)
        {
            // Obtém todas as matrículas com os relacionamentos necessários
            var matriculas = _context.Matriculas
                .Include(m => m.aluno)
                .Include(m => m.turma)
                .AsQueryable();

            // Filtra por nome do aluno
            if (!string.IsNullOrEmpty(nomeAluno))
            {
                matriculas = matriculas.Where(m => m.aluno.Nome.Contains(nomeAluno));
            }

            // Filtra por RA (convertendo para string para comparação parcial)
            if (!string.IsNullOrEmpty(ra))
            {
                matriculas = matriculas.Where(m => m.RA.ToString().Contains(ra));
            }

            // Retorna a lista filtrada para a view
            return View(await matriculas.ToListAsync());
        }










        // GET: Matriculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.aluno)
                .Include(m => m.turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matriculas/Create
        public IActionResult Create()
        {
            ViewData["alunoID"] = new SelectList(_context.Alunos, "Id", "Nome");
            ViewData["turmaID"] = new SelectList(_context.Turmas, "Id", "descricao");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataMatricula,alunoID,RA,turmaID")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                var turma = await _context.Turmas
                    .Include(t => t.atividade)
                    .FirstOrDefaultAsync(t => t.Id == matricula.turmaID);
                if(turma != null && turma.atividade != null)
                {
                    matricula.Presenca = turma.atividade.TotalAulas;
                    matricula.Faltas = 0;
                }

                _context.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "Id", "Nome", matricula.alunoID);
            ViewData["turmaID"] = new SelectList(_context.Turmas, "Id", "descricao", matricula.turmaID);
            return View(matricula);
        }

        // GET: Matriculas/AddFaltas/5
        public async Task<IActionResult> AddFaltas(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.turma)
                .ThenInclude(t => t.atividade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matriculas/AddFaltas/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFaltas(int id, int faltas)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }

            if (faltas > 0)
            {
                matricula.Faltas += faltas;
                matricula.Presenca -= faltas;
                if (matricula.Presenca < 0)
                {
                    matricula.Presenca = 0; // Garantir que a presença não seja negativa
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id = matricula.Id });
        }

        // GET: Matriculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "Id", "CPF", matricula.alunoID);
            ViewData["turmaID"] = new SelectList(_context.Turmas, "Id", "descricao", matricula.turmaID);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataMatricula,alunoID,RA,turmaID")] Matricula matricula)
        {
            if (id != matricula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.Id))
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
            ViewData["alunoID"] = new SelectList(_context.Alunos, "Id", "CPF", matricula.alunoID);
            ViewData["turmaID"] = new SelectList(_context.Turmas, "Id", "descricao", matricula.turmaID);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.aluno)
                .Include(m => m.turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula != null)
            {
                _context.Matriculas.Remove(matricula);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(e => e.Id == id);
        }
    }
}
