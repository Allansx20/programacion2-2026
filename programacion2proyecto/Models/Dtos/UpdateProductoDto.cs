namespace programacion2proyecto.Models.Dtos
{
    public class UpdateProductoDto : BaseDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal PrecioBase { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Disponible { get; set; }
    }
}
