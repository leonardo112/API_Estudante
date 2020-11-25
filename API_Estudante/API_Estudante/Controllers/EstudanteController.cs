using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Estudante.Context;
using API_Estudante.Models;

namespace API_Estudante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private readonly EstudanteContext _context;

        public EstudanteController(EstudanteContext context)
        {
            _context = context;
        }

        // GET: api/Estudante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudante>>> Getestudantes()
        {
            return await _context.estudantes.ToListAsync();
        }

        // GET: api/Estudante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudante>> GetEstudante(int id)
        {
            var estudante = await _context.estudantes.FindAsync(id);

            if (estudante == null)
            {
                return NotFound();
            }

            return estudante;
        }

        // PUT: api/Estudante/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudante(int id, Estudante estudante)
        {
            if (id != estudante.id)
            {
                return BadRequest();
            }

            _context.Entry(estudante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudanteExists(id))
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

        // POST: api/Estudante
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Estudante>> PostEstudante(Estudante estudante)
        {
            _context.estudantes.Add(estudante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudante", new { id = estudante.id }, estudante);
        }

        // DELETE: api/Estudante/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estudante>> DeleteEstudante(int id)
        {
            var estudante = await _context.estudantes.FindAsync(id);
            if (estudante == null)
            {
                return NotFound();
            }

            _context.estudantes.Remove(estudante);
            await _context.SaveChangesAsync();

            return estudante;
        }

        private bool EstudanteExists(int id)
        {
            return _context.estudantes.Any(e => e.id == id);
        }
    }
}
