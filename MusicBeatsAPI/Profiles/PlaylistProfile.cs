using AutoMapper;
using MusicBeatsAPI.Data.Dtos.Playlist;
using MusicBeatsAPI.Models;

namespace MusicBeatsAPI.Profiles
{
    public class PlaylistProfile : Profile
    {
        public PlaylistProfile()
        {
            CreateMap<CreatePlaylistDto, Playlist>();
            CreateMap<Playlist, ReadPlaylistDto>();
            CreateMap<UpdatePlaylistDto, Playlist>();
        }
    }
}
