using programacion2proyecto.Domain.Entities;
using programacion2proyecto.Infraestructure.Contex;

namespace programacion2proyecto.Infraestructure.Repositories
{
    public class EntregaRepository
    {
        readonly DataContext _context;

        public EntregaRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Entrega> GetAll()
        {
            var entregas = _context.Entregas.ToList();
            return entregas;
        }

        public Entrega? GetById(int id)
        {
            var entrega = _context.Entregas.FirstOrDefault(e => e.Id == id);
            return entrega;
        }

        public int Create(Entrega entrega)
        {
            _context.Entregas.Add(entrega);
            _context.SaveChanges();
            return entrega.Id;
        }

        public bool Update(int id, Entrega request)
        {
            var existing = _context.Entregas.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return false;

            existing.Tipo = request.Tipo;
            existing.Direccion = request.Direccion;
            existing.FechaProgramada = request.FechaProgramada;
            existing.Confirmada = request.Confirmada;

            _context.Entregas.Update(existing);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existing = _context.Entregas.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return false;

            _context.Entregas.Remove(existing);
            _context.SaveChanges();
            return true;
        }
    }
}