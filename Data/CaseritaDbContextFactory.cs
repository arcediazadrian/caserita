using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Caserita_Data
{
    public class CaseritaDbContextFactory : IDesignTimeDbContextFactory<CaseritaDbContext>
    {
        public CaseritaDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CaseritaDbContext>();
            var connectionString = configuration.GetConnectionString("CaseritaDb");
            optionsBuilder.UseSqlServer(connectionString);

            return new CaseritaDbContext(optionsBuilder.Options);
        }
    }
}
