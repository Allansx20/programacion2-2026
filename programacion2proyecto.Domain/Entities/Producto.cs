using programacion2proyecto.Domain.Core;

namespace programacion2proyecto.Domain.Entities
{
    public class Producto : BaseEntity
    {
        //public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal PrecioBase { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Disponible { get; set; } = true;

        public void Activar() => Disponible = true;
        public void Desactivar() => Disponible = false;

        public override string ToString()
        {
            return $"Producto: {Nombre} | Precio: {PrecioBase} | Categoría: {Categoria} | Disponible: {Disponible}";
        }
    }
}