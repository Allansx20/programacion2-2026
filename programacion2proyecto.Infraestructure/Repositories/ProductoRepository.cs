using programacion2proyecto.Domain.Entities;
using programacion2proyecto.Infraestructure.Contex;

namespace programacion2proyecto.Infraestructure.Repositories
{
    public class ProductoRepository
    {
        readonly DataContext _context;

        public ProductoRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto> GetAll()
        {
            var productos = _context.Productos.ToList();
            return productos;
        }

        public Producto? GetById(int id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Id == id);
            return producto;
        }

        public int Create(Producto producto)
        {
            _context.Productos.Add(producto);
            //_context.SaveChanges();
            return producto.Id;
        }

        public bool Update(int id, Producto request)
        {
            var existing = _context.Productos.FirstOrDefault(p => p.Id == id);
            if (existing == null)
                return false;

            existing.Nombre = request.Nombre;
            existing.Descripcion = request.Descripcion;
            existing.PrecioBase = request.PrecioBase;
            existing.Categoria = request.Categoria;
            existing.Disponible = request.Disponible;

            _context.Productos.Update(existing);
            //_context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existing = _context.Productos.FirstOrDefault(p => p.Id == id);
            if (existing == null)
                return false;

            _context.Productos.Remove(existing);
            //_context.SaveChanges();
            return true;
        }

        public void Update(Producto existente)
        {
            throw new NotImplementedException();
        }
    }
}