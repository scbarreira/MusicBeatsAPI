using System.ComponentModel.DataAnnotations;

namespace MusicBeatsAPI.Data.Dtos.Song
{
    public class ReadSongDto
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo artista é obrigatório")]
        public string Artista { get; set; }

        [Required(ErrorMessage = "O campo gênero é obrigatório")]
        public string Genero { get; set; }

        //[Required(ErrorMessage = "O campo BPM é obrigatório")]
        public int Bpm { get; set; }

        [Required(ErrorMessage = "O campo duração é obrigatório")]
        public float Duracao { get; set; }
    }
}
