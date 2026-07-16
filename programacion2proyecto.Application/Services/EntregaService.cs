using AutoMapper;
using programacion2proyecto.Application.Models.Dtos;
using programacion2proyecto.Application.Models.Responses;
using programacion2proyecto.Domain.Entities;
using programacion2proyecto.Infraestructure.Repositories;

namespace programacion2proyecto.Application.Services
{
    public class EntregaService
    {
        private readonly UnitOfwork _unitOfWork;
        private readonly IMapper _mapper;

        public EntregaService(UnitOfwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ApiResponse<IEnumerable<EntregaDto>> GetAll()
        {
            var entregas = _unitOfWork.EntregaRepository.GetAll();
            var result = _mapper.Map<List<EntregaDto>>(entregas);
            return ApiResponse<IEnumerable<EntregaDto>>.SuccessResponse(result);
        }

        public ApiResponse<EntregaDto> GetById(int id)
        {
            var entrega = _unitOfWork.EntregaRepository.GetById(id);
            if (entrega == null)
                return ApiResponse<EntregaDto>.FailureResponse("Entrega no encontrada.", 404);

            var result = _mapper.Map<EntregaDto>(entrega);
            return ApiResponse<EntregaDto>.SuccessResponse(result);
        }

        public ApiResponse<EntregaDto> Create(CreateEntregaDto dto)
        {
            var pedido = _unitOfWork.PedidoRepository.GetById(dto.PedidoId);
            if (pedido == null)
                return ApiResponse<EntregaDto>.FailureResponse("El pedido indicado no existe.", 400);

            var entrega = _mapper.Map<Entrega>(dto);

            _unitOfWork.EntregaRepository.Create(entrega);
            _unitOfWork.Complete();

            var result = _mapper.Map<EntregaDto>(entrega);
            return ApiResponse<EntregaDto>.SuccessResponse(result, 201);
        }

        public ApiResponse<EntregaDto> Update(int id, UpdateEntregaDto dto)
        {
            var existente = _unitOfWork.EntregaRepository.GetById(id);
            if (existente == null)
                return ApiResponse<EntregaDto>.FailureResponse("Entrega no encontrada.", 404);

            if (!string.IsNullOrEmpty(dto.Tipo))
                existente.Tipo = dto.Tipo;

            if (!string.IsNullOrEmpty(dto.Direccion))
                existente.Direccion = dto.Direccion;

            if (dto.FechaProgramada.HasValue)
                existente.FechaProgramada = dto.FechaProgramada.Value;

            if (dto.Confirmada == true && !existente.Confirmada)
                existente.ConfirmarEntrega();

            _unitOfWork.EntregaRepository.Update(existente);
            _unitOfWork.Complete();

            var result = _mapper.Map<EntregaDto>(existente);
            return ApiResponse<EntregaDto>.SuccessResponse(result);
        }

        public ApiResponse<string> Delete(int id)
        {
            var success = _unitOfWork.EntregaRepository.Delete(id);
            if (!success)
                return ApiResponse<string>.FailureResponse("Entrega no encontrada.", 404);

            _unitOfWork.Complete();
            return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);
        }
    }
}