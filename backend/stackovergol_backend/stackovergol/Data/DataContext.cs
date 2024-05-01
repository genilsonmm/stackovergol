using Microsoft.EntityFrameworkCore;
using stackovergol.Data.Entity;

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
        }

        public DbSet<Player> Player { get; set; }
        public DbSet<stackovergol.Data.Entity.Match> Match { get; set; }
        public DbSet<PlayerMatchStatistic> PlayerMatchStatistic { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<EventPlayer> EventPlayer { get; set; }
        public DbSet<TeamMatch> TeamMatch { get; set; }

    }
}
