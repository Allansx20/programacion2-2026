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
    public class EntregaController : BaseController<Entrega>
    {
        //private readonly DataContext _context; 

        public EntregaController(DataContext context, IMapper mapper) : base(context, mapper) { }

        [HttpPost]
        public ApiResponse<EntregaDto> Create(CreateEntregaDto dto)
        {
            var entrega = Mapper.Map<Entrega>(dto);
            _context.Entregas.Add(entrega);
            _context.SaveChanges();

            var response = Mapper.Map<EntregaDto>(entrega);
            return ApiResponse<EntregaDto>.SuccessResponse(response, 201);
        }

        [HttpPut("{id}")]
        public ApiResponse<EntregaDto> Update(int id, UpdateEntregaDto dto)
        {
            var entrega = _context.Entregas.Find(id);
            if (entrega == null)
                return ApiResponse<EntregaDto>.FailureResponse("Entrega no encontrada.", 404);
            Mapper.Map(dto, entrega);
            _context.SaveChanges();
            var response = Mapper.Map<EntregaDto>(entrega);
            return ApiResponse<EntregaDto>.SuccessResponse(response);
        }


        //{
        //    _context = context;
        //}

        //[HttpGet]
        //public ActionResult<List<Entrega>> GetAll()
        //{
        //    return Ok(_context.Entregas.ToList());
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Entrega> GetById(int id)
        //{
        //    var entrega = _context.Entregas.FirstOrDefault(e => e.Id == id);
        //    if (entrega == null) return NotFound();
        //    return Ok(entrega);
        //}

        //[HttpPost]
        //public ActionResult<Entrega> Create(EntregaDto dto)
        //{
        //    var entrega = new Entrega
        //    {
        //        PedidoId = dto.PedidoId,
        //        Tipo = dto.Tipo,
        //        Direccion = dto.Direccion,
        //        FechaProgramada = dto.FechaProgramada,
        //        Confirmada = false
        //    };

        //    _context.Entregas.Add(entrega);
        //    _context.SaveChanges();

        //    return CreatedAtAction(nameof(GetById), new { id = entrega.Id }, entrega);
        //}

        //[HttpPut("{id}/confirmar")]
        //public ActionResult Confirmar(int id)
        //{
        //    var entrega = _context.Entregas.FirstOrDefault(e => e.Id == id);
        //    if (entrega == null) return NotFound();

        //    entrega.ConfirmarEntrega();
        //    _context.SaveChanges();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    var entrega = _context.Entregas.FirstOrDefault(e => e.Id == id);
        //    if (entrega == null) return NotFound();

        //    _context.Entregas.Remove(entrega);
        //    _context.SaveChanges();

        //    return NoContent();
    }
}

