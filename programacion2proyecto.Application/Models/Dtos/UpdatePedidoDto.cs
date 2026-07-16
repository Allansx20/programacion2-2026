namespace programacion2proyecto.Application.Models.Dtos
{
    public class UpdatePedidoDto
    {
        public DateTime? FechaEntrega { get; set; }
        public string? Estado { get; set; } 
        public decimal? Total { get; set; }
        public bool? Pagado { get; set; }


    }
}
