using eshop_webapi.api.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop_webapi.api.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}