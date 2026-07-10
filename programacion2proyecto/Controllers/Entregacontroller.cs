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
    public class EntregaController : BaseController<Entrega>
    {
        private readonly EntregaRepository _repository;

        public EntregaController(DataContext context, EntregaRepository repository, IMapper mapper)
            : base(context, mapper)
        {
            _repository = repository;
        }

        [HttpGet]
        public ApiResponse<List<EntregaDto>> GetAll()
        {
            var entregas = _repository.GetAll().ToList();
            var response = Mapper.Map<List<EntregaDto>>(entregas);
            return ApiResponse<List<EntregaDto>>.SuccessResponse(response);
        }

        [HttpGet("{id}")]
        public ApiResponse<EntregaDto> GetById(int id)
        {
            var entrega = _repository.GetById(id);
            if (entrega == null)
                return ApiResponse<EntregaDto>.FailureResponse("Recurso no encontrado.", 404);

            var response = Mapper.Map<EntregaDto>(entrega);
            return ApiResponse<EntregaDto>.SuccessResponse(response);
        }

        [HttpPost]
        public ApiResponse<EntregaDto> Create(CreateEntregaDto dto)
        {
            var entrega = Mapper.Map<Entrega>(dto);
            _repository.Create(entrega);

            var response = Mapper.Map<EntregaDto>(entrega);
            return ApiResponse<EntregaDto>.SuccessResponse(response, 201);
        }

        [HttpPut("{id}")]
        public ApiResponse<EntregaDto> Update(int id, UpdateEntregaDto dto)
        {
            var entrega = Mapper.Map<Entrega>(dto);
            var success = _repository.Update(id, entrega);

            if (!success)
                return ApiResponse<EntregaDto>.FailureResponse("Entrega no encontrada.", 404);

            var response = Mapper.Map<EntregaDto>(entrega);
            return ApiResponse<EntregaDto>.SuccessResponse(response);
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

