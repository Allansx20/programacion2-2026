namespace programacion2proyecto.Application.Models.Dtos
{
    public class EntregaDto : BaseDto
    {
        public int PedidoId { get; set; }
        public string Tipo { get; set; } = "retiro";
        public string Direccion { get; set; } = string.Empty;
        public DateTime FechaProgramada { get; set; }
        public DateTime? FechaReal { get; set; }
        public bool Confirmada { get; set; }
    }
}