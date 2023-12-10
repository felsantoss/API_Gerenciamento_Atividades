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
            try
            {
                if (_context.Atividades == null) // verificar se há valores válidos no banco de dados
                {
                    return NotFound(); // retorna erro caso não seja encontrado nada 
                }

                return await _context.Atividades.ToListAsync(); // se houver informações, é retornado as informações
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpGet]
        [Route("{ID}")] // Este GET passando como parametro um ID, é retornado um ID especifico do banco de dados
        public async Task<ActionResult<Atividades>> getAtividadeByID(int ID)
        {
            try
            {
                var atividade = await _context.Atividades.FindAsync(ID); // criado a variável atividade para verificar se o ID fornecido existe no banco de dados, se existir será armazenado na variavel atividade

                if (atividade == null) // verifica se o valor existe no banco de dados
                {
                    return StatusCode(400, $"ERRO! ID {ID} não localizado"); // caso o ID informado não exista é retornado a mensagem de erro
                }

                return atividade; // se o ID existir é retornado a variavel atividade com todas as informações 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }

        [HttpPost] // Método postAtividades cria e atualizar atividades no banco de dados 
        public async Task<ActionResult<Atividades>> postAtividades([FromBody] Atividades atividades)
        {
            try
            {
                if (atividades.ID != 0) // verifica se o valor fornecido é diferente de zero, se o valor fornecido for diferente de zero é feito uma atualização em uma atividade e não uma criação de uma nova atividade
                {
                    var atividadeExiste = await _context.Atividades.FindAsync(atividades.ID); // armazenando o valor fornecido em uma variavel

                    if (atividadeExiste != null) // Se a atividade existir, as informações são atualizadas conforme valores fornecido
                    {
                        atividadeExiste.Titulo = atividades.Titulo;
                        atividadeExiste.Descricao = atividades.Descricao;
                        atividadeExiste.Status = atividades.Status;

                        await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

                        return Ok("Sucesso! ID atualizado com sucesso");
                    }
                    else
                    {
                        return BadRequest("ERRO! ID não localizado"); // Erro caso o ID fornecido não existe no banco de dados 
                    }
                }
                else
                {
                    if (await _context.Atividades.AnyAsync(a => a.Titulo == atividades.Titulo && a.Descricao == atividades.Descricao)) // Verifica se já existe uma atividade com o mesmo título e descrição
                    {
                        return BadRequest("ERRO! ID já cadastrado com este título e descrição");
                    }
                    else
                    {
                        // Se o ID for enviado como zero, adiciona a nova atividade ao contexto do banco de dados
                        _context.Atividades.Add(atividades); 
                        await _context.SaveChangesAsync();

                        return CreatedAtAction(nameof(getAtividadeByID), new { id = atividades.ID }, atividades); // Retorna uma resposta com os detalhes da nova atividade 
                    }
                }       
            } 
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
            
        }
        
    }
}
