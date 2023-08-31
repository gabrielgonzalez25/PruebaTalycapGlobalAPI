using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PruebaTalycapGlobalAPI.Datos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTalycapGlobalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly DataContext _context;
        public ClientesController(DataContext context)
        {
            this._context = context;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            return await _context.Clientes.ToListAsync();
        }

        // GET api/<ClientesController>/5
        [HttpGet("{IdCliente}")]
        public async Task<ActionResult<Clientes>> GetClientes(int IdCliente)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(IdCliente);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'DataContext.Clientes'  is null.");
            }
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientes", new { id = clientes.IdCliente }, clientes);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{IdCliente}")]
        public async Task<IActionResult> PutClientes(int IdCliente, Clientes cliente)
        {
            if (IdCliente != cliente.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(IdCliente))
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

        private bool ClientesExists(int IdCliente)
        {
            return (_context.Clientes?.Any(e => e.IdCliente == IdCliente)).GetValueOrDefault();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{IdCliente}")]
        public async Task<IActionResult> DeleteClientes(int IdCliente)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var clientes = await _context.Clientes.FindAsync(IdCliente);
            if (clientes == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
