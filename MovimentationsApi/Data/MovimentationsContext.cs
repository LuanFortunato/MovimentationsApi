using Microsoft.EntityFrameworkCore;
using MovimentationsApi.Models;

namespace MovimentationsApi.Data
{
    public class MovimentationsContext : DbContext
    {
        public DbSet<MovimentationUsecaseModel> Movimentations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"server=localhost;User Id=root;database=movimentatinosapi; password=root; TrustServerCertificate=True);
        }
    }
}
