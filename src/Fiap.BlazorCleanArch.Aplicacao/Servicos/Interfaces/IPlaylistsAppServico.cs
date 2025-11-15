using Fiap.BlazorCleanArch.Aplicacao.DTOs.Requests;
using Fiap.BlazorCleanArch.Aplicacao.DTOs.Responses;

namespace Fiap.BlazorCleanArch.Aplicacao.Servicos.Interfaces
{
    public interface IPlaylistsAppServico
    {
        Task<int> InserirAsync(PlaylistInserirRequest request, string usuarioId);
        Task<IReadOnlyList<PlaylistListarResponse>> ListarPlaylistsDoUsuarioAsync(string usuarioId);
        Task<PlaylistResponse?> ObterPorIdAsync(int id);
    }
}