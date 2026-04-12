using AutoMapper;
using FIAP.Fiapfy.Aplicacao.DTOs.Requests;
using FIAP.Fiapfy.Aplicacao.DTOs.Responses;
using FIAP.Fiapfy.Aplicacao.Servicos.Interfaces;
using FIAP.Fiapfy.Dominio.Entidades;
using FIAP.Fiapfy.Dominio.Interfaces;

namespace FIAP.Fiapfy.Aplicacao.Servicos;

public class PlaylistsAppServico : IPlaylistsAppServico
{
    private readonly IPlaylistsRepositorio _playlistsRepositorio;
    private readonly IMusicasRepositorio _musicasRepositorio;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PlaylistsAppServico(IPlaylistsRepositorio playlistsRepositorio,
                               IMusicasRepositorio musicasRepositorio,
                               IMapper mapper,
                               IUnitOfWork unitOfWork)
    {
        _playlistsRepositorio = playlistsRepositorio;
        _musicasRepositorio = musicasRepositorio;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<PlaylistResponse?> ObterPorIdAsync(int id)
    {
        var playlist = await _playlistsRepositorio.ObterPorIdAsync(id);
        if (playlist is null)
            return null;

        return _mapper.Map<PlaylistResponse>(playlist);
    }

    public async Task<IReadOnlyList<PlaylistListarResponse>> ListarPorUsuarioAsync(string usuarioId)
    {
        var playlists = await _playlistsRepositorio.ListarTodosAsync(c => c.UsuarioId == usuarioId);
        return _mapper.Map<IReadOnlyList<PlaylistListarResponse>>(playlists);
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

            var playlist = await _playlistsRepositorio.ObterPorIdAsync(playlistId)
            ?? throw new Exception("Playlist não encontrada");

            var musica = await _musicasRepositorio.ObterPorIdAsync(musicaId)
                ?? throw new Exception("Playlist não encontrada");

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

            var playlist = await _playlistsRepositorio.ObterPorIdAsync(playlistId)
            ?? throw new Exception("Playlist não encontrada");

            var musica = await _musicasRepositorio.ObterPorIdAsync(musicaId)
                ?? throw new Exception("Playlist não encontrada");

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
