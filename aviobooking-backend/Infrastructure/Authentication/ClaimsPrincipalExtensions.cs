using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain.Entities;

namespace Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
{
    public static StronglyTypedId<User> GetUserId(this ClaimsPrincipal? principal)
    {
        string? userId = principal?.FindFirstValue(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub);

        return StronglyTypedId<User>.TryParse(userId, out StronglyTypedId<User> parsedUserId) ?
            parsedUserId :
            throw new ApplicationException("User id is unavailable");
    }
}
