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
                @"server=localhost;port=3306;User Id=root;database=alan; password=root");
        }
    }
}
