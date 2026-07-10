using programacion2proyecto.Context;
using programacion2proyecto.Domain.Entities;

namespace programacion2proyecto.Infraestructure.Repositories
{
    public class PedidoRepository
    {
        readonly DataContext _context;

        public PedidoRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Pedido> GetAll()
        {
            var pedidos = _context.Pedidos.ToList();
            return pedidos;
        }

        public Pedido? GetById(int id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == id);
            return pedido;
        }

        public int Create(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return pedido.Id;
        }

        public bool Update(int id, Pedido request)
        {
            var existing = _context.Pedidos.FirstOrDefault(p => p.Id == id);
            if (existing == null)
                return false;

            existing.FechaEntrega = request.FechaEntrega;
            existing.Estado = request.Estado;
            existing.Total = request.Total;
            existing.Pagado = request.Pagado;

            _context.Pedidos.Update(existing);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existing = _context.Pedidos.FirstOrDefault(p => p.Id == id);
            if (existing == null)
                return false;

            _context.Pedidos.Remove(existing);
            _context.SaveChanges();
            return true;
        }
    }
}