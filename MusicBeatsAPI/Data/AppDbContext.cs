using Microsoft.EntityFrameworkCore;
using MusicBeatsAPI.Models;

namespace MusicBeatsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Play>()
                .HasOne(play => play.Playlist)
                .WithMany(playlist => playlist.Plays)
                .HasForeignKey(play => play.PlaylistId);

            builder.Entity<Play>()
                    .HasOne(play => play.Song)
                    .WithMany(song => song.Plays)
                    .HasForeignKey(play => play.SongId);
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet <Play> Plays { get; set; }
    }
}
