using FIAP.Fiapfy.Dominio.Entidades.Base;
using FIAP.Fiapfy.Dominio.Enumeradores;

namespace FIAP.Fiapfy.Dominio.Entidades;

public class Artista : Entity
{
    public string Nome { get; protected set; } = string.Empty;
    public GeneroMusicalArtistaEnum GeneroMusical { get; protected set; }
    public StatusArtistaEnum Status { get; protected set; }

    protected Artista() { }

    public Artista(string nome, GeneroMusicalArtistaEnum generoMusical)
    {
        Nome = nome;
        GeneroMusical = generoMusical;
        Status = StatusArtistaEnum.Ativo;

        Validar();
    }


    public void Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
            throw new ArgumentException("O nome do artista é obrigatório.");
        if (!Enum.IsDefined(typeof(GeneroMusicalArtistaEnum), GeneroMusical))
            throw new ArgumentException("Gênero musical do artista inválido.");
    }

}
