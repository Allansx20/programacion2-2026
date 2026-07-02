namespace programacion2proyecto.Models.Dtos
{
    public class CreateEntregaDto : BaseDto
    {
        public int PedidoId { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public DateTime FechaProgramada { get; set; }

    }
}
