using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Data;
using programacion2proyecto.Models.Dtos;
using programacion2proyecto.Models.Entities;
using programacion2proyecto.Models.Responses;

namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : BaseController<Pedido>
    {
        //private readonly DataContext _context;

        public PedidoController(DataContext context, IMapper mapper) : base(context, mapper) { }

        [HttpPost]
        public ApiResponse<PedidoDto> Create(CreatePedidoDto dto)
        {
            var pedido = Mapper.Map<Pedido>(dto);
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            var response = Mapper.Map<PedidoDto>(pedido);
            return ApiResponse<PedidoDto>.SuccessResponse(response, 201);
        }

        [HttpPut("{id}")]
        public ApiResponse<PedidoDto> Update(int id, UpdatePedidoDto dto)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null)

                return ApiResponse<PedidoDto>.FailureResponse("Pedido no encontrado", 404);


            Mapper.Map(dto, pedido);
            _context.SaveChanges();

            var response = Mapper.Map<PedidoDto>(pedido);
            return ApiResponse<PedidoDto>.SuccessResponse(response, 201);
        }
    }







    //{
    //    _context = context;
    //}

    //[HttpGet]
    //public ActionResult<List<Pedido>> GetAll()
    //{
    //    return Ok(_context.Pedidos.ToList());
    //}

    //[HttpGet("{id}")]
    //public ActionResult<Pedido> GetById(int id)
    //{
    //    var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == id);
    //    if (pedido == null) return NotFound();
    //    return Ok(pedido);
    //}

    //[HttpPost]
    //public ActionResult<Pedido> Create(PedidoDto dto)
    //{
    //    var pedido = new Pedido
    //    {
    //        ClienteId = dto.ClienteId,
    //        FechaPedido = DateTime.Now,
    //        FechaEntrega = dto.FechaEntrega,
    //        Estado = "pendiente",
    //        Total = dto.Total,
    //        Pagado = dto.Pagado
    //    };

    //    _context.Pedidos.Add(pedido);
    //    _context.SaveChanges();

    //    return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
    //}

    //[HttpPut("{id}/estado")]
    //public ActionResult CambiarEstado(int id, [FromBody] string nuevoEstado)
    //{
    //    var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == id);
    //    if (pedido == null) return NotFound();

    //    bool ok = pedido.CambiarEstado(nuevoEstado);
    //    if (!ok) return BadRequest("No se puede entregar sin pago.");

    //    _context.SaveChanges();
    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public ActionResult Delete(int id)
    //{
    //    var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == id);
    //    if (pedido == null) return NotFound();

    //    _context.Pedidos.Remove(pedido);
    //    _context.SaveChanges();

    //    return NoContent();
}





