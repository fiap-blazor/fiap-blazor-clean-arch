namespace FIAP.Fiapfy.Aplicacao.DTOs;

public class MusicaListarRequest : PaginacaoFiltro
{
    public string Nome { get; set; } = string.Empty;
}
