using FIAP.Fiapfy.Aplicacao.DTOs;
using FIAP.Fiapfy.Aplicacao.DTOs.Responses;
using FIAP.Fiapfy.Dominio.Modelos;

namespace FIAP.Fiapfy.Aplicacao.Servicos.Interfaces
{
    public interface IMusicasAppServico
    {
        Task<PaginacaoConsulta<MusicaResponse>> ListarAsync(MusicaListarRequest request);
    }
}