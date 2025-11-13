using AutoMapper;
using Fiap.BlazorCleanArch.Aplicacao.DTOs.Responses;
using Fiap.BlazorCleanArch.Aplicacao.Servicos.Interfaces;
using Fiap.BlazorCleanArch.Dominio.Interfaces;

namespace Fiap.BlazorCleanArch.Aplicacao.Servicos;

public class PlaylistsAppServico : IPlaylistsAppServico
{
    private readonly IPlaylistsRepositorio _playlistsRepositorio;
    private readonly IMapper _mapper;

    public PlaylistsAppServico(IPlaylistsRepositorio playlistsRepositorio,
                               IMapper mapper)
    {
        _playlistsRepositorio = playlistsRepositorio;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<PlaylistListarResponse>> ListarPlaylistsDoUsuarioAsync(string usuarioId)
    {
        var playlists = await _playlistsRepositorio.ListarTodosAsync(c => c.UsuarioId == usuarioId);
        return _mapper.Map<IReadOnlyList<PlaylistListarResponse>>(playlists);
    }
}
