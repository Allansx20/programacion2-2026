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
    public class EntregaController : BaseController<Entrega>
    {
        //private readonly EntregaRepository _repository;
        //private readonly UnitOfwork _unitOfWork;
        private readonly EntregaService _entregaService;
        public EntregaController(/*UnitOfwork unitOfWork,*/EntregaService entregaService,
            IMapper mapper)
            : base(mapper)
        {
            _entregaService = entregaService;
            //this._unitOfWork = unitOfWork;
        }


        [HttpGet]
        public ApiResponse<IEnumerable<EntregaDto>> GetAll() => _entregaService.GetAll();
        //{
        //    var entregas = _unitOfWork.EntregaRepository.GetAll().ToList();
        //    var response = Mapper.Map<List<EntregaDto>>(entregas);
        //    return ApiResponse<List<EntregaDto>>.SuccessResponse(response);
        //}

        [HttpGet("{id}")]
        public ApiResponse<EntregaDto> GetById(int id) => _entregaService.GetById(id);
        //{
        //    var entrega = _unitOfWork.EntregaRepository.GetById(id);
        //    if (entrega == null)
        //        return ApiResponse<EntregaDto>.FailureResponse("Recurso no encontrado.", 404);

        //    var response = Mapper.Map<EntregaDto>(entrega);
        //    return ApiResponse<EntregaDto>.SuccessResponse(response);
        //}

        [HttpPost]
        public ApiResponse<EntregaDto> Create(CreateEntregaDto dto) => _entregaService.Create(dto);
        //{
        //    var entrega = Mapper.Map<Entrega>(dto);
        //    _unitOfWork.EntregaRepository.Create(entrega);
        //    _unitOfWork.Complete();

        //    var response = Mapper.Map<EntregaDto>(entrega);
        //    return ApiResponse<EntregaDto>.SuccessResponse(response, 201);
        //}

        [HttpPut("{id}")]
        public ApiResponse<EntregaDto> Update(int id, UpdateEntregaDto dto) => _entregaService.Update(id, dto);
        //{
        //    var entrega = Mapper.Map<Entrega>(dto);
        //    var success = _unitOfWork.EntregaRepository.Update(id, entrega);

        //    if (!success)
        //        return ApiResponse<EntregaDto>.FailureResponse("Entrega no encontrada.", 404);
        //    _unitOfWork.Complete();

        //    var response = Mapper.Map<EntregaDto>(entrega);
        //    return ApiResponse<EntregaDto>.SuccessResponse(response);
        //}

        [HttpDelete("{id}")]
        public ApiResponse<string> Delete(int id) => _entregaService.Delete(id);
        //{
        //    var success = _unitOfWork.EntregaRepository.Delete(id);
        //    if (!success)
        //        return ApiResponse<string>.FailureResponse("Recurso no encontrado.", 404);
        //    _unitOfWork.Complete();

        //    return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);
        //}
    }
}



//        [HttpGet]
//        public virtual ApiResponse<List<Entrega>> GetAll()
//        {
//            var response = _context.Entregas.ToList();
//            return ApiResponse<List<Entrega>>.SuccessResponse(response);
//        }

//        [HttpGet("{id}")]
//        public virtual ApiResponse<Entrega> GetById(int id)
//        {
//            var response = _context.Entregas.Find(id);
//            if (response == null)
//                return ApiResponse<Entrega>.FailureResponse("Recurso no encontrado.", 404);
//            return ApiResponse<Entrega>.SuccessResponse(response);
//        }

//        [HttpPost]
//        public ApiResponse<EntregaDto> Create(CreateEntregaDto dto)
//        {
//            var entrega = Mapper.Map<Entrega>(dto);
//            _context.Entregas.Add(entrega);
//            _context.SaveChanges();

//            var response = Mapper.Map<EntregaDto>(entrega);
//            return ApiResponse<EntregaDto>.SuccessResponse(response, 201);
//        }

//        [HttpPut("{id}")]
//        public ApiResponse<EntregaDto> Update(int id, UpdateEntregaDto dto)
//        {
//            var entrega = _context.Entregas.Find(id);
//            if (entrega == null)
//                return ApiResponse<EntregaDto>.FailureResponse("Entrega no encontrada.", 404);
//            Mapper.Map(dto, entrega);
//            _context.SaveChanges();
//            var response = Mapper.Map<EntregaDto>(entrega);
//            return ApiResponse<EntregaDto>.SuccessResponse(response);
//        }

//        [HttpDelete("{id}")]
//        public virtual ApiResponse<string> Delete(int id)
//        {
//            var response = _context.Entregas.Find(id);
//            if (response == null)
//                return ApiResponse<string>.FailureResponse("Recurso no encontrado.", 404);

//            _context.Entregas.Remove(response);
//            _context.SaveChanges();
//            return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);


//{
//    _context = context;
//}

