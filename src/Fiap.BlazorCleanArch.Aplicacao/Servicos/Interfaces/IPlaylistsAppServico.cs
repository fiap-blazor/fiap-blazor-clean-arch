using Fiap.BlazorCleanArch.Aplicacao.DTOs.Responses;

namespace Fiap.BlazorCleanArch.Aplicacao.Servicos.Interfaces
{
    public interface IPlaylistsAppServico
    {
        Task<IReadOnlyList<PlaylistListarResponse>> ListarPlaylistsDoUsuarioAsync(string usuarioId);
    }
}