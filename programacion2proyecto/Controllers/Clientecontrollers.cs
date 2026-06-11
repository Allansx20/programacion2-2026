using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Models.Entities;

namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private static List<Cliente> _clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nombre = "María López", Telefono = "8091234567", Email = "maria@gmail.com", Direccion = "Calle 5" },
            new Cliente { Id = 2, Nombre = "Carlos Pérez", Telefono = "8297654321", Email = "carlos@hotmail.com", Direccion = "Av. 27 de Febrero" }
        };

        [HttpGet]
        public ActionResult<List<Cliente>> GetAll() => Ok(_clientes);

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetById(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<Cliente> Create(Cliente cliente)
        {
            if (!Cliente.ValidarEmail(cliente.Email ?? ""))
                return BadRequest("Email no válido.");
            if (!Cliente.ValidarTelefono(cliente.Telefono ?? ""))
                return BadRequest("Teléfono no válido.");
            cliente.Id = _clientes.Count + 1;
            cliente.FechaRegistro = DateTime.Now;
            _clientes.Add(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Cliente cliente)
        {
            var existing = _clientes.FirstOrDefault(c => c.Id == id);
            if (existing == null) return NotFound();
            existing.Nombre = cliente.Nombre;
            existing.Telefono = cliente.Telefono;
            existing.Email = cliente.Email;
            existing.Direccion = cliente.Direccion;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            _clientes.Remove(cliente);
            return NoContent();
        }
    }
}