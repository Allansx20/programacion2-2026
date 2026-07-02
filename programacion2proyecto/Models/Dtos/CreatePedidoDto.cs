namespace programacion2proyecto.Models.Dtos
{
    public class CreatePedidoDto : BaseDto
    {
        public int ClienteId { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal Total { get; set; }
        public bool Pagado { get; set; } 
    }
}
