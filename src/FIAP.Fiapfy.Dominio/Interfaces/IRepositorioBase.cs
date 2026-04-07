using FIAP.Fiapfy.Dominio.Entidades.Base;
using FIAP.Fiapfy.Dominio.Modelos;
using System.Linq.Expressions;

namespace FIAP.Fiapfy.Dominio.Interfaces;

public interface IRepositorioBase<T> : IDisposable where T : Entity
{
    Task InserirAsync(T entitidade);
    Task AtualizarAsync(T entidade);
    Task<PaginacaoConsulta<TModel>> ListarAsync<TModel>(IQueryable<T> query, int qt, int pg) where TModel : class;
    Task<IReadOnlyList<T>> ListarTodosAsync(Expression<Func<T, bool>>? expression = null);
    IQueryable<T> Query();
}
