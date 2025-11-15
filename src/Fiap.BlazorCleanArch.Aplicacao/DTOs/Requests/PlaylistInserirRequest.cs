using System.ComponentModel.DataAnnotations;

namespace Fiap.BlazorCleanArch.Aplicacao.DTOs.Requests;

public class PlaylistInserirRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [StringLength(255, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    public string Descricao { get; set; } = string.Empty;
}
