using Fiap.BlazorCleanArch.Aplicacao.DTOs;
using Fiap.BlazorCleanArch.Aplicacao.DTOs.Requests;
using Fiap.BlazorCleanArch.Aplicacao.DTOs.Responses;
using Fiap.BlazorCleanArch.Dominio.Modelos;

namespace Fiap.BlazorCleanArch.Aplicacao.Servicos.Interfaces
{
    public interface IMusicasAppServico
    {
        Task<PaginacaoConsulta<MusicaResponse>> ListarAsync(MusicaListarRequest request);
    }
}