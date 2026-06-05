namespace programacion2proyecto
{
    using System;

    namespace programacion2proyecto.Models
    {
        public class Entrega
        {
            public int Id { get; set; }
            public int PedidoId { get; set; }
            public Pedido? Pedido { get; set; }
            public string Tipo { get; set; } = "retiro";
            public string? Direccion { get; set; }
            public DateTime FechaProgramada { get; set; }
            public DateTime? FechaReal { get; set; }
            public bool Confirmada { get; set; } = false;

            public bool ConfirmarEntrega()
            {
                if (Pedido != null && !Pedido.Pagado)
                    return false;

                Confirmada = true;
                FechaReal = DateTime.Now;

                if (Pedido != null)
                    Pedido.CambiarEstado("entregado");

                return true;
            }

            public override string ToString()
            {
                return $"Entrega #{Id} | Pedido: {PedidoId} | " +
                       $"Tipo: {Tipo} | " +
                       $"Fecha: {FechaProgramada:dd/MM/yyyy} | " +
                       $"Confirmada: {Confirmada}";
            }
        }
    }
    public class Entrega
    {
    }
}
