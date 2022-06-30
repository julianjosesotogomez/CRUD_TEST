using CRUD_DAVIVIENDA_TEST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_DAVIVIENDA_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ClienteController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listarClientes = await _context.ClienteCRUD.ToListAsync();
                return Ok(listarClientes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult>Post([FromBody] Cliente cliente)
        {
            try
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                if(id != cliente.IdCliente)
                {
                    return NotFound();
                }
                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El cliente fue actualizado con exito!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _context.ClienteCRUD.FindAsync(id);
                if(cliente == null)
                {
                    return NotFound();
                }
                _context.ClienteCRUD.Remove(cliente);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El cliente fue eliminado con exito!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
