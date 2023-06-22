using ApiExec.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExec.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                 .HasKey(k => k.Id);


        
        }
    }
}
