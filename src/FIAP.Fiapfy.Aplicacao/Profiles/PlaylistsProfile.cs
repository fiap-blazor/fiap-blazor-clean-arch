using AutoMapper;
using FIAP.Fiapfy.Aplicacao.DTOs.Responses;
using FIAP.Fiapfy.Dominio.Entidades;

namespace FIAP.Fiapfy.Aplicacao.Profiles;

public class PlaylistsProfile : Profile
{
    public PlaylistsProfile()
    {
        CreateMap<Playlist, PlaylistListarResponse>();

        CreateMap<Playlist, PlaylistResponse>();        
    }
}
