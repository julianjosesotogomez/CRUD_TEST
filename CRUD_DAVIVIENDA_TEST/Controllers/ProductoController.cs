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
    public class ProductoController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ProductoController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listarProductos = await _context.ProductoCRUD.ToListAsync();
                return Ok(listarProductos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            try
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return Ok(producto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto producto)
        {
            try
            {
                if (id != producto.IdProducto)
                {
                    return NotFound();
                }
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El producto fue actualizado con exito!" });
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
                var producto = await _context.ProductoCRUD.FindAsync(id);
                if (producto == null)
                {
                    return NotFound();
                }
                _context.ProductoCRUD.Remove(producto);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El producto fue eliminado con exito!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
