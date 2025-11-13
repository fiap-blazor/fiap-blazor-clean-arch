using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Fiap.BlazorCleanArch.WebApp.Servicos;

public interface IUsuarioAutenticadoServico
{
    Task<string> ObterIdUsuarioAsync();
    Task<string> ObterEmailUsuarioAsync();
    Task<string> ObterNomeUsuarioAsync();
    Task<bool> EstaAutenticadoAsync();
    Task<ClaimsPrincipal> ObterUsuarioAsync();
}

public class UsuarioAutenticadoServico : IUsuarioAutenticadoServico
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public UsuarioAutenticadoServico(AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<string> ObterIdUsuarioAsync()
    {
        var user = await ObterUsuarioAsync();

        // Tenta obter o ID do usuário de diferentes claims comuns
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? user.FindFirst("sub")?.Value
            ?? user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

        if (string.IsNullOrEmpty(userId))
            throw new InvalidOperationException("ID do usuário não encontrado nas claims.");

        return userId;
    }

    public async Task<string> ObterEmailUsuarioAsync()
    {
        var user = await ObterUsuarioAsync();

        var email = user.FindFirst(ClaimTypes.Email)?.Value
            ?? user.FindFirst("email")?.Value;

        if (string.IsNullOrEmpty(email))
            throw new InvalidOperationException("Email do usuário não encontrado nas claims.");

        return email;
    }

    public async Task<string> ObterNomeUsuarioAsync()
    {
        var user = await ObterUsuarioAsync();

        if (string.IsNullOrEmpty(user.Identity?.Name))
            throw new InvalidOperationException("Nome do usuário não encontrado.");

        return user.Identity.Name;
    }

    public async Task<bool> EstaAutenticadoAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        return authState.User?.Identity?.IsAuthenticated ?? false;
    }

    public async Task<ClaimsPrincipal> ObterUsuarioAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user?.Identity?.IsAuthenticated != true)
            throw new UnauthorizedAccessException("Usuário não está autenticado.");

        return user;
    }
}