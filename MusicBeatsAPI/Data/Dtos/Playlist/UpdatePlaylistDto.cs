using System.ComponentModel.DataAnnotations;

namespace MusicBeatsAPI.Data.Dtos.Playlist
{
    public class UpdatePlaylistDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

    }
}
