using Humanizer;

namespace Fiap.BlazorCleanArch.Aplicacao.DTOs.Responses;

public record PlaylistMusicaResponse(DateTime DataAdicao, MusicaResponse Musica)
{
    public string DataAdicaoHumanizada => DataAdicao.Humanize(culture: new System.Globalization.CultureInfo("pt-BR"));
}