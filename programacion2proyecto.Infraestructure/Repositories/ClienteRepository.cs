using programacion2proyecto.Domain.Entities;
using programacion2proyecto.Infraestructure.Contex;

namespace programacion2proyecto.Infraestructure.Repositories
{
    public class ClienteRepository
    {
        readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetAll()
        {
            var clientes = _context.Clientes.ToList();
            return clientes;
        }

        public Cliente? GetById(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            return cliente;
        }

        public int Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente.Id;
        }

        public bool Update(int id, Cliente request)
        {
            var existing = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (existing == null)
                return false;

            existing.Nombre = request.Nombre;
            existing.Telefono = request.Telefono;
            existing.Email = request.Email;
            existing.Direccion = request.Direccion;

            _context.Clientes.Update(existing);
            _context.SaveChanges();
            return true;

        }

        public bool Delete(int id)
        {
            var existing = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (existing == null)
                return false;


            _context.Clientes.Remove(existing);
            _context.SaveChanges();
            return true;

        }
    }
}