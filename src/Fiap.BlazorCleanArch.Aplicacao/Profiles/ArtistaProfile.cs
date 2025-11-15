using AutoMapper;
using Fiap.BlazorCleanArch.Aplicacao.DTOs.Responses;
using Fiap.BlazorCleanArch.Dominio.Entidades;

namespace Fiap.BlazorCleanArch.Aplicacao.Profiles;

public class ArtistaProfile : Profile
{
    public ArtistaProfile()
    {
        CreateMap<Artista, ArtistaResponse>();
    }
}
