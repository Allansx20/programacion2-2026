namespace programacion2proyecto.Models.Dtos
{
    public class UpdatePedidoDto : BaseDto
    {
        public DateTime FechaEntrega { get; set; }
        public string Estado { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public bool Pagado { get; set; }


    }
}
