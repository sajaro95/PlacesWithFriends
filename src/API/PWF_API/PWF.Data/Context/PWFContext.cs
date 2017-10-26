namespace PWF.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Model;

    public class PWFContext : DbContext, IPWFContext
    {
        public PWFContext(DbContextOptions<PWFContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Buddy> Buddies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buddy>()
                .HasKey(b => new { b.MainUserId, b.BuddyUserId });

            modelBuilder.Entity<Buddy>()
                .HasOne(b => b.MainUser)
                .WithMany(mu => mu.MainUserBuddies)
                .HasForeignKey(b => b.MainUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Buddy>()
                .HasOne(b => b.BuddyUser)
                .WithMany(u => u.Buddies)
                .HasForeignKey(b => b.BuddyUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
