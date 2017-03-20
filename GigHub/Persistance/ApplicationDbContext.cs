using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Configuration;
using GigHub.Core.Models;
using GigHub.Persistance.EntityConfigurations;

namespace GigHub.Persistance
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet <Notification> Notifications { get; set; }
        public DbSet <UserNotification> UserNotifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GigConfiguration());

            modelBuilder.Entity<Following>()
                .HasRequired(f => f.Followee)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Following>()
                .HasRequired(f => f.Follower)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserNotification>()
                .HasRequired(n => n.User)
                .WithMany(u=>u.UserNotifications)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}