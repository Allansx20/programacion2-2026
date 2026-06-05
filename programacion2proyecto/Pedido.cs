namespace programacion2proyecto
{
    using System;

    namespace programacion2proyecto.Models
    {
        public class Pedido
        {
            public int Id { get; set; }
            public int ClienteId { get; set; }
            public Cliente? Cliente { get; set; }
            public DateTime FechaPedido { get; set; }
            public DateTime? FechaEntrega { get; set; }
            public string Estado { get; set; } = "pendiente";
            public decimal Total { get; set; }
            public bool Pagado { get; set; } = false;

            public bool CambiarEstado(string nuevoEstado)
            {
                if (nuevoEstado == "entregado" && !Pagado)
                    return false;

                Estado = nuevoEstado;
                return true;
            }

            public override string ToString()
            {
                return $"Pedido #{Id} | Cliente: {ClienteId} | " +
                       $"Estado: {Estado} | Total: {Total} | " +
                       $"Pagado: {Pagado}";
            }
        }
    }
    public class Pedido
    {
    }
}
