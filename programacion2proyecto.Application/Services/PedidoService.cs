using AutoMapper;
using programacion2proyecto.Application.Models.Dtos;
using programacion2proyecto.Application.Models.Responses;
using programacion2proyecto.Domain.Entities;
using programacion2proyecto.Infraestructure.Repositories;

namespace programacion2proyecto.Application.Services
{
    public class PedidoService
    {
        private readonly UnitOfwork _unitOfWork;
        private readonly IMapper _mapper;

        public PedidoService(UnitOfwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ApiResponse<IEnumerable<PedidoDto>> GetAll()
        {
            var pedidos = _unitOfWork.PedidoRepository.GetAll();
            var result = _mapper.Map<List<PedidoDto>>(pedidos);
            return ApiResponse<IEnumerable<PedidoDto>>.SuccessResponse(result);
        }

        public ApiResponse<PedidoDto> GetById(int id)
        {
            var pedido = _unitOfWork.PedidoRepository.GetById(id);
            if (pedido == null)
                return ApiResponse<PedidoDto>.FailureResponse("Pedido no encontrado.", 404);

            var result = _mapper.Map<PedidoDto>(pedido);
            return ApiResponse<PedidoDto>.SuccessResponse(result);
        }

        public ApiResponse<PedidoDto> Create(CreatePedidoDto dto)
        {
            var cliente = _unitOfWork.ClienteRepository.GetById(dto.ClienteId);
            if (cliente == null)
                return ApiResponse<PedidoDto>.FailureResponse("El cliente indicado no existe.", 400);

            if (dto.Total < 0)
                return ApiResponse<PedidoDto>.FailureResponse("El total no puede ser negativo.", 400);

            var pedido = _mapper.Map<Pedido>(dto);
            pedido.FechaPedido = DateTime.Now;
            pedido.Estado = "pendiente";

            _unitOfWork.PedidoRepository.Create(pedido);
            _unitOfWork.Complete();

            var result = _mapper.Map<PedidoDto>(pedido);
            return ApiResponse<PedidoDto>.SuccessResponse(result, 201);
        }

        public ApiResponse<PedidoDto> Update(int id, UpdatePedidoDto dto)
        {
            var existente = _unitOfWork.PedidoRepository.GetById(id);
            if (existente == null)
                return ApiResponse<PedidoDto>.FailureResponse("Pedido no encontrado.", 404);

            if (dto.Total.HasValue && dto.Total < 0)
                return ApiResponse<PedidoDto>.FailureResponse("El total no puede ser negativo.", 400);

            // Pagado se aplica antes del cambio de estado: CambiarEstado depende de este valor
            if (dto.Pagado.HasValue)
                existente.Pagado = dto.Pagado.Value;

            if (!string.IsNullOrEmpty(dto.Estado))
            {
                var pudoCambiar = existente.CambiarEstado(dto.Estado);
                if (!pudoCambiar)
                    return ApiResponse<PedidoDto>.FailureResponse(
                        "No se puede marcar el pedido como 'entregado' si no está pagado.", 400);
            }

            if (dto.FechaEntrega.HasValue)
                existente.FechaEntrega = dto.FechaEntrega;

            if (dto.Total.HasValue)
                existente.Total = dto.Total.Value;

            _unitOfWork.PedidoRepository.Update(existente);
            _unitOfWork.Complete();

            var result = _mapper.Map<PedidoDto>(existente);
            return ApiResponse<PedidoDto>.SuccessResponse(result);
        }

        public ApiResponse<string> Delete(int id)
        {
            var success = _unitOfWork.PedidoRepository.Delete(id);
            if (!success)
                return ApiResponse<string>.FailureResponse("Pedido no encontrado.", 404);

            _unitOfWork.Complete();
            return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);
        }
    }
}