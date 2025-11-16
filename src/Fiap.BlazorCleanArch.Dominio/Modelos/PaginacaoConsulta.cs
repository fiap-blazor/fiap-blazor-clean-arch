namespace Fiap.BlazorCleanArch.Dominio.Modelos;

public class PaginacaoConsulta<T> where T : class
{
    public long Total { get; set; }
    public IReadOnlyList<T> Registros { get; set; } = [];
}
