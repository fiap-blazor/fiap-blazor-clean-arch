using AutoMapper;
using AutoMapper.QueryableExtensions;
using Fiap.BlazorCleanArch.Dominio.Entidades.Base;
using Fiap.BlazorCleanArch.Dominio.Interfaces;
using Fiap.BlazorCleanArch.Dominio.Modelos;
using Fiap.BlazorCleanArch.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Fiap.BlazorCleanArch.Infra.Repositorios.Base;

public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : Entity, new()
{
    protected readonly ApplicationDbContext DbContext;
    protected readonly DbSet<T> DbSet;
    private readonly IMapper _mapper;

    protected RepositorioBase(ApplicationDbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<T>();
        _mapper = mapper;
    }

    public virtual IQueryable<T> Query()
    {
        return DbSet.AsNoTracking();
    }

    public virtual async Task<PaginacaoConsulta<TModel>> ListarAsync<TModel>(IQueryable<T> query, int qt, int pg)
        where TModel : class
    {
        PaginacaoConsulta<TModel> paginacaoConsulta = new()
        {
            Total = await query.LongCountAsync(),
            Registros = await query
                .Skip((pg - 1) * qt)
                .Take(qt)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync()
                .ConfigureAwait(false)
        };

        return paginacaoConsulta;
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
