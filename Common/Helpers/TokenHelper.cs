using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Common.Helpers
{
    public static class TokenHelper
    {
        public static string GetClaimValue(string token, string claim)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            string authHeader = token.Replace("Bearer ", "").Replace("bearer ", "");
            JwtSecurityToken? tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

            if (tokenS == null) throw new UnauthorizedAccessException("Invalid token.");

            Claim? claimData = tokenS.Claims.FirstOrDefault(cl => cl.Type.ToUpper() == claim.ToUpper());

            if (claimData == null || string.IsNullOrEmpty(claimData.Value))
                throw new UnauthorizedAccessException("Claim not found or empty.");

            return claimData.Value;
        }
    }
}
