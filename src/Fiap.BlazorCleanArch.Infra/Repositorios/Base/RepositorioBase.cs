using Fiap.BlazorCleanArch.Dominio.Entidades.Base;
using Fiap.BlazorCleanArch.Dominio.Interfaces;
using Fiap.BlazorCleanArch.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Fiap.BlazorCleanArch.Infra.Repositorios.Base;

public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : Entity, new()
{
    protected readonly ApplicationDbContext DbContext;
    protected readonly DbSet<T> DbSet;

    protected RepositorioBase(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<T>();
    }

    public virtual async Task<IReadOnlyList<T>> ListarTodosAsync(Expression<Func<T, bool>>? expression = null)
    {
        IQueryable<T> query = DbSet.AsQueryable();

        if (expression is not null)
            query = query.Where(expression);

        return await query.ToListAsync().ConfigureAwait(false);
    }

    public async Task InserirAsync(T entitidade)
    {
        await DbSet.AddAsync(entitidade);
    }

    public void Dispose()
    {
        DbContext?.Dispose();
    }
}
