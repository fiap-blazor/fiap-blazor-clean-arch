using AutoMapper;
using FIAP.Fiapfy.Aplicacao.DTOs.Responses;
using FIAP.Fiapfy.Dominio.Entidades;

namespace FIAP.Fiapfy.Aplicacao.Profiles;

public class PlaylistMusicaProfile : Profile
{
    public PlaylistMusicaProfile()
    {
        CreateMap<PlaylistMusica, PlaylistMusicaResponse>();

        CreateMap<PlaylistMusica, PlaylistMusicaResponse>()
            .ForCtorParam("DataAdicao", opt => opt.MapFrom(src => src.DataAdicao))
            .ForCtorParam("Musica", opt => opt.MapFrom(src => src.Musica));
    }
}
