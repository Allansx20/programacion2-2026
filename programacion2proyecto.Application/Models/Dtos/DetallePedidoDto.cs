namespace programacion2proyecto.Application.Models.Dtos
{
    public class DetallePedidoDto : BaseDto 
    {
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}