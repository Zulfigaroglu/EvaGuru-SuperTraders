using Microsoft.EntityFrameworkCore;
using SuperTraders.Core.Entities;

namespace SuperTraders.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserShare>()
                .HasOne(UserShare => UserShare.User)
                .WithMany(User => User.UserShares)
                .HasForeignKey(UserShare => UserShare.UserId);

            modelBuilder.Entity<UserShare>()
                .HasOne(UserShare => UserShare.Share)
                .WithMany(t => t.UserShares)
                .HasForeignKey(UserShare => UserShare.ShareId);
        }
    }
}