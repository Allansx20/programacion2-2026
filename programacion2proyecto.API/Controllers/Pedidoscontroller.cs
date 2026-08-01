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
    public class PedidoController : BaseController<Pedido>
    {
        //private readonly PedidoRepository _repository;
        //private readonly UnitOfwork _unitOfWork;
        private readonly PedidoService _pedidoService;

        public PedidoController(/*UnitOfwork unitOfWork,*/PedidoService pedidoService,
            IMapper mapper)
             : base(mapper)
        {
            _pedidoService = pedidoService;
            //this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ApiResponse<IEnumerable<PedidoDto>> GetAll() => _pedidoService.GetAll();

        //{
        //    var pedidos = _unitOfWork.PedidoRepository.GetAll().ToList();
        //    var response = Mapper.Map<List<PedidoDto>>(pedidos);
        //    return ApiResponse<List<PedidoDto>>.SuccessResponse(response);
        //}

        [HttpGet("{id}")]
        public ApiResponse<PedidoDto> GetById(int id) => _pedidoService.GetById(id);
        //{
        //    var pedido = _unitOfWork.PedidoRepository.GetById(id);
        //    if (pedido == null)
        //        return ApiResponse<PedidoDto>.FailureResponse("Recurso no encontrado.", 404);

        //    var response = Mapper.Map<PedidoDto>(pedido);
        //    return ApiResponse<PedidoDto>.SuccessResponse(response);
        //}

        [HttpPost]
        public ApiResponse<PedidoDto> Create(CreatePedidoDto dto) => _pedidoService.Create(dto);
        //{
        //    var pedido = Mapper.Map<Pedido>(dto);
        //    _unitOfWork.PedidoRepository.Create(pedido);
        //    _unitOfWork.Complete();

        //    var response = Mapper.Map<PedidoDto>(pedido);
        //    return ApiResponse<PedidoDto>.SuccessResponse(response, 201);
        //}

        [HttpPut("{id}")]
        public ApiResponse<PedidoDto> Update(int id, UpdatePedidoDto dto) => _pedidoService.Update(id, dto);
        //{
        //    var pedido = Mapper.Map<Pedido>(dto);
        //    var success = _unitOfWork.PedidoRepository.Update(id, pedido);

        //    if (!success)
        //        return ApiResponse<PedidoDto>.FailureResponse("Pedido no encontrado.", 404);
        //    _unitOfWork.Complete();

        //    var response = Mapper.Map<PedidoDto>(pedido);
        //    return ApiResponse<PedidoDto>.SuccessResponse(response);
        //}

        [HttpDelete("{id}")]
        public ApiResponse<string> Delete(int id) => _pedidoService.Delete(id);
        //{
        //    var success = _unitOfWork.PedidoRepository.Delete(id);
        //    if (!success)
        //        return ApiResponse<string>.FailureResponse("Recurso no encontrado.", 404);
        //    _unitOfWork.Complete();

        //    return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);
        //}
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