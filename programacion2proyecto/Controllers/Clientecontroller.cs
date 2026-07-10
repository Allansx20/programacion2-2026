using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Context;
using programacion2proyecto.Domain.Entities;
using programacion2proyecto.Infraestructure.Repositories;
using programacion2proyecto.Models.Dtos;
using programacion2proyecto.Models.Responses;

namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : BaseController<Cliente>
    {
        private readonly ClienteRepository _repository;

        public ClienteController(DataContext context, ClienteRepository repository, IMapper mapper)
            : base(context, mapper)
        {
            _repository = repository;
        }

        [HttpGet]
        public ApiResponse<List<ClienteDto>> GetAll()
        {
            var clientes = _repository.GetAll().ToList();
            var response = Mapper.Map<List<ClienteDto>>(clientes);
            return ApiResponse<List<ClienteDto>>.SuccessResponse(response);
        }

        [HttpGet("{id}")]
        public ApiResponse<ClienteDto> GetById(int id)
        {
            var cliente = _repository.GetById(id);
            if (cliente == null)
                return ApiResponse<ClienteDto>.FailureResponse("Recurso no encontrado.", 404);

            var response = Mapper.Map<ClienteDto>(cliente);
            return ApiResponse<ClienteDto>.SuccessResponse(response);
        }

        [HttpPost]
        public ApiResponse<ClienteDto> Create(CreateClienteDto dto)
        {
            var cliente = Mapper.Map<Cliente>(dto);
            _repository.Create(cliente);

            var response = Mapper.Map<ClienteDto>(cliente);
            return ApiResponse<ClienteDto>.SuccessResponse(response, 201);
        }

        [HttpPut("{id}")]
        public ApiResponse<ClienteDto> Update(int id, UpdateClienteDto dto)
        {
            var cliente = Mapper.Map<Cliente>(dto);
            var success = _repository.Update(id, cliente);

            if (!success)
                return ApiResponse<ClienteDto>.FailureResponse("Cliente no encontrado.", 404);

            var response = Mapper.Map<ClienteDto>(cliente);
            return ApiResponse<ClienteDto>.SuccessResponse(response);
        }

        [HttpDelete("{id}")]
        public ApiResponse<string> Delete(int id)
        {
            var success = _repository.Delete(id);
            if (!success)
                return ApiResponse<string>.FailureResponse("Recurso no encontrado.", 404);

            return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);
        }
    }
}





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





