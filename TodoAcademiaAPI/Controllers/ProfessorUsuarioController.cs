using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAcademiaAPI.Data;
using TodoAcademiaAPI.Models;

namespace TodoAcademiaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorUsuarioController : ControllerBase
    {
        private readonly AcademiaDbContext _context;

        public ProfessorUsuarioController(AcademiaDbContext context)
        {
            _context = context;
        }

        // GET: api/ProfessorUsuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessorUsuario>>> GetProfessores()
        {
            return await _context.Professores.ToListAsync();
        }

        // GET: api/ProfessorUsuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessorUsuario>> GetProfessorUsuario(int id)
        {
            var professorUsuario = await _context.Professores.FindAsync(id);

            if (professorUsuario == null)
            {
                return NotFound();
            }

            return professorUsuario;
        }

        // PUT: api/ProfessorUsuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessorUsuario(int id, ProfessorUsuario professorUsuario)
        {
            if (id != professorUsuario.IdProfessorUsuario)
            {
                return BadRequest();
            }

            _context.Entry(professorUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorUsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProfessorUsuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfessorUsuario>> PostProfessorUsuario(ProfessorUsuario professorUsuario)
        {
            _context.Professores.Add(professorUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessorUsuario", new { id = professorUsuario.IdProfessorUsuario }, professorUsuario);
        }

        // DELETE: api/ProfessorUsuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessorUsuario(int id)
        {
            var professorUsuario = await _context.Professores.FindAsync(id);
            if (professorUsuario == null)
            {
                return NotFound();
            }

            _context.Professores.Remove(professorUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessorUsuarioExists(int id)
        {
            return _context.Professores.Any(e => e.IdProfessorUsuario == id);
        }
    }
}
