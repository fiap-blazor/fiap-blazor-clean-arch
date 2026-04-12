namespace FIAP.Fiapfy.Aplicacao.DTOs.Responses;

public record MusicaResponse(int Id, string Nome, TimeSpan Duracao, string AlbumNome, string AlbumCapaUrl, string ArtistaNome);
