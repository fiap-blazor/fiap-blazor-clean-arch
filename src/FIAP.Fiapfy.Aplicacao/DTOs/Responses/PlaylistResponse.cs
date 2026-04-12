namespace FIAP.Fiapfy.Aplicacao.DTOs.Responses;

public record PlaylistResponse(int Id, string Nome, string Descricao, string UsuarioId, IList<PlaylistMusicaResponse> PlaylistMusicas);

