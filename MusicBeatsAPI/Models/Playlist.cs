using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicBeatsAPI.Models
{
    public class Playlist
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        public virtual List<Play> Plays { get; set; }

    }
}
