using Microsoft.EntityFrameworkCore;
using MovimentationsApi.Models;

namespace MovimentationsApi.Data
{
    public class MovimentationsContext : DbContext
    {
        public MovimentationsContext(DbContextOptions<MovimentationsContext> options) : base(options) { }

        public DbSet<MovimentationUsecaseModel> Movimentations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStr = @"server=localhost,3306; User Id=root;database=movimentatinosapi; password=root";
            optionsBuilder.UseMySql(
                connectionStr,
                ServerVersion.AutoDetect(connectionStr),
                options => options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null)
                );
        }
    }
}
