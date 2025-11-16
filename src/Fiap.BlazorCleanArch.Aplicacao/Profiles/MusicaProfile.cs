using AutoMapper;
using Fiap.BlazorCleanArch.Aplicacao.DTOs;
using Fiap.BlazorCleanArch.Aplicacao.DTOs.Responses;
using Fiap.BlazorCleanArch.Dominio.Entidades;
using Fiap.BlazorCleanArch.Dominio.Modelos;

namespace Fiap.BlazorCleanArch.Aplicacao.Profiles;

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
