using Microsoft.EntityFrameworkCore;
using SimpleCRUD_MVC.Data.Models;
using SimpleCRUD_MVC.Business.Models.Input;
using SimpleCRUD_MVC.Business.Models.Output;

namespace SimpleCRUD_MVC.Data
{
    public class SimpleCRUD_MVCContext : DbContext
    {
        public SimpleCRUD_MVCContext(DbContextOptions<SimpleCRUD_MVCContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<SimpleCRUD_MVC.Business.Models.Input.ClientInput>? ClientInput { get; set; }
        public DbSet<SimpleCRUD_MVC.Business.Models.Output.ClientOutput>? ClientOutput { get; set; }
    }
}
