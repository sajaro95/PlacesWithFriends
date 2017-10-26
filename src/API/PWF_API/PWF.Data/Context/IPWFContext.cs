namespace PWF.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using PWF.Model;

    public interface IPWFContext : IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Buddy> Buddies { get; set; }
    }
}
