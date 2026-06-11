using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Models.Dtos;
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

        // Cambia el método Create - recibe ClienteDto en vez de Cliente
        [HttpPost]
        public ActionResult<Cliente> Create(ClienteDto dto)
        {
            if (!Cliente.ValidarEmail(dto.Email))
                return BadRequest("Email no válido.");
            if (!Cliente.ValidarTelefono(dto.Telefono))
                return BadRequest("Teléfono no válido.");

            var cliente = new Cliente
            {
                Id = _clientes.Count + 1,
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Direccion = dto.Direccion,
                FechaRegistro = DateTime.Now
            };

            _clientes.Add(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        // Cambia el método Update - recibe ClienteDto
        [HttpPut("{id}")]
        public ActionResult Update(int id, ClienteDto dto)
        {
            var existing = _clientes.FirstOrDefault(c => c.Id == id);
            if (existing == null) return NotFound();
            existing.Nombre = dto.Nombre;
            existing.Telefono = dto.Telefono;
            existing.Email = dto.Email;
            existing.Direccion = dto.Direccion;
            return NoContent();
        }
    }
}