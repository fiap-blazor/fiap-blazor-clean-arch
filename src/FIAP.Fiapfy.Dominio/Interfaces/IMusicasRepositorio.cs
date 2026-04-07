using FIAP.Fiapfy.Dominio.Entidades;

namespace FIAP.Fiapfy.Dominio.Interfaces;

public interface IMusicasRepositorio : IRepositorioBase<Musica>
{
    Task<Musica?> ObterPorIdAsync(int id);
}
