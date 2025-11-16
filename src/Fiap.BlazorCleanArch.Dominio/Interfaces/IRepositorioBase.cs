using Fiap.BlazorCleanArch.Dominio.Entidades.Base;
using Fiap.BlazorCleanArch.Dominio.Modelos;
using System.Linq.Expressions;

namespace Fiap.BlazorCleanArch.Dominio.Interfaces;

public interface IRepositorioBase<T> : IDisposable where T : Entity
{
    Task AtualizarAsync(T entidade);
    Task InserirAsync(T entitidade);
    Task<PaginacaoConsulta<TModel>> ListarAsync<TModel>(IQueryable<T> query, int qt, int pg) where TModel : class;
    Task<IReadOnlyList<T>> ListarTodosAsync(Expression<Func<T, bool>>? expression = null);
    IQueryable<T> Query();
}
