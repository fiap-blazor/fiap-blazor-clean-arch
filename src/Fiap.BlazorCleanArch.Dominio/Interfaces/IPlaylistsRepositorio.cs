using Fiap.BlazorCleanArch.Dominio.Entidades;

namespace Fiap.BlazorCleanArch.Dominio.Interfaces;

public interface IPlaylistsRepositorio : IRepositorioBase<Playlist>
{
    Task<Playlist?> ObterPorIdAsync(int id);
}
