using AutoMapper;
using Fiap.BlazorCleanArch.Dominio.Entidades;
using Fiap.BlazorCleanArch.Dominio.Interfaces;
using Fiap.BlazorCleanArch.Infra.Contexts;
using Fiap.BlazorCleanArch.Infra.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace Fiap.BlazorCleanArch.Infra.Repositorios;

public class PlaylistsRepositorio : RepositorioBase<Playlist>, IPlaylistsRepositorio
{
    public PlaylistsRepositorio(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

    public async Task<Playlist?> ObterPorIdAsync(int id)
    {
        return await DbContext.Playlists
            .Include(p => p.PlaylistMusicas)           // Carrega a tabela intermediária
                .ThenInclude(pm => pm.Musica)          // Carrega as Músicas
                    .ThenInclude(m => m.Album)         // Carrega o Álbum
                        .ThenInclude(a => a.Artista)   // Carrega o Artista
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
