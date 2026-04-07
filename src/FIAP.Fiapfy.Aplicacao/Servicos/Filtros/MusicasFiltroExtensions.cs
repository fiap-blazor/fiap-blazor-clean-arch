using FIAP.Fiapfy.Aplicacao.DTOs;
using FIAP.Fiapfy.Dominio.Entidades;

namespace FIAP.Fiapfy.Aplicacao.Servicos.Filtros
{
    public static class MusicasFiltroExtensions
    {
        public static IQueryable<Musica> Filtrar(this IQueryable<Musica> query, MusicaListarRequest request)
        {
            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(m => m.Nome.ToLower().Contains(request.Nome.ToLower()));

            return query;
        }
    }
}
