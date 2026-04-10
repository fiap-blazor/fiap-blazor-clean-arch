using FIAP.Fiapfy.Aplicacao.Servicos;
using FIAP.Fiapfy.Aplicacao.Servicos.Interfaces;
using FIAP.Fiapfy.Dominio.Interfaces;
using FIAP.Fiapfy.Infra;
using FIAP.Fiapfy.Infra.Repositorios;
using FIAP.Fiapfy.WebApp.Servicos;

namespace FIAP.Fiapfy.WebApp.Configuracoes;

public static class InjecaoDependenciaConfig
{
    public static void RegistrarServicos(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(typeof(PlaylistsAppServico).Assembly);
        services.AddScoped<IUsuarioAutenticadoServico, UsuarioAutenticadoServico>();

        services.AddScoped<IPlaylistsAppServico, PlaylistsAppServico>();
        services.AddScoped<IPlaylistsRepositorio, PlaylistsRepositorio>();

        services.AddScoped<IMusicasRepositorio, MusicasRepositorio>();
        services.AddScoped<IMusicasAppServico, MusicasAppServico>();
    }
}
