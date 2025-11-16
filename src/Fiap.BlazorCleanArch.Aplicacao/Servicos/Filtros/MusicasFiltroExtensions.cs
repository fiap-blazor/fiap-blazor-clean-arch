using Fiap.BlazorCleanArch.Aplicacao.DTOs.Requests;
using Fiap.BlazorCleanArch.Dominio.Entidades;

namespace Fiap.BlazorCleanArch.Aplicacao.Servicos.Filtros;

public static class MusicasFiltroExtensions
{
    public static IQueryable<Musica> Filtrar(this IQueryable<Musica> query, MusicaListarRequest request)
    {
        if (!string.IsNullOrEmpty(request.Nome))
            query = query.Where(m => m.Nome.ToLower().Contains(request.Nome.ToLower()));

        return query;
    }
}
