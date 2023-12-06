using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Gerenciamento_Atividades.Context;
using API_Gerenciamento_Atividades.Models;

namespace API_Gerenciamento_Atividades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AtividadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Atividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atividades>>> GetAtividades()
        {
          if (_context.Atividades == null)
          {
              return NotFound();
          }
            return await _context.Atividades.ToListAsync();
        }

        // GET: api/Atividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atividades>> GetAtividades(int id)
        {
          if (_context.Atividades == null)
          {
              return NotFound();
          }
            var atividades = await _context.Atividades.FindAsync(id);

            if (atividades == null)
            {
                return NotFound();
            }

            return atividades;
        }

        // PUT: api/Atividades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtividades(int id, Atividades atividades)
        {
            if (id != atividades.ID)
            {
                return BadRequest();
            }

            _context.Entry(atividades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtividadesExists(id))
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

        // POST: api/Atividades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atividades>> PostAtividades(Atividades atividades)
        {
          if (_context.Atividades == null)
          {
              return Problem("Entity set 'AppDbContext.Atividades'  is null.");
          }
            _context.Atividades.Add(atividades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtividades", new { id = atividades.ID }, atividades);
        }

        // DELETE: api/Atividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtividades(int id)
        {
            if (_context.Atividades == null)
            {
                return NotFound();
            }
            var atividades = await _context.Atividades.FindAsync(id);
            if (atividades == null)
            {
                return NotFound();
            }

            _context.Atividades.Remove(atividades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtividadesExists(int id)
        {
            return (_context.Atividades?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
