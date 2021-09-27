using F3R4L.DevPack.SSO.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F3R4L.DevPack.Eve.SSO
{
    public interface IEveOnlineSSOService
    {
        string GetRefreshTokenFromReturnUri(Uri requestUri);
        Task<TokenResponse> GetTokensFromRefreshTokenAsync(string clientId, string applicationKey, string refreshToken);
        string SignOnRedirectUrl(string redirectURI, string clientId, IEnumerable<string> scopes);
    }
}