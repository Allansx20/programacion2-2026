namespace programacion2proyecto.Models.Dtos
{
    public class UpdateEntregaDto : BaseDto
    {
        public string Tipo { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public DateTime FechaProgramada { get; set; }
        public bool Confirmada { get; set; }

    }
}
