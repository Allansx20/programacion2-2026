using Microsoft.EntityFrameworkCore;
using programacion2proyecto.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace programacion2proyecto.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        [Key]

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}