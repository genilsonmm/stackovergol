using Microsoft.EntityFrameworkCore;
using stackovergol.Data.Entity;
using stackovergol.Infra.Security;

namespace stackovergol.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(t => t.TeamLeft)
                .WithMany()
                .HasForeignKey(t => t.TeamLeftId);

            modelBuilder.Entity<Match>()
                .HasOne(t => t.TeamRight)
                .WithMany()
                .HasForeignKey(t => t.TeamRightId);

            InitialData(modelBuilder);
        }

        private void InitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,
                    Name = "ADMIN",
                });

            modelBuilder.Entity<Player>().HasData(
                new Player { 
                    PlayerId = 1,
                    Name = "Genilson Medeiros",
                    Username = "genilson.martins",
                    Password = TokenManager.Encrypted("123456"),
                    Phone = "83981808066",
                    Email = "genisnilson@gmail.com",
                    Rating = 4,
                    RoleId = 1,
                    IsGoalkeeper = false,
                    Enabled = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public DbSet<Player> Player { get; set; }
        public DbSet<stackovergol.Data.Entity.Match> Match { get; set; }
        public DbSet<PlayerMatchStatistic> PlayerMatchStatistic { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventPlayer> EventPlayer { get; set; }
        public DbSet<TeamMatch> TeamMatch { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
