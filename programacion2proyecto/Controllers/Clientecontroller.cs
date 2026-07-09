using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Data;
using programacion2proyecto.Domain.Entities;
using programacion2proyecto.Models.Dtos;
using programacion2proyecto.Models.Responses;

namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : BaseController<Cliente>
    {
        //readonly DataContext _context;
        //readonly IMapper _mapper;

        public ClienteController(DataContext context, IMapper mapper) : base(context, mapper) { }

        [HttpPost]
        public ApiResponse<ClienteDto> Create(CreateClienteDto dto)
        {
            var cliente = Mapper.Map<Cliente>(dto);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            var response = Mapper.Map<ClienteDto>(cliente);
            return ApiResponse<ClienteDto>.SuccessResponse(response, 201);
        }

        [HttpPut("{id}")]
        public ApiResponse<ClienteDto> Update(int id, UpdateClienteDto dto)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
                return ApiResponse<ClienteDto>.FailureResponse("Cliente no encontrado.", 404);

            Mapper.Map(dto, cliente);
            _context.SaveChanges();

            var response = Mapper.Map<ClienteDto>(cliente);
            return ApiResponse<ClienteDto>.SuccessResponse(response);
        }

        //using var _ = _context = context;
        //_mapper = mapper;



        //        [HttpGet]
        //        public ActionResult<List<Cliente>> GetAll()
        //        {
        //            return Ok(_context.Clientes.ToList());
        //        }

        //        [HttpGet("{id}")]
        //        public ActionResult<Cliente> GetById(int id)
        //        {
        //            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
        //            if (cliente == null) return NotFound();
        //            return Ok(cliente);
        //        }

        //        [HttpPost]
        //        public ActionResult<Cliente> Create(ClienteDto dto)
        //        {
        //            if (!Cliente.ValidarEmail(dto.Email))
        //                return BadRequest("Email no válido.");
        //            if (!Cliente.ValidarTelefono(dto.Telefono))
        //                return BadRequest("Teléfono no válido.");

        //            var cliente = new Cliente
        //            {
        //                Nombre = dto.Nombre,
        //                Telefono = dto.Telefono,
        //                Email = dto.Email,
        //                Direccion = dto.Direccion,
        //                FechaRegistro = DateTime.Now
        //            };

        //            _context.Clientes.Add(cliente);
        //            _context.SaveChanges();

        //            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        //        }

        //        [HttpPut("{id}")]
        //        public IActionResult Update(int id, ClienteDto dto)
        //        {
        //            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
        //            if (cliente == null) return NotFound();

        //            if (!Cliente.ValidarEmail(dto.Email))
        //                return BadRequest("Email no válido.");
        //            if (!Cliente.ValidarTelefono(dto.Telefono))
        //                return BadRequest("Teléfono no válido.");

        //            cliente.Nombre = dto.Nombre;
        //            cliente.Telefono = dto.Telefono;
        //            cliente.Email = dto.Email;
        //            cliente.Direccion = dto.Direccion;

        //            _context.SaveChanges();
        //            return NoContent();
        //        }

        //        [HttpDelete("{id}")]
        //        public IActionResult Delete(int id)
        //        {
        //            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
        //            if (cliente == null) return NotFound();

        //            _context.Clientes.Remove(cliente);
        //            _context.SaveChanges();
        //            return NoContent();
    }
}
