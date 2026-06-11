using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Models.Entities;


namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntregaController : ControllerBase
    {
        private static List<Entrega> _entregas = new List<Entrega>
        {
            new Entrega { Id = 1, PedidoId = 1, Tipo = "domicilio", Direccion = "Calle 5, Santo Domingo", FechaProgramada = DateTime.Now.AddDays(3), Confirmada = false }
        };

        [HttpGet]
        public ActionResult<List<Entrega>> GetAll() => Ok(_entregas);

        [HttpGet("{id}")]
        public ActionResult<Entrega> GetById(int id)
        {
            var entrega = _entregas.FirstOrDefault(e => e.Id == id);
            if (entrega == null) return NotFound();
            return Ok(entrega);
        }

        [HttpPost]
        public ActionResult<Entrega> Create(Entrega entrega)
        {
            entrega.Id = _entregas.Count + 1;
            _entregas.Add(entrega);
            return CreatedAtAction(nameof(GetById), new { id = entrega.Id }, entrega);
        }

        [HttpPut("{id}/confirmar")]
        public ActionResult Confirmar(int id)
        {
            var entrega = _entregas.FirstOrDefault(e => e.Id == id);
            if (entrega == null) return NotFound();
            entrega.ConfirmarEntrega();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entrega = _entregas.FirstOrDefault(e => e.Id == id);
            if (entrega == null) return NotFound();
            _entregas.Remove(entrega);
            return NoContent();
        }
    }
}