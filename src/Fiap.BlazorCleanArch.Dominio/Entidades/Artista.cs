using Fiap.BlazorCleanArch.Dominio.Entidades.Base;
using Fiap.BlazorCleanArch.Dominio.Enumeradores;
using Fiap.BlazorCleanArch.Dominio.Excecoes;

namespace Fiap.BlazorCleanArch.Dominio.Entidades;

public class Artista : Entity
{
    public string Nome { get; set; } = string.Empty;
    public GeneroMusicalArtistaEnum GeneroMusical { get; set; }
    public StatusArtistaEnum Status { get; set; }

    public Artista(){}

    public Artista(string nome, GeneroMusicalArtistaEnum genero)
    {
        SetNome(nome);
        SetGeneroMusical(genero);
        SetStatus(StatusArtistaEnum.Ativo);
    }

    public void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new AtributoObrigatorioExcecao(nameof(Nome));

        if (nome.Length > 50)
            throw new TamanhoDeAtributoInvalidoExcecao(nameof(Nome), 1, 50);

        Nome = nome;
    }

    public virtual void SetGeneroMusical(GeneroMusicalArtistaEnum generoMusical)
    {
        if (!Enum.IsDefined(generoMusical))
            throw new AtributoInvalidoExcecao(nameof(GeneroMusical));

        GeneroMusical = generoMusical;
    }

    public void SetStatus(StatusArtistaEnum status)
    {
        if (!Enum.IsDefined(status))
            throw new AtributoInvalidoExcecao(nameof(Status));

        Status = status;
    }
}


