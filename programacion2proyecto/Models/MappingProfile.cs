using AutoMapper;
using programacion2proyecto.Models.Dtos;
using programacion2proyecto.Models.Entities;

namespace programacion2proyecto.Models
{
    public class MappingProfile: Profile
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
            CreateMap<UpdateClienteDto, Cliente>();

            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<CreatePedidoDto, Pedido>();
            CreateMap<UpdatePedidoDto, Pedido>();

            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<CreateProductoDto, Producto>();
            CreateMap<UpdateProductoDto, Producto>();

            CreateMap<Entrega, EntregaDto>().ReverseMap();
            CreateMap<CreateEntregaDto, Entrega>();
            CreateMap<UpdateEntregaDto, Entrega>();

        }   
    }
}
    