using EFCore_MusicDB.Data;
using EFCore_MusicDB.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_MusicDB
{
    internal class Starter
    {
        public static void Run()
        {
            var options = CreateDbOptions();

            using (var dbContext = new ApplicationDbContext(options))
            {
                // ...
            }
        }

        private static DbContextOptions<ApplicationDbContext> CreateDbOptions()
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

            return options;
        }
    }
}
