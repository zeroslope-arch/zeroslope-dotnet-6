using System.Security.Claims;

namespace ZeroSlope.Domain.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, string emailAddress);
        string BuildTokenWithClaims(string key, string issuer, Claim[] claims);
    }
}
