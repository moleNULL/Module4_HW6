using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using EFCore_MusicDB.Helpers;

namespace EFCore_MusicDB.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile(Constants.JsonConfig);

            var config = builder.Build();
            string? connectionString = config.GetConnectionString(Constants.ConnectionKeySection);

            if (connectionString is null)
            {
                throw new Exception("connectionString is null");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            return new ApplicationDbContext(options);
        }
    }
}
