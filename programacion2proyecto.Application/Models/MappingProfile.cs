using AutoMapper;
using programacion2proyecto.Application.Models.Dtos;
using programacion2proyecto.Domain.Entities;

namespace programacion2proyecto.Application.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Define your mappings here
            //CreateMap<Cliente, ClienteDto>().ReverseMap().ReverseMap();
            ////CreateMap<ClienteDto, Cliente>().ReverseMap();

            //CreateMap<Pedido, PedidoDto>().ReverseMap();
            //CreateMap<Producto, ProductoDto>().ReverseMap();
            //CreateMap<Entrega, EntregaDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<UpdateClienteDto, Cliente>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<CreatePedidoDto, Pedido>();
            CreateMap<UpdatePedidoDto, Pedido>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<CreateProductoDto, Producto>();
            CreateMap<UpdateProductoDto, Producto>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Entrega, EntregaDto>().ReverseMap();
            CreateMap<CreateEntregaDto, Entrega>();
            CreateMap<UpdateEntregaDto, Entrega>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
