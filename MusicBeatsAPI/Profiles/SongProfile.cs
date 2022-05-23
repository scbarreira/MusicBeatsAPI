using AutoMapper;
using MusicBeatsAPI.Data.Dtos.Song;
using MusicBeatsAPI.Models;

namespace MusicBeatsAPI.Profiles
{
    public class SongProfile : Profile
    {

        public SongProfile()
        {
            CreateMap<CreateSongDto, Song>();
            CreateMap<Song, ReadSongDto>();
            CreateMap<UpdateSongDto, Song>();
        }
    }
}
