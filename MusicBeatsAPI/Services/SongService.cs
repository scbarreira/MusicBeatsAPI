using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using MusicBeatsAPI.Data;
using MusicBeatsAPI.Data.Dtos.Song;
using MusicBeatsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicBeatsAPI.Services
{
    public class SongService
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public SongService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSongDto AddSong(CreateSongDto songDto)
        {
            Song song = _mapper.Map<Song>(songDto);

            _context.Songs.Add(song);
            _context.SaveChanges();
            return _mapper.Map<ReadSongDto>(song);
        }

        public List<ReadSongDto> RetrieveSongs()
        {
            List<Song> songs = _context.Songs.ToList();
            List<ReadSongDto> readDto = _mapper.Map<List<ReadSongDto>>(songs);
            if (readDto != null )return readDto;
            return null;
        }

        public List<ReadSongDto> RetrieveSongsByName(string titulo)
        {
            List<Song> songs = _context.Songs.Where(song => song.Titulo.ToLower().Contains(titulo.ToLower())).ToList();

            if (songs != null) 
            {
                List<ReadSongDto> readDto = _mapper.Map<List<ReadSongDto>>(songs);
                return (readDto);

            }
            return null;
        }

        public Result UpdateSong(int id, UpdateSongDto songDto)
        {
            Song song = _context.Songs.FirstOrDefault(song => song.Id == id);

            if (song == null)
            {
                return Result.Fail("Música não encontrada");
            }

            _mapper.Map(songDto, song);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeleteSong(int id)
        {
            Song song = _context.Songs.FirstOrDefault(song => song.Id == id);

            if (song == null)
            {
                return Result.Fail("Música não encontrada");
            }
            _context.Songs.Remove(song);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
