using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Management.WebUI.States
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal anonymous = new(new ClaimsIdentity());

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(Constants.JWTToken))
                    return await Task.FromResult(new AuthenticationState(anonymous));

                var getUserClaims = DecryptToken(Constants.JWTToken);
                if (getUserClaims == null) return await Task.FromResult(new AuthenticationState(anonymous));

                var claimsPrincipal = SetClaimPrincipal(getUserClaims);
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {
                return await Task.FromResult(new AuthenticationState(anonymous));
            }
        }

        public async void UpdateAuthenticationState(string jwtToken)
        {
            var claimsPrincipal = new ClaimsPrincipal();
            if (!string.IsNullOrEmpty(jwtToken) && !IsTokenExpired(jwtToken))
            {
                Constants.JWTToken = jwtToken;
                var getUserClaims = DecryptToken(jwtToken);
                claimsPrincipal = SetClaimPrincipal(getUserClaims);
            }
            else
            {
                Constants.JWTToken = null!;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        private static ClaimsPrincipal SetClaimPrincipal(CustomUserClaims claims)
        {
            if (claims.Email is null) return new ClaimsPrincipal();

            return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new(ClaimTypes.Name, claims.Name!),
                new(ClaimTypes.NameIdentifier, claims.UserId!),
                new(ClaimTypes.Email, claims.Email!),
            }, "JwtAuth"));
        }

        private static CustomUserClaims DecryptToken(string jwtToken)
        {
            if (string.IsNullOrEmpty(jwtToken)) return new CustomUserClaims();

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            var name = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Name);
            var id = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier);
            var email = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Email);
            var validate = token.ValidTo > DateTime.UtcNow;

            if (!validate)
            {
                return new CustomUserClaims();
            }

            return new CustomUserClaims(name!.Value, email!.Value, id!.Value);
        }

        private static bool IsTokenExpired(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);
            return token.ValidTo < DateTime.UtcNow;
        }
    }
}
