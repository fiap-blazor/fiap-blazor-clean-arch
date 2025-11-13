using Fiap.BlazorCleanArch.Dominio.Entidades.Base;
using System.Linq.Expressions;

namespace Fiap.BlazorCleanArch.Dominio.Interfaces;

public interface IRepositorioBase<T> : IDisposable where T : Entity
{
    Task InserirAsync(T entitidade);
    Task<IReadOnlyList<T>> ListarTodosAsync(Expression<Func<T, bool>>? expression = null);
}
