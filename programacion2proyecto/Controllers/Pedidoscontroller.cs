using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Domain.Entities;
using programacion2proyecto.Infraestructure.Contex;
using programacion2proyecto.Infraestructure.Repositories;
using programacion2proyecto.Models.Dtos;
using programacion2proyecto.Models.Responses;

namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : BaseController<Pedido>
    {
        private readonly PedidoRepository _repository;

        public PedidoController(DataContext context, PedidoRepository repository, IMapper mapper)
            : base(context, mapper)
        {
            _repository = repository;
        }

        [HttpGet]
        public ApiResponse<List<PedidoDto>> GetAll()
        {
            var pedidos = _repository.GetAll().ToList();
            var response = Mapper.Map<List<PedidoDto>>(pedidos);
            return ApiResponse<List<PedidoDto>>.SuccessResponse(response);
        }

        [HttpGet("{id}")]
        public ApiResponse<PedidoDto> GetById(int id)
        {
            var pedido = _repository.GetById(id);
            if (pedido == null)
                return ApiResponse<PedidoDto>.FailureResponse("Recurso no encontrado.", 404);

            var response = Mapper.Map<PedidoDto>(pedido);
            return ApiResponse<PedidoDto>.SuccessResponse(response);
        }

        [HttpPost]
        public ApiResponse<PedidoDto> Create(CreatePedidoDto dto)
        {
            var pedido = Mapper.Map<Pedido>(dto);
            _repository.Create(pedido);

            var response = Mapper.Map<PedidoDto>(pedido);
            return ApiResponse<PedidoDto>.SuccessResponse(response, 201);
        }

        [HttpPut("{id}")]
        public ApiResponse<PedidoDto> Update(int id, UpdatePedidoDto dto)
        {
            var pedido = Mapper.Map<Pedido>(dto);
            var success = _repository.Update(id, pedido);

            if (!success)
                return ApiResponse<PedidoDto>.FailureResponse("Pedido no encontrado.", 404);

            var response = Mapper.Map<PedidoDto>(pedido);
            return ApiResponse<PedidoDto>.SuccessResponse(response);
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


//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class PedidoController : BaseController<Pedido>
//    {
//        //private readonly DataContext _context;

//        public PedidoController(DataContext context, IMapper mapper) : base(context, mapper) { }

//        [HttpGet]
//        public virtual ApiResponse<List<Pedido>> GetAll()
//        {
//            var response = _context.Pedidos.ToList();
//            return ApiResponse<List<Pedido>>.SuccessResponse(response);
//        }

//        [HttpGet("{id}")]
//        public virtual ApiResponse<Pedido> GetById(int id)
//        {
//            var response = _context.Pedidos.Find(id);
//            if (response == null)
//                return ApiResponse<Pedido>.FailureResponse("Recurso no encontrado.", 404);
//            return ApiResponse<Pedido>.SuccessResponse(response);
//        }


//        [HttpPost]
//        public ApiResponse<PedidoDto> Create(CreatePedidoDto dto)
//        {
//            var pedido = Mapper.Map<Pedido>(dto);
//            _context.Pedidos.Add(pedido);
//            _context.SaveChanges();

//            var response = Mapper.Map<PedidoDto>(pedido);
//            return ApiResponse<PedidoDto>.SuccessResponse(response, 201);
//        }

//        [HttpPut("{id}")]
//        public ApiResponse<PedidoDto> Update(int id, UpdatePedidoDto dto)
//        {
//            var pedido = _context.Pedidos.Find(id);
//            if (pedido == null)

//                return ApiResponse<PedidoDto>.FailureResponse("Pedido no encontrado", 404);


//            Mapper.Map(dto, pedido);
//            _context.SaveChanges();

//            var response = Mapper.Map<PedidoDto>(pedido);
//            return ApiResponse<PedidoDto>.SuccessResponse(response, 201);
//        }

//        [HttpDelete("{id}")]
//        public virtual ApiResponse<string> Delete(int id)
//        {
//            var response = _context.Pedidos.Find(id);
//            if (response == null)
//                return ApiResponse<string>.FailureResponse("Recurso no encontrado.", 404);

//            _context.Pedidos.Remove(response);
//            _context.SaveChanges();
//            return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);
//        }
//    }