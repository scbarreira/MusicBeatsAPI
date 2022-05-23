using AutoMapper;
using FluentResults;
using MusicBeatsAPI.Data;
using MusicBeatsAPI.Data.Dtos.Playlist;
using MusicBeatsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicBeatsAPI.Services
{
    public class PlaylistService
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public PlaylistService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadPlaylistDto AddPlaylist(Playlist playlistDto)
        {

            Playlist playlist = _mapper.Map<Playlist>(playlistDto);


            _context.Playlists.Add(playlist);
            _context.SaveChanges();
            return  _mapper.Map<ReadPlaylistDto>(playlist);
        }

        public List<ReadPlaylistDto> RetrieveSongs()
        {
            List<Playlist> songs = _context.Playlists.ToList();
            List<ReadPlaylistDto> readDto = _mapper.Map<List<ReadPlaylistDto>>(songs);
            if (readDto != null) return readDto;
            return null;
        }

        public List<ReadPlaylistDto> RetrievePlaylistsByName(string nome)
        {
            List<Playlist> playlists = _context.Playlists.Where(playlists => playlists.Nome.ToLower().Contains(nome.ToLower())).ToList();

            if (playlists != null)
            {
                List<ReadPlaylistDto> readDto = _mapper.Map<List<ReadPlaylistDto>>(playlists);
                return (readDto);

            }
            return null;
        }

        public Result UpdatePlaylist(int id, UpdatePlaylistDto playlistDto)
        {
            Playlist playlist = _context.Playlists.FirstOrDefault(playlist => playlist.Id == id);

            if (playlist == null)
            {
                return Result.Fail("Playlist não encontrada");
            }

            _mapper.Map(playlistDto, playlist);

            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteSong(int id)
        {
            Playlist playlist = _context.Playlists.FirstOrDefault(playlist => playlist.Id == id);

            if (playlist == null)
            {
                return Result.Fail("Playlist não encontrada");
            }

            _context.Playlists.Remove(playlist);
            _context.SaveChanges();
            return Result.Ok ();
        }
    }
}
