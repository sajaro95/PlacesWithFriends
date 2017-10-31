namespace PWF.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class PWFContextFactory : IDesignTimeDbContextFactory<PWFContext>
    {
        public static PWFContext Create (string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PWFContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var context = new PWFContext(optionsBuilder.Options);

            return context;
        }

        // Used only by EFCore Migrations
        public PWFContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PWFContext>();
            builder.UseSqlServer("Server = tcp:pwf.database.windows.net, 1433; Initial Catalog = pwf; Persist Security Info = False; User ID = pwf_admin; Password = ee418_places_2017; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            return new PWFContext(builder.Options);
        }
    }
}
