namespace programacion2proyecto.Application.Models.Dtos
{
    public class PedidoDto : BaseDto
    {
        public int ClienteId { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal Total { get; set; }
        public bool Pagado { get; set; } = false;
    }
}