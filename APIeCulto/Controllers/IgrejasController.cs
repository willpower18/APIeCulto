using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIeCulto.Models;
using APIeCulto.Data;
using APIeCulto.Coomon;

namespace APIeCulto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IgrejasController : ControllerBase
    {
        private readonly eCultoContext _context;

        public IgrejasController(eCultoContext context)
        {
            _context = context;
        }

        // GET: api/Igrejas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Igreja>>> GetIgreja(string key)
        {
            try
            {
                if (key != ApiKey.Key)
                {
                    return StatusCode(403);
                }

                return await _context.Igreja.Where(i => i.Ativo == 1).OrderBy(i => i.Nome).ToListAsync();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET: api/Igrejas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IgrejaCultos>> GetCultos(int id, string key)
        {
            try
            {
                if (key != ApiKey.Key)
                {
                    return StatusCode(403);
                }

                var igreja = await _context.Igreja.FindAsync(id);

                if (igreja == null)
                {
                    return NotFound();
                }

                DateTime hoje = Util.BrasilDate();

                List<Culto> cultos = await _context.Culto.Where(c => c.IdIgreja == igreja.IdIgreja & c.DataHora >= hoje).OrderBy(c => c.DataHora).ToListAsync();
                if(cultos.Count > 0)
                {
                    foreach(Culto c in cultos)
                    {
                        c.IdIgrejaNavigation = null;
                        c.Participacao = null;
                    }
                }

                IgrejaCultos iCulto = new IgrejaCultos
                {
                    nomeIgreja = igreja.Nome,
                    capacidade = igreja.Capacidade,
                    cultos = cultos
                };

                return iCulto;
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
