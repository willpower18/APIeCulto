using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIeCulto.Models;
using APIeCulto.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIeCulto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipacaoController : ControllerBase
    {
        private readonly eCultoContext _context;

        public ParticipacaoController(eCultoContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Culto>> Index(int id, string key)
        {
            if (key != ApiKey.Key)
            {
                return StatusCode(403);
            }

            try
            {
                if(id == 0)
                {
                    return NotFound();
                }

                Culto culto = await _context.Culto.FindAsync(id);

                if(culto == null)
                {
                    return NotFound();
                }

                return culto;
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(NovaParticipacao participacao)
        {
            if (participacao.key != ApiKey.Key)
            {
                return StatusCode(403);
            }

            try
            {
                Culto culto = await _context.Culto.Where(c => c.IdCulto == participacao.participacao.IdCulto).FirstOrDefaultAsync();
                if(culto == null)
                {
                    return NotFound();
                }
                else
                {
                    Igreja igreja = await _context.Igreja.Where(i => i.IdIgreja == culto.IdIgreja).FirstOrDefaultAsync();
                    List<Participacao> participacoes = await _context.Participacao.Where(p => p.IdCulto == culto.IdCulto).ToListAsync();
                    int quantidade = culto.Lotacao;
                    if (culto.Lotacao >= igreja.Capacidade)
                    {
                        return StatusCode(406); //Quando ultrapassa a capacidade do culto
                    }

                    if(quantidade > igreja.Capacidade)
                    {
                        return StatusCode(406); //Quando ultrapassa a capacidade do culto
                    }

                    /*var appkey = participacoes.Where(p => p.ChaveApp == participacao.participacao.ChaveApp).Select(p => p.ChaveApp);
                    if(appkey.Count() > 0)
                    {
                        return Unauthorized(); //401 Dispositivo já registrado no app
                    }*/

                    Participacao novaParticipacao = new Participacao
                    {
                        IdParticipacao = 0,
                        IdCulto = culto.IdCulto,
                        ChaveApp = participacao.participacao.ChaveApp,
                        Nome = participacao.participacao.Nome,
                        Telefone = participacao.participacao.Telefone,
                        QtdAdultos = participacao.participacao.QtdAdultos,
                        QtdCriancas = participacao.participacao.QtdCriancas
                    };
                    //Adiciona a participacao
                    _context.Add(novaParticipacao);
                    await _context.SaveChangesAsync();
                    //Incrementa a Lotacao do Culto
                    quantidade += novaParticipacao.QtdAdultos;
                    quantidade += novaParticipacao.QtdCriancas;
                    culto.Lotacao = quantidade;
                    _context.Update(culto);
                    await _context.SaveChangesAsync();

                    return Ok();//Participacao Confirmada
                }
            }
            catch
            {
                return StatusCode(500);
            }
        } 
    }
}
