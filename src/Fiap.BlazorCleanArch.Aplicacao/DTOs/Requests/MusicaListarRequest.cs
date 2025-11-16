namespace Fiap.BlazorCleanArch.Aplicacao.DTOs.Requests;

public class MusicaListarRequest : PaginacaoFiltro
{
    public string Nome { get; set; } = string.Empty;
}
