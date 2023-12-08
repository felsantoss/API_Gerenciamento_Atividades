using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Gerenciamento_Atividades.Context;
using API_Gerenciamento_Atividades.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Update;

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

        [HttpGet] // este GET ele retorna todos os IDs cadastrados no banco de dados
        public async Task<ActionResult<IEnumerable<Atividades>>> getTodosIDs()
        {
            if (_context.Atividades == null)
            {
                return NotFound();
            }

            return await _context.Atividades.ToListAsync();
        }

        [HttpGet]
        [Route("{ID}")] // Este GET passando como parametro um ID, é retornado um ID especifico do banco de dados
        public async Task<ActionResult<Atividades>> getAtividadeByID(int ID)
        {
            try
            {
                var atividade = await _context.Atividades.FindAsync(ID);

                if (atividade == null)
                {
                    return StatusCode(400, $"ERRO! ID {ID} não localizado");
                }

                return atividade;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpPut]
        [Route("{ID}")] // O putAtividades valida se um ID existe no banco de dados e se existir ele atualiza as informações que foram fornecidas 
        public async Task<ActionResult<Atividades>> putAtividades(int ID, Atividades atividades)
        {
            if (ID != atividades.ID)
            {
                return StatusCode(400, $"ERRO! ID {ID} não localizado na base de dados");
            }

            _context.Entry(atividades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtividadesExists(ID))
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
        private bool AtividadesExists(int id)
        {
            return (_context.Atividades?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        
    } 

                return atividade;
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro interno no servidor");
            }
        }
    } 
}
