using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=InventoryControlDb;User Id=sa;Password=Senha123.;TrustServerCertificate=True;Encrypt=False;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
