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
    public class ExercicioController : ControllerBase
    {
        private readonly AcademiaDbContext _context;

        public ExercicioController(AcademiaDbContext context)
        {
            _context = context;
        }

        // GET: api/Exercicio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercicio>>> GetExercicios()
        {
            return await _context.Exercicios.ToListAsync();
        }

        // GET: api/Exercicio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercicio>> GetExercicio(int id)
        {
            var exercicio = await _context.Exercicios.FindAsync(id);

            if (exercicio == null)
            {
                return NotFound();
            }

            return exercicio;
        }

        // PUT: api/Exercicio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercicio(int id, Exercicio exercicio)
        {
            if (id != exercicio.IdExercicio)
            {
                return BadRequest();
            }

            _context.Entry(exercicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercicioExists(id))
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

        // POST: api/Exercicio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exercicio>> PostExercicio(Exercicio exercicio)
        {
            _context.Exercicios.Add(exercicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercicio", new { id = exercicio.IdExercicio }, exercicio);
        }

        // DELETE: api/Exercicio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercicio(int id)
        {
            var exercicio = await _context.Exercicios.FindAsync(id);
            if (exercicio == null)
            {
                return NotFound();
            }

            _context.Exercicios.Remove(exercicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExercicioExists(int id)
        {
            return _context.Exercicios.Any(e => e.IdExercicio == id);
        }
    }
}
