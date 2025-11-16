namespace Fiap.BlazorCleanArch.Aplicacao.DTOs.Responses;

public record PlaylistResponse(int Id, string Nome, string Descricao, IList<PlaylistMusicaResponse> PlaylistMusicas);
