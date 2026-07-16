namespace programacion2proyecto.Application.Models.Dtos
{
    public class UpdateEntregaDto
    {
        public string? Tipo { get; set; } 
        public string? Direccion { get; set; } 
        public DateTime? FechaProgramada { get; set; }
        public bool? Confirmada { get; set; }

    }
}
