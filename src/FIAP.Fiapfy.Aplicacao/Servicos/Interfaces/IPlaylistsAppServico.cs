using FIAP.Fiapfy.Aplicacao.DTOs.Requests;
using FIAP.Fiapfy.Aplicacao.DTOs.Responses;

namespace FIAP.Fiapfy.Aplicacao.Servicos.Interfaces;

public interface IPlaylistsAppServico
{
    Task AdicionarMusicaAsync(int playlistId, int musicaId);
    Task<int> InserirAsync(PlaylistInserirRequest request, string usuarioId);
    Task<IReadOnlyList<PlaylistListarResponse>> ListarPorUsuarioAsync(string usuarioId);
    Task<PlaylistResponse?> ObterPorIdAsync(int id);
    Task RemoverMusicaAsync(int playlistId, int musicaId);
}