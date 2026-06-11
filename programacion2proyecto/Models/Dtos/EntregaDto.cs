namespace programacion2proyecto.Models.Dtos
{
    public class EntregaDto
    {
        public int PedidoId { get; set; }
        public string Tipo { get; set; } = "retiro";
        public string Direccion { get; set; } = string.Empty;
        public DateTime FechaProgramada { get; set; }
    }
}