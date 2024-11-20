using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotasParaOFuturo.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RotasParaOFuturo.Controllers
{
    public class AlunosController : Controller
    {
        private readonly Contexto _context;

        public AlunosController(Contexto context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index(string nome, string cpf, int? id)
        {
            // Inicia a consulta com todos os alunos
            var alunos = from a in _context.Alunos
                         select a;

            // Aplica filtro se o nome foi passado
            if (!string.IsNullOrEmpty(nome))
            {
                alunos = alunos.Where(a => a.Nome.Contains(nome));  // Filtra por nome
            }

            // Aplica filtro se o CPF foi passado
            if (!string.IsNullOrEmpty(cpf))
            {
                alunos = alunos.Where(a => a.CPF.ToString().Contains(cpf)); // Filtra por CPF
            }

            // Aplica filtro se o ID foi passado
            if (id.HasValue)
            {
                alunos = alunos.Where(a => a.Id == id);  // Filtra por ID
            }

            // Retorna a lista de alunos filtrados
            return View(await alunos.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            // Garantindo que um novo aluno será criado com sexo predefinido
            var aluno = new Aluno
            {
                Sexo = "Masculino"  // Definindo valor padrão para o sexo
            };

            return View(aluno);
        }

        // POST: Alunos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Nascimento,Endereco,CPF,RG,Telefone,Sexo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);  // Adiciona o aluno ao contexto
                await _context.SaveChangesAsync();  // Salva no banco de dados
                return RedirectToAction(nameof(Index));  // Redireciona para a lista de alunos
            }

            // Se o modelo não for válido, retorna a view com o modelo atual para corrigir os erros
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Nascimento,Endereco,CPF,RG,Telefone,Sexo")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);  // Atualiza o aluno no contexto
                    await _context.SaveChangesAsync();  // Salva as alterações no banco de dados
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Id))  // Verifica se o aluno existe
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));  // Redireciona para a lista de alunos
            }

            return View(aluno);  // Se não for válido, retorna à view de edição com os erros
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);  // Exibe a view de confirmação para deletar
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);  // Remove o aluno do contexto
            }

            await _context.SaveChangesAsync();  // Salva as alterações no banco de dados
            return RedirectToAction(nameof(Index));  // Redireciona para a lista de alunos
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);  // Verifica se o aluno existe no banco
        }
    }
}
