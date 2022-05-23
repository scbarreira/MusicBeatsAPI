using System.ComponentModel.DataAnnotations;

namespace MusicBeatsAPI.Data.Dtos.Playlist
{
    public class ReadPlaylistDto
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
    }
}
