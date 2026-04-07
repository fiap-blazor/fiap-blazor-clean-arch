using AutoMapper;
using FIAP.Fiapfy.Dominio.Entidades;
using FIAP.Fiapfy.Dominio.Interfaces;
using FIAP.Fiapfy.Infra.Repositorios.Base;
using FIAP.Fiapfy.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Fiapfy.Infra.Repositorios;

public class PlaylistsRepositorio : RepositorioBase<Playlist>, IPlaylistsRepositorio
{
    public PlaylistsRepositorio(ApplicationDbContext dbContext, 
                                IMapper mapper) : base(dbContext, mapper) { }

    public async Task<Playlist?> ObterPorIdAsync(int id)
    {
        return await DbContext.Playlists
            .Include(p => p.PlaylistMusicas)           // Carrega a tabela intermediária
                .ThenInclude(pm => pm.Musica)          // Carrega as Músicas
                    .ThenInclude(m => m.Album)         // Carrega o Álbum
                        .ThenInclude(a => a.Artista)   // Carrega o Artista
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
