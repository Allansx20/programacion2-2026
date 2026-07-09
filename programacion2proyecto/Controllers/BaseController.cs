using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programacion2proyecto.Data;
using programacion2proyecto.Domain.Core;
using programacion2proyecto.Models.Responses;

namespace programacion2proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : BaseEntity
    {
        public readonly DataContext _context;
        public readonly IMapper Mapper;
        public BaseController(DataContext context, IMapper mapper)
        {
            _context = context;
            Mapper = mapper;
        }
        [HttpGet]
        public virtual ApiResponse<List<T>> GetAll()
        {
            var response = _context.Set<T>().ToList();
            return ApiResponse<List<T>>.SuccessResponse(response);
        }

        [HttpGet("{id}")]
        public virtual ApiResponse<T> GetById(int id)
        {
            var response = _context.Set<T>().Find(id);
            if (response == null)
                return ApiResponse<T>.FailureResponse("Recurso no encontrado.", 404);
            return ApiResponse<T>.SuccessResponse(response);
        }

        [HttpDelete("{id}")]
        public virtual ApiResponse<string> Delete(int id)
        {
            var response = _context.Set<T>().Find(id);
            if (response == null)
                return ApiResponse<string>.FailureResponse("Recurso no encontrado.", 404);

            _context.Set<T>().Remove(response);
            _context.SaveChanges();
            return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);
        }
    }
}
