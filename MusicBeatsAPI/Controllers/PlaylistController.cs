using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using MusicBeatsAPI.Data;
using MusicBeatsAPI.Data.Dtos.Playlist;
using MusicBeatsAPI.Models;
using MusicBeatsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicBeatsAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : ControllerBase
    {
        private PlaylistService _playlistService;

        public PlaylistController(PlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpPost]
            public IActionResult AddPlaylist([FromBody] Playlist playlistDto)
            {
                ReadPlaylistDto readDto = _playlistService.AddPlaylist(playlistDto);
                return CreatedAtAction(nameof(RetrievePlaylistsByName), new { Nome = playlistDto.Nome }, playlistDto);
            }


            [HttpGet]
            public IActionResult RetrievePlaylists()
            {
                List<ReadPlaylistDto> readDto = _playlistService.RetrieveSongs();
                if (readDto != null) return Ok(readDto);
                return NotFound();
            }

        [HttpGet("{nome}")]
        public IActionResult RetrievePlaylistsByName(string nome)
        {

            List<ReadPlaylistDto> readDto = _playlistService.RetrievePlaylistsByName(nome);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlaylist(int id, [FromBody] UpdatePlaylistDto playlistDto)
        {

            Result result = _playlistService.UpdatePlaylist(id, playlistDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSong(int id)
        {

            Result result = _playlistService.DeleteSong(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
