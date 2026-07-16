using programacion2proyecto.Infraestructure.Contex;

namespace programacion2proyecto.Infraestructure.Repositories
{
    public class UnitOfwork
    {
        private readonly DataContext _context;

        public ClienteRepository ClienteRepository { get; }
        public PedidoRepository PedidoRepository { get; }
        public ProductoRepository ProductoRepository { get; }
        public EntregaRepository EntregaRepository { get; }

        public UnitOfwork(
           DataContext context,
           ClienteRepository clienteRepository,
           PedidoRepository pedidoRepository,
           ProductoRepository productoRepository,
           EntregaRepository entregaRepository)
        {
            _context = context;
            ClienteRepository = clienteRepository;
            PedidoRepository = pedidoRepository;
            ProductoRepository = productoRepository;
            EntregaRepository = entregaRepository;
        }
        public void Complete()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void commitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void rollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }


    }
}