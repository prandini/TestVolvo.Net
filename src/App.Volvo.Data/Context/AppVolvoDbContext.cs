using microblogAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace App.Volvo.Data.Context
{
    public class AppVolvoDbContext : DbContext
    {
        public AppVolvoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Business.Models.Caminhao> Caminhoes { get; set; }
        public DbSet<Business.Models.Modelo> Modelos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppVolvoDbContext).Assembly);
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
