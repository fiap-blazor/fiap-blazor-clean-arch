namespace Fiap.BlazorCleanArch.Aplicacao.DTOs;

public abstract class PaginacaoFiltro
{
    public int Qt { get; set; } = 10;
    public int Pg { get; set; } = 1;
}
