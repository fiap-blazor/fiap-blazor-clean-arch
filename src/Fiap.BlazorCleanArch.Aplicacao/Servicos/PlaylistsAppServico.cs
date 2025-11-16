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

    public async Task<PlaylistResponse?> ObterPorIdAsync(int id)
    {
        var playlist = await _playlistsRepositorio.ObterPorIdAsync(id);
        if (playlist == null)
            return null;

        return _mapper.Map<PlaylistResponse>(playlist);
    }

    public async Task<int> InserirAsync(PlaylistInserirRequest request, string usuarioId)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var playlist = new Playlist(request.Nome, request.Descricao, usuarioId);

            await _playlistsRepositorio.InserirAsync(playlist);

            await _unitOfWork.CommitAsync();

            return playlist.Id;
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task AdicionarMusicaAsync(int playlistId, int musicaId)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var playlist = await _playlistsRepositorio.ObterPorIdEditarAsync(playlistId);

            if(playlist is null)
                throw new Exception("Playlist não encontrada.");            

            playlist.AdicionarMusica(musicaId);

            await _playlistsRepositorio.AtualizarAsync(playlist);

            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task RemoverMusicaAsync(int playlistId, int musicaId)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var playlist = await _playlistsRepositorio.ObterPorIdEditarAsync(playlistId);

            if (playlist is null)
                throw new Exception("Playlist não encontrada.");

            playlist.RemoverMusica(musicaId);

            await _playlistsRepositorio.AtualizarAsync(playlist);

            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}
