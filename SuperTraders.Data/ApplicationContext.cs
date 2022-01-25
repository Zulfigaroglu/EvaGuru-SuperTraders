using System;
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
        public DbSet<Share> Shares { get; set; }
        public DbSet<BuyOrder> BuyOrders { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

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

            modelBuilder.Entity<Share>()
                .HasData(
                    new Share()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Lorem Ipsum",
                        Code = "LIP",
                    },
                    new Share()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Dolor Sit Amer",
                        Code = "DSA",
                    },
                    new Share()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Consectetur Adipiscing Elit",
                        Code = "CAE",
                    }
                );
            
            modelBuilder.Entity<User>()
                .HasData(
                    new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "osman",
                        Password = "123456",
                        EMail = "osman@zulfigaroglu.com",
                        AuthToken = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiIiwibmJmIjoxNjQzMTM1NDU0LCJleHAiOjE2NDU3Mjc0NTQsImlhdCI6MTY0MzEzNTQ1NH0.jb-M5NOTieF1GDR1mHsc9YtFLKUB4uSjZVSfZbh-APg"
                    },
                    new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "lorem",
                        Password = "123456",
                        EMail = "lorem@ipsum.com",
                        AuthToken = ""
                    },
                    new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "dolor",
                        Password = "123456",
                        EMail = "dolor@sitamet.com",
                        AuthToken = ""
                    }
                );
        }
    }
}