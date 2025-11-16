using AutoMapper;
using Fiap.BlazorCleanArch.Aplicacao.DTOs;
using Fiap.BlazorCleanArch.Aplicacao.DTOs.Requests;
using Fiap.BlazorCleanArch.Aplicacao.DTOs.Responses;
using Fiap.BlazorCleanArch.Aplicacao.Servicos.Filtros;
using Fiap.BlazorCleanArch.Aplicacao.Servicos.Interfaces;
using Fiap.BlazorCleanArch.Dominio.Entidades;
using Fiap.BlazorCleanArch.Dominio.Modelos;
using Fiap.BlazorCleanArch.Infra.Repositorios;

namespace Fiap.BlazorCleanArch.Aplicacao.Servicos;

public class MusicasAppServico : IMusicasAppServico
{
    private readonly IMusicasRepositorio _musicasRepositorio;
    private readonly IMapper _mapper;

    public MusicasAppServico(IMusicasRepositorio musicasRepositorio, IMapper mapper)
    {
        _musicasRepositorio = musicasRepositorio;
        _mapper = mapper;
    }

    public async Task<PaginacaoConsulta<MusicaResponse>> ListarAsync(MusicaListarRequest request)
    {
        IQueryable<Musica> query = _musicasRepositorio.Query().Filtrar(request);

        return await _musicasRepositorio.ListarAsync<MusicaResponse>(query, request.Qt, request.Pg);
    }
}
