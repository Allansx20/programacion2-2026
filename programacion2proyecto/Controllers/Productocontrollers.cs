using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Models.Dtos;
using programacion2proyecto.Models.Entities;

namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private static List<Producto> _productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Torta de chocolate", Descripcion = "Torta de 3 pisos", PrecioBase = 2500, Categoria = "Tortas", Disponible = true },
            new Producto { Id = 2, Nombre = "Cupcakes x12", Descripcion = "Caja de 12 cupcakes", PrecioBase = 800, Categoria = "Cupcakes", Disponible = true }
        };

        [HttpGet]
        public ActionResult<List<Producto>> GetAll() => Ok(_productos);

        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public ActionResult<Producto> Create(ProductoDto dto)
        {
            var producto = new Producto
            {
                Id = _productos.Count + 1,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                PrecioBase = dto.PrecioBase,
                Categoria = dto.Categoria,
                Disponible = dto.Disponible
            };
            _productos.Add(producto);
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ProductoDto dto)
        {
            var existing = _productos.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();
            existing.Nombre = dto.Nombre;
            existing.Descripcion = dto.Descripcion;
            existing.PrecioBase = dto.PrecioBase;
            existing.Categoria = dto.Categoria;
            existing.Disponible = dto.Disponible;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return NotFound();
            _productos.Remove(producto);
            return NoContent();
        }
    }
}