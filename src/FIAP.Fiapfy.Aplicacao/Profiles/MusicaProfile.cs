using AutoMapper;
using FIAP.Fiapfy.Aplicacao.DTOs.Responses;
using FIAP.Fiapfy.Dominio.Entidades;
using FIAP.Fiapfy.Dominio.Modelos;

namespace FIAP.Fiapfy.Aplicacao.Profiles;

public class MusicaProfile : Profile
{
    public MusicaProfile()
    {
        CreateMap<Musica, MusicaResponse>()
            .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("Nome", opt => opt.MapFrom(src => src.Nome))
            .ForCtorParam("Duracao", opt => opt.MapFrom(src => src.Duracao))
            .ForCtorParam("AlbumNome", opt => opt.MapFrom(src => src.Album.Nome))
            .ForCtorParam("AlbumCapaUrl", opt => opt.MapFrom(src => src.Album.CapaUrl))
            .ForCtorParam("ArtistaNome", opt => opt.MapFrom(src => src.Album.Artista.Nome));

        CreateMap<PaginacaoConsulta<Musica>, PaginacaoConsulta<MusicaResponse>>();
    }
}
