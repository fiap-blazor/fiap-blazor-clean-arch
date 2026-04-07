using AutoMapper;
using FIAP.Fiapfy.Dominio.Entidades;
using FIAP.Fiapfy.Dominio.Interfaces;
using FIAP.Fiapfy.Infra.Repositorios.Base;
using FIAP.Fiapfy.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Fiapfy.Infra.Repositorios;

public class MusicasRepositorio : RepositorioBase<Musica>, IMusicasRepositorio
{
    public MusicasRepositorio(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<Musica?> ObterPorIdAsync(int id)
    {
        return await DbContext.Musicas         
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
