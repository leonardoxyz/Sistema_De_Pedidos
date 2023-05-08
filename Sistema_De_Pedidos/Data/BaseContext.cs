using Microsoft.EntityFrameworkCore;
using Sistema_De_Pedidos.Models;

namespace Sistema_De_Pedidos.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)  : base(options)
        {

        }
        public DbSet<ProductModel> Products { get; set; }
    }
}
