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
    public class ProductoController : BaseController<Producto>
    {
        private readonly ProductoRepository _repository;

        public ProductoController(DataContext context, ProductoRepository repository, IMapper mapper)
            : base(context, mapper)
        {
            _repository = repository;
        }

        [HttpGet]
        public ApiResponse<List<ProductoDto>> GetAll()
        {
            var productos = _repository.GetAll().ToList();
            var response = Mapper.Map<List<ProductoDto>>(productos);
            return ApiResponse<List<ProductoDto>>.SuccessResponse(response);
        }

        [HttpGet("{id}")]
        public ApiResponse<ProductoDto> GetById(int id)
        {
            var producto = _repository.GetById(id);
            if (producto == null)
                return ApiResponse<ProductoDto>.FailureResponse("Recurso no encontrado.", 404);

            var response = Mapper.Map<ProductoDto>(producto);
            return ApiResponse<ProductoDto>.SuccessResponse(response);
        }

        [HttpPost]
        public ApiResponse<ProductoDto> Create(CreateProductoDto dto)
        {
            var producto = Mapper.Map<Producto>(dto);
            _repository.Create(producto);

            var response = Mapper.Map<ProductoDto>(producto);
            return ApiResponse<ProductoDto>.SuccessResponse(response, 201);
        }

        [HttpPut("{id}")]
        public ApiResponse<ProductoDto> Update(int id, UpdateProductoDto dto)
        {
            var producto = Mapper.Map<Producto>(dto);
            var success = _repository.Update(id, producto);

            if (!success)
                return ApiResponse<ProductoDto>.FailureResponse("Producto no encontrado.", 404);

            var response = Mapper.Map<ProductoDto>(producto);
            return ApiResponse<ProductoDto>.SuccessResponse(response);
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

//        //private readonly DataContext _context;

//        public ProductoController(DataContext context, IMapper mapper) : base(context, mapper) { }

//        [HttpGet]
//        public virtual ApiResponse<List<Producto>> GetAll()
//        {
//            var response = _context.Productos.ToList();
//            return ApiResponse<List<Producto>>.SuccessResponse(response);
//        }

//        [HttpGet("{id}")]
//        public virtual ApiResponse<Producto> GetById(int id)
//        {
//            var response = _context.Productos.Find(id);
//            if (response == null)
//                return ApiResponse<Producto>.FailureResponse("Recurso no encontrado.", 404);
//            return ApiResponse<Producto>.SuccessResponse(response);
//        }


//        [HttpPost]
//        public ApiResponse<ProductoDto> Create(CreateProductoDto dto)
//        {
//            var producto = Mapper.Map<Producto>(dto);
//            _context.Productos.Add(producto);
//            _context.SaveChanges();

//            var response = Mapper.Map<ProductoDto>(producto);
//            return ApiResponse<ProductoDto>.SuccessResponse(response, 201);
//        }

//        [HttpPut("{id}")]
//        public ApiResponse<ProductoDto> Update(int id, UpdateProductoDto dto)
//        {
//            var producto = _context.Productos.Find(id);
//            if (producto == null)
//                return ApiResponse<ProductoDto>.FailureResponse("Producto no encontrado", 404);

//            Mapper.Map(dto, producto);
//            _context.SaveChanges();

//            var response = Mapper.Map<ProductoDto>(producto);
//            return ApiResponse<ProductoDto>.SuccessResponse(response, 201);
//        }

//        [HttpDelete("{id}")]
//        public virtual ApiResponse<string> Delete(int id)
//        {
//            var response = _context.Productos.Find(id);
//            if (response == null)
//                return ApiResponse<string>.FailureResponse("Recurso no encontrado.", 404);

//            _context.Productos.Remove(response);
//            _context.SaveChanges();
//            return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);