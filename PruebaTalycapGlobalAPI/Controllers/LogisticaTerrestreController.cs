using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTalycapGlobalAPI.Datos;


namespace PruebaTalycapGlobalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticaTerrestreController : ControllerBase
    {
        private readonly DataContext _context;
        public LogisticaTerrestreController(DataContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogisticaTerrestre>>> GetLogisticaTerrestre()
        {
            if (_context.LogisticaTerrestre == null)
            {
                return NotFound();
            }
            return await _context.LogisticaTerrestre.ToListAsync();
        }

        [HttpGet("{NumeroGuia}")]
        public async Task<ActionResult<LogisticaTerrestre>> GetLogisticaTerrestre(int NumeroGuia)
        {
            if (_context.LogisticaTerrestre == null)
            {
                return NotFound();
            }
            var logistica = await _context.LogisticaTerrestre.FindAsync(NumeroGuia);

            if (logistica == null)
            {
                return NotFound();
            }

            return logistica;
        }

        [HttpPost]
        public async Task<ActionResult<LogisticaTerrestre>> PostLogisticaTerrestre(LogisticaTerrestre logisticaTerrestre)
        {
            try
            {
                if (_context.LogisticaTerrestre == null)
                {
                    return Problem("Entity set 'DataContext.LogisticaTerrestre'  is null.");
                }
                _context.LogisticaTerrestre.Add(logisticaTerrestre);
                await _context.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                return StatusCode(500, "Ocurrió un error interno al guardar los datos. " + Ex.Message.ToString());
            }
            

            return CreatedAtAction("GetLogisticaTerrestre", new { id = logisticaTerrestre.NumeroGuia }, logisticaTerrestre);
        }

        [HttpPut("{NumeroGuia}")]
        public async Task<IActionResult> PutLogisticaTerrestre(int NumeroGuia, LogisticaTerrestre logistica)
        {
            if (NumeroGuia != logistica.NumeroGuia)
            {
                return BadRequest();
            }

            _context.Entry(logistica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogisticaTerrestreExists(NumeroGuia))
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

        private bool LogisticaTerrestreExists(int NumeroGuia)
        {
            return (_context.LogisticaTerrestre?.Any(e => e.NumeroGuia == NumeroGuia)).GetValueOrDefault();
        }

        [HttpDelete("{NumeroGuia}")]
        public async Task<IActionResult> DeleteLogisticaTerrestre(int NumeroGuia)
        {
            if (_context.LogisticaTerrestre == null)
            {
                return NotFound();
            }
            var logisticaTerrestre = await _context.LogisticaTerrestre.FindAsync(NumeroGuia);
            if (logisticaTerrestre == null)
            {
                return NotFound();
            }

            _context.LogisticaTerrestre.Remove(logisticaTerrestre);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
