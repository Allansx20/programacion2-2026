namespace programacion2proyecto.Application.Models.Dtos
{
    public class UpdateProductoDto
    {
        public string? Nombre { get; set; } 
        public string? Descripcion { get; set; } 
        public decimal? PrecioBase { get; set; }
        public string? Categoria { get; set; } 
        public bool? Disponible { get; set; }
    }
}
