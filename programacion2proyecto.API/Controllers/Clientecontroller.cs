using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Application.Models.Dtos;
using programacion2proyecto.Application.Models.Responses;
using programacion2proyecto.Application.Services;
using programacion2proyecto.Domain.Entities;


namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : BaseController<Cliente>
    {
        //private readonly ClienteRepository _repository;
        //private readonly UnitOfwork _unitOfWork;

        //private readonly UnitOfwork _unitOfWork;
        private readonly ClienteService _clienteService;

        public ClienteController(/*UnitOfwork unitOfWork*/ClienteService clienteService,
            IMapper mapper)
            : base(mapper)
        {
            _clienteService = clienteService;
            //this._unitOfWork = unitOfWork;
        }


        [HttpGet]
        public ApiResponse<IEnumerable<ClienteDto>> GetAll() => _clienteService.GetAll();

        /*var clientes = *//*_clienteService.GetAllCliente();*/
        //var response = Mapper.Map<List<ClienteDto>>(clientes);
        //return ApiResponse<List<ClienteDto>>.SuccessResponse(response);


        [HttpGet("{id}")]
        public ApiResponse<ClienteDto> GetById(int id) => _clienteService.GetById(id);
        //{
        //    var cliente = _unitOfWork.ClienteRepository.GetById(id);
        //    if (cliente == null)
        //        return ApiResponse<ClienteDto>.FailureResponse("Recurso no encontrado.", 404);

        //    var response = Mapper.Map<ClienteDto>(cliente);
        //    return ApiResponse<ClienteDto>.SuccessResponse(response);
        //}

        [HttpPost]
        public ApiResponse<ClienteDto> Create(CreateClienteDto dto) => _clienteService.Create(dto);
        //{
        //    var cliente = Mapper.Map<Cliente>(dto);
        //    _unitOfWork.ClienteRepository.Create(cliente);
        //    _unitOfWork.Complete();

        //    var response = Mapper.Map<ClienteDto>(cliente);
        //    return ApiResponse<ClienteDto>.SuccessResponse(response, 201);
        //}

        [HttpPut("{id}")]
        public ApiResponse<ClienteDto> Update(int id, UpdateClienteDto dto) => _clienteService.Update(id, dto);
        //{
        //    var cliente = Mapper.Map<Cliente>(dto);
        //    var success = _unitOfWork.ClienteRepository.Update(id, cliente);

        //    if (!success)
        //        return ApiResponse<ClienteDto>.FailureResponse("Cliente no encontrado.", 404);
        //    _unitOfWork.Complete();

        //    var response = Mapper.Map<ClienteDto>(cliente);
        //    return ApiResponse<ClienteDto>.SuccessResponse(response);
        //}

        [HttpDelete("{id}")]
        public ApiResponse<string> Delete(int id) => _clienteService.Delete(id);
        //{
        //    var success = _unitOfWork.ClienteRepository.Delete(id);
        //    if (!success)
        //        return ApiResponse<string>.FailureResponse("Recurso no encontrado.", 404);
        //    _unitOfWork.Complete();

        //    return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);
        //}
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





