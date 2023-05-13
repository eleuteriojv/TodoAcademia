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
    public class AlunoUsuarioController : Controller
    {
        private readonly AcademiaDbContext _context;

        public AlunoUsuarioController(AcademiaDbContext context)
        {
            _context = context;
        }

        // GET: AlunoUsuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.ToListAsync());
        }

        // GET: AlunoUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoUsuario = await _context.Alunos
                .FirstOrDefaultAsync(m => m.IdAlunoUsuario == id);
            if (alunoUsuario == null)
            {
                return NotFound();
            }

            return View(alunoUsuario);
        }

        // GET: AlunoUsuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlunoUsuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlunoUsuario,IdProfessorUsuario")] AlunoUsuario alunoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alunoUsuario);
        }

        // GET: AlunoUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoUsuario = await _context.Alunos.FindAsync(id);
            if (alunoUsuario == null)
            {
                return NotFound();
            }
            return View(alunoUsuario);
        }

        // POST: AlunoUsuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlunoUsuario,IdProfessorUsuario")] AlunoUsuario alunoUsuario)
        {
            if (id != alunoUsuario.IdAlunoUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoUsuarioExists(alunoUsuario.IdAlunoUsuario))
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
            return View(alunoUsuario);
        }

        // GET: AlunoUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoUsuario = await _context.Alunos
                .FirstOrDefaultAsync(m => m.IdAlunoUsuario == id);
            if (alunoUsuario == null)
            {
                return NotFound();
            }

            return View(alunoUsuario);
        }

        // POST: AlunoUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alunoUsuario = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(alunoUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoUsuarioExists(int id)
        {
            return _context.Alunos.Any(e => e.IdAlunoUsuario == id);
        }
    }
}
