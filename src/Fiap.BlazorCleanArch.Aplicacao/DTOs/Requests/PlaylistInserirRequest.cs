namespace Fiap.BlazorCleanArch.Aplicacao.DTOs.Requests;

public class PlaylistInserirRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Publica { get; set; } = true;
    public string? ImagemUrl { get; set; }
}
