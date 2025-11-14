using AutoMapper;
using Fiap.BlazorCleanArch.Aplicacao.DTOs.Requests;
using Fiap.BlazorCleanArch.Aplicacao.DTOs.Responses;
using Fiap.BlazorCleanArch.Aplicacao.Servicos.Interfaces;
using Fiap.BlazorCleanArch.Dominio.Entidades;
using Fiap.BlazorCleanArch.Dominio.Interfaces;

namespace Fiap.BlazorCleanArch.Aplicacao.Servicos;

public class PlaylistsAppServico : IPlaylistsAppServico
{
    private readonly IPlaylistsRepositorio _playlistsRepositorio;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PlaylistsAppServico(IPlaylistsRepositorio playlistsRepositorio,
                               IMapper mapper,
                               IUnitOfWork unitOfWork)
    {
        _playlistsRepositorio = playlistsRepositorio;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<PlaylistListarResponse>> ListarPlaylistsDoUsuarioAsync(string usuarioId)
    {
        var playlists = await _playlistsRepositorio.ListarTodosAsync(c => c.UsuarioId == usuarioId);
        return _mapper.Map<IReadOnlyList<PlaylistListarResponse>>(playlists);
    }

    public async Task InserirAsync(PlaylistInserirRequest request, string usuarioId)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var playlist = new Playlist(request.Nome, request.Descricao, usuarioId);

            await _playlistsRepositorio.InserirAsync(playlist);

            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}
