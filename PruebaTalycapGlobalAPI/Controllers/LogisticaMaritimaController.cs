using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTalycapGlobalAPI.Datos;

namespace PruebaTalycapGlobalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticaMaritimaController : ControllerBase
    {
        private readonly DataContext _context;
        public LogisticaMaritimaController(DataContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogisticaMaritima>>> GetLogisticaMaritima()
        {
            if (_context.LogisticaMaritima == null)
            {
                return NotFound();
            }
            return await _context.LogisticaMaritima.ToListAsync();
        }

        [HttpGet("{NumeroGuia}")]
        public async Task<ActionResult<LogisticaMaritima>> GetLogisticaMaritima(int NumeroGuia)
        {
            if (_context.LogisticaMaritima == null)
            {
                return NotFound();
            }
            var cliente = await _context.LogisticaMaritima.FindAsync(NumeroGuia);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<LogisticaMaritima>> PostLogisticaMaritima(LogisticaMaritima logisticaMaritima)
        {
            try
            {
                if (_context.LogisticaMaritima == null)
                {
                    return Problem("Entity set 'DataContext.LogisticaMaritima'  is null.");
                }
                _context.LogisticaMaritima.Add(logisticaMaritima);
                await _context.SaveChangesAsync();
            }
            catch (Exception Ex)
            {

                return StatusCode(500, "Ocurrió un error interno al guardar los datos. "+ Ex.Message.ToString());
            }
            

            return CreatedAtAction("GetLogisticaMaritima", new { id = logisticaMaritima.NumeroGuia }, logisticaMaritima);
        }

        [HttpPut("{NumeroGuia}")]
        public async Task<IActionResult> PutLogisticaMaritima(int NumeroGuia, LogisticaMaritima logisticaMaritima)
        {
            if (NumeroGuia != logisticaMaritima.NumeroGuia)
            {
                return BadRequest();
            }

            _context.Entry(logisticaMaritima).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogisticaMaritimaExists(NumeroGuia))
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

        private bool LogisticaMaritimaExists(int NumeroGuia)
        {
            return (_context.LogisticaMaritima?.Any(e => e.NumeroGuia == NumeroGuia)).GetValueOrDefault();
        }

        [HttpDelete("{NumeroGuia}")]
        public async Task<IActionResult> DeleteLogisticaMaritima(int NumeroGuia)
        {
            if (_context.LogisticaMaritima == null)
            {
                return NotFound();
            }
            var logisticaMaritima = await _context.LogisticaMaritima.FindAsync(NumeroGuia);
            if (logisticaMaritima == null)
            {
                return NotFound();
            }

            _context.LogisticaMaritima.Remove(logisticaMaritima);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    
    }
}
