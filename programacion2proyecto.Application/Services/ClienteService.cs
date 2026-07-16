using AutoMapper;
using programacion2proyecto.Application.Models.Dtos;
using programacion2proyecto.Application.Models.Responses;
using programacion2proyecto.Domain.Entities;
using programacion2proyecto.Infraestructure.Repositories;

namespace programacion2proyecto.Application.Services
{
    public class ClienteService
    {
        private readonly UnitOfwork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteService(UnitOfwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ApiResponse<IEnumerable<ClienteDto>> GetAll()
        {
            var clientes = _unitOfWork.ClienteRepository.GetAll();
            var result = _mapper.Map<List<ClienteDto>>(clientes);
            return ApiResponse<IEnumerable<ClienteDto>>.SuccessResponse(result);
        }

        public ApiResponse<ClienteDto> GetById(int id)
        {
            var cliente = _unitOfWork.ClienteRepository.GetById(id);
            if (cliente == null)
                return ApiResponse<ClienteDto>.FailureResponse("Cliente no encontrado.", 404);

            var result = _mapper.Map<ClienteDto>(cliente);
            return ApiResponse<ClienteDto>.SuccessResponse(result);
        }

        public ApiResponse<ClienteDto> Create(CreateClienteDto dto)
        {
            if (!Cliente.ValidarEmail(dto.Email))
                return ApiResponse<ClienteDto>.FailureResponse("El email no tiene un formato válido.", 400);

            if (!Cliente.ValidarTelefono(dto.Telefono))
                return ApiResponse<ClienteDto>.FailureResponse("El teléfono no tiene un formato válido.", 400);

            var emailDuplicado = _unitOfWork.ClienteRepository.GetAll().Any(c => c.Email == dto.Email);
            if (emailDuplicado)
                return ApiResponse<ClienteDto>.FailureResponse("Ya existe un cliente con ese email.", 400);

            var cliente = _mapper.Map<Cliente>(dto);
            cliente.FechaRegistro = DateTime.Now;

            _unitOfWork.ClienteRepository.Create(cliente);
            _unitOfWork.Complete();

            var result = _mapper.Map<ClienteDto>(cliente);
            return ApiResponse<ClienteDto>.SuccessResponse(result, 201);
        }

        public ApiResponse<ClienteDto> Update(int id, UpdateClienteDto dto)
        {
            var existente = _unitOfWork.ClienteRepository.GetById(id);
            if (existente == null)
                return ApiResponse<ClienteDto>.FailureResponse("Cliente no encontrado.", 404);

            if (!string.IsNullOrEmpty(dto.Email))
            {
                if (!Cliente.ValidarEmail(dto.Email))
                    return ApiResponse<ClienteDto>.FailureResponse("El email no tiene un formato válido.", 400);
                existente.Email = dto.Email;
            }

            if (!string.IsNullOrEmpty(dto.Telefono))
            {
                if (!Cliente.ValidarTelefono(dto.Telefono))
                    return ApiResponse<ClienteDto>.FailureResponse("El teléfono no tiene un formato válido.", 400);
                existente.Telefono = dto.Telefono;
            }

            if (!string.IsNullOrEmpty(dto.Nombre))
                existente.Nombre = dto.Nombre;

            if (!string.IsNullOrEmpty(dto.Direccion))
                existente.Direccion = dto.Direccion;

            _unitOfWork.ClienteRepository.Update(existente);
            _unitOfWork.Complete();

            var result = _mapper.Map<ClienteDto>(existente);
            return ApiResponse<ClienteDto>.SuccessResponse(result);
        }

        public ApiResponse<string> Delete(int id)
        {
            var success = _unitOfWork.ClienteRepository.Delete(id);
            if (!success)
                return ApiResponse<string>.FailureResponse("Cliente no encontrado.", 404);

            _unitOfWork.Complete();
            return ApiResponse<string>.SuccessResponse("Eliminado correctamente.", 200);
        }

        public object GetAllCliente()
        {
            throw new NotImplementedException();
        }
    }
}