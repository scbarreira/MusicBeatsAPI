using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using MusicBeatsAPI.Data;
using MusicBeatsAPI.Data.Dtos.Song;
using MusicBeatsAPI.Models;
using MusicBeatsAPI.Services;
using System.Collections.Generic;
using System.Linq;

namespace MusicBeatsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SongController : ControllerBase
    {
        private SongService _songService;

        public SongController(SongService songService)
        {
            _songService = songService;
        }

        [HttpPost]
        public IActionResult AddSong([FromBody] CreateSongDto songDto)
        {
            ReadSongDto readSongDto = _songService.AddSong(songDto);
            return CreatedAtAction(nameof(RetrieveSongsByName), new { Titulo = songDto.Titulo }, songDto);
        }

        [HttpGet]
        public IActionResult RetrieveSongs()
        {
            List<ReadSongDto> readDto = _songService.RetrieveSongs();
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{titulo}")]
        public IActionResult RetrieveSongsByName(string titulo)
        {
            List<ReadSongDto> readDto = _songService.RetrieveSongsByName(titulo);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSong(int id, [FromBody] UpdateSongDto songDto)
        {

            Result result = _songService.UpdateSong(id, songDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSong(int id)
        {

            Result result = _songService.DeleteSong(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
