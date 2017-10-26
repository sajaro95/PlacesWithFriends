namespace PWF.Data.Context
{
    using Microsoft.EntityFrameworkCore;

    public class PWFContextFactory
    {
        public static PWFContext Create (string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PWFContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var context = new PWFContext(optionsBuilder.Options);

            return context;
        }
    }
}
