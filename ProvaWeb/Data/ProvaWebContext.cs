using Microsoft.EntityFrameworkCore;
using ProvaWeb.Models;

namespace ProvaWeb.Data
{
    public class ProvaWebContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public ProvaWebContext(DbContextOptions<ProvaWebContext> options) : base(options) { }
    }
}
