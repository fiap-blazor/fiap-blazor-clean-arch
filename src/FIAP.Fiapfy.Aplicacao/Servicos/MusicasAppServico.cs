using AutoMapper;
using FIAP.Fiapfy.Aplicacao.DTOs;
using FIAP.Fiapfy.Aplicacao.DTOs.Responses;
using FIAP.Fiapfy.Aplicacao.Servicos.Filtros;
using FIAP.Fiapfy.Aplicacao.Servicos.Interfaces;
using FIAP.Fiapfy.Dominio.Entidades;
using FIAP.Fiapfy.Dominio.Interfaces;
using FIAP.Fiapfy.Dominio.Modelos;

namespace FIAP.Fiapfy.Aplicacao.Servicos;

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
