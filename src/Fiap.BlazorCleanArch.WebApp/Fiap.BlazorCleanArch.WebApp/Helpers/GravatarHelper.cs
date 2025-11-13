using System.Security.Cryptography;
using System.Text;

namespace Fiap.BlazorCleanArch.WebApp.Helpers;

public static class GravatarHelper
{
    public static string ObterGravatarUrl(string email, int size = 80, string defaultImage = "mp")
    {
        if (string.IsNullOrWhiteSpace(email))
            return $"https://www.gravatar.com/avatar/?d={defaultImage}&s={size}";

        var emailLower = email.Trim().ToLowerInvariant();

        var hash = MD5.HashData(Encoding.UTF8.GetBytes(emailLower));
        var hashString = Convert.ToHexStringLower(hash);

        return $"https://www.gravatar.com/avatar/{hashString}?d={defaultImage}&s={size}";
    }
}
