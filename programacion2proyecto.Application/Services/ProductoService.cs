using AutoMapper;
using programacion2proyecto.Application.Models.Dtos;
using programacion2proyecto.Application.Models.Responses;
using programacion2proyecto.Domain.Entities;
using programacion2proyecto.Infraestructure.Repositories;

namespace programacion2proyecto.Application.Services
{
    public class ProductoService
    {
        private readonly UnitOfwork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoService(UnitOfwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ApiResponse<IEnumerable<ProductoDto>> GetAll()
        {
            var productos = _unitOfWork.ProductoRepository.GetAll();
            var result = _mapper.Map<List<ProductoDto>>(productos);
            return ApiResponse<IEnumerable<ProductoDto>>.SuccessResponse(result);
        }

        public ApiResponse<ProductoDto> GetById(int id)
        {
            var producto = _unitOfWork.ProductoRepository.GetById(id);
            if (producto == null)
                return ApiResponse<ProductoDto>.FailureResponse("Producto no encontrado.", 404);

            var result = _mapper.Map<ProductoDto>(producto);
            return ApiResponse<ProductoDto>.SuccessResponse(result);
        }

        public ApiResponse<ProductoDto> Create(CreateProductoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                return ApiResponse<ProductoDto>.FailureResponse("El nombre es obligatorio.", 400);

            if (dto.PrecioBase < 0)
                return ApiResponse<ProductoDto>.FailureResponse("El precio base no puede ser negativo.", 400);

            var producto = _mapper.Map<Producto>(dto);

            _unitOfWork.ProductoRepository.Create(producto);
            _unitOfWork.Complete();

            var result = _mapper.Map<ProductoDto>(producto);
            return ApiResponse<ProductoDto>.SuccessResponse(result, 201);
        }

        public ApiResponse<ProductoDto> Update(int id, UpdateProductoDto dto)
        {
            var existente = _unitOfWork.ProductoRepository.GetById(id);
            if (existente == null)
                return ApiResponse<ProductoDto>.FailureResponse("Producto no encontrado.", 404);

            if (dto.PrecioBase.HasValue)
            {
                if (dto.PrecioBase < 0)
                    return ApiResponse<ProductoDto>.FailureResponse("El precio base no puede ser negativo.", 400);
                existente.PrecioBase = dto.PrecioBase.Value;
            }

            if (!string.IsNullOrEmpty(dto.Nombre))
                existente.Nombre = dto.Nombre;

            if (!string.IsNullOrEmpty(dto.Descripcion))
                existente.Descripcion = dto.Descripcion;

            if (!string.IsNullOrEmpty(dto.Categoria))
                existente.Categoria = dto.Categoria;

            if (dto.Disponible.HasValue)
            {
                if (dto.Disponible.Value) existente.Activar();
                else existente.Desactivar();
            }

            _unitOfWork.ProductoRepository.Update(existente);
            _unitOfWork.Complete();

            var result = _mapper.Map<ProductoDto>(existente);
            return ApiResponse<ProductoDto>.SuccessResponse(result);
        }

        public ApiResponse<string> Delete(int id)
        {
            var success = _unitOfWork.ProductoRepository.Delete(id);
            if (!success)
                return ApiResponse<string>.FailureResponse("Producto no encontrado.", 404);

            _unitOfWork.Complete();
            return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);
        }
    }
}