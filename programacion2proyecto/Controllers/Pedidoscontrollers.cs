using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Models.Dtos;
using programacion2proyecto.Models.Entities;

namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private static List<Pedido> _pedidos = new List<Pedido>
        {
            new Pedido { Id = 1, ClienteId = 1, FechaPedido = DateTime.Now, Estado = "pendiente", Total = 1500, Pagado = false }
        };

        [HttpGet]
        public ActionResult<List<Pedido>> GetAll() => Ok(_pedidos);

        [HttpGet("{id}")]
        public ActionResult<Pedido> GetById(int id)
        {
            var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        [HttpPost]
        public ActionResult<Pedido> Create(PedidoDto dto)
        {
            var pedido = new Pedido
            {
                Id = _pedidos.Count + 1,
                ClienteId = dto.ClienteId,
                FechaPedido = DateTime.Now,
                FechaEntrega = dto.FechaEntrega,
                Estado = "pendiente",
                Total = dto.Total,
                Pagado = dto.Pagado
            };
            _pedidos.Add(pedido);
            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}/estado")]
        public ActionResult CambiarEstado(int id, [FromBody] string nuevoEstado)
        {
            var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null) return NotFound();
            bool ok = pedido.CambiarEstado(nuevoEstado);
            if (!ok) return BadRequest("No se puede entregar sin pago.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null) return NotFound();
            _pedidos.Remove(pedido);
            return NoContent();
        }
    }
}
