using System.Security.Claims;

namespace MinimalAPI.Application.Utils.Token;

public interface ITokenController
{
    string GenerateToken(string userEmail, IList<string> roles);
    string GenerateToken(string userEmail);
    ClaimsPrincipal TokenValidate(string token);
    string GetEmailFromToken(string token);
}
