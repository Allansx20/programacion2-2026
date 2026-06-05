namespace programacion2proyecto
{
    using System;

    namespace programacion2proyecto.Models
    {
        public class Producto
        {
            public int Id { get; set; }
            public string? Nombre { get; set; }
            public string? Descripcion { get; set; }
            public decimal PrecioBase { get; set; }
            public string? Categoria { get; set; }
            public bool Disponible { get; set; } = true;

            public void Activar() => Disponible = true;
            public void Desactivar() => Disponible = false;

            public override string ToString()
            {
                return $"Producto: {Nombre} | Precio: {PrecioBase} | " +
                       $"Categoría: {Categoria} | " +
                       $"Disponible: {Disponible}";
            }
        }
    }
    public class Producto
    {
    }
}
