using System.ComponentModel.DataAnnotations;

namespace MusicBeatsAPI.Models
{
    public class Play
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public virtual Playlist Playlist { get; set; }
        public int PlaylistId { get; set; }

        public virtual Song Song { get; set; }
        public int SongId { get; set; }
    }
}

