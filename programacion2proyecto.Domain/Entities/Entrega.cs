using programacion2proyecto.Domain.Core;

namespace programacion2proyecto.Domain.Entities
{
    public class Entrega : BaseEntity
    {
        //public int Id { get; set; }
        public int PedidoId { get; set; }
        public string Tipo { get; set; } = "retiro";
        public string Direccion { get; set; } = string.Empty;
        public DateTime FechaProgramada { get; set; }
        public DateTime? FechaReal { get; set; }
        public bool Confirmada { get; set; } = false;

        public void ConfirmarEntrega()
        {
            Confirmada = true;
            FechaReal = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Entrega #{Id} | Pedido: {PedidoId} | Tipo: {Tipo} | Fecha: {FechaProgramada:dd/MM/yyyy} | Confirmada: {Confirmada}";
        }
    }
}