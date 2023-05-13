using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoAcademiaAPI.Data;
using TodoAcademiaAPI.Models;

namespace TodoAcademiaAPI.Controllers
{
    public class TarefaSemanalController : Controller
    {
        private readonly AcademiaDbContext _context;

        public TarefaSemanalController(AcademiaDbContext context)
        {
            _context = context;
        }

        // GET: TarefaSemanal
        public async Task<IActionResult> Index()
        {
            return View(await _context.TarefasSemanais.ToListAsync());
        }

        // GET: TarefaSemanal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaSemanal = await _context.TarefasSemanais
                .FirstOrDefaultAsync(m => m.IdTarefaSemanal == id);
            if (tarefaSemanal == null)
            {
                return NotFound();
            }

            return View(tarefaSemanal);
        }

        // GET: TarefaSemanal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TarefaSemanal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTarefaSemanal,DataInicio,DataFim,IdExercicio,IdAlunoUsuario")] TarefaSemanal tarefaSemanal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarefaSemanal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefaSemanal);
        }

        // GET: TarefaSemanal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaSemanal = await _context.TarefasSemanais.FindAsync(id);
            if (tarefaSemanal == null)
            {
                return NotFound();
            }
            return View(tarefaSemanal);
        }

        // POST: TarefaSemanal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTarefaSemanal,DataInicio,DataFim,IdExercicio,IdAlunoUsuario")] TarefaSemanal tarefaSemanal)
        {
            if (id != tarefaSemanal.IdTarefaSemanal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefaSemanal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefaSemanalExists(tarefaSemanal.IdTarefaSemanal))
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
            return View(tarefaSemanal);
        }

        // GET: TarefaSemanal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaSemanal = await _context.TarefasSemanais
                .FirstOrDefaultAsync(m => m.IdTarefaSemanal == id);
            if (tarefaSemanal == null)
            {
                return NotFound();
            }

            return View(tarefaSemanal);
        }

        // POST: TarefaSemanal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefaSemanal = await _context.TarefasSemanais.FindAsync(id);
            _context.TarefasSemanais.Remove(tarefaSemanal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefaSemanalExists(int id)
        {
            return _context.TarefasSemanais.Any(e => e.IdTarefaSemanal == id);
        }
    }
}
