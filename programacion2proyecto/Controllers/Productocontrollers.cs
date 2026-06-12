using System.Linq;
using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Data;
using programacion2proyecto.Models.Dtos;
using programacion2proyecto.Models.Entities;

namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Producto>> GetAll()
        {
            return Ok(_context.Productos.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public ActionResult<Producto> Create(ProductoDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                PrecioBase = dto.PrecioBase,
                Categoria = dto.Categoria,
                Disponible = dto.Disponible
            };

            _context.Productos.Add(producto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ProductoDto dto)
        {
            var existing = _context.Productos.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();

            existing.Nombre = dto.Nombre;
            existing.Descripcion = dto.Descripcion;
            existing.PrecioBase = dto.PrecioBase;
            existing.Categoria = dto.Categoria;
            existing.Disponible = dto.Disponible;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}