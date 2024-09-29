using System.Security.Claims;

namespace TekhnelogosOkr.Business.Abstract
{
    public interface ITokenService
    {
        string GenerateToken(List<Claim> authClaims);
    }
}