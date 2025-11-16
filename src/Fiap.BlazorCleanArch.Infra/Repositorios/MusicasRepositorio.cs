using AutoMapper;
using Fiap.BlazorCleanArch.Dominio.Entidades;
using Fiap.BlazorCleanArch.Infra.Contexts;
using Fiap.BlazorCleanArch.Infra.Repositorios.Base;

namespace Fiap.BlazorCleanArch.Infra.Repositorios;

public class MusicasRepositorio : RepositorioBase<Musica>, IMusicasRepositorio
{
    public MusicasRepositorio(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
