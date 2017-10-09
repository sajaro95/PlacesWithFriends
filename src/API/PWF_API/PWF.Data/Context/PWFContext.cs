namespace PWF.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Model;

    public class PWFContext : DbContext
    {
        public PWFContext(DbContextOptions<PWFContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Buddy> Buddies { get; set; }
    }
}
