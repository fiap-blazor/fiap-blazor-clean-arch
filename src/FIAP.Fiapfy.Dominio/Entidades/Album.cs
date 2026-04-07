using FIAP.Fiapfy.Dominio.Entidades.Base;

namespace FIAP.Fiapfy.Dominio.Entidades;

public class Album : Entity
{
    public string Nome { get; set; } = string.Empty;
    public string CapaUrl { get; set; } = string.Empty;
    public DateTime DataLancamento { get; set; }

    // FK explícita
    public int ArtistaId { get; set; }
    public Artista Artista { get; set; } = default!;

    protected Album() { }

    public Album(string nome, string capaUrl, DateTime dataLancamento, int artistaId)
    {
        Nome = nome;
        CapaUrl = capaUrl;
        DataLancamento = dataLancamento;
        ArtistaId = artistaId;
    }
}
