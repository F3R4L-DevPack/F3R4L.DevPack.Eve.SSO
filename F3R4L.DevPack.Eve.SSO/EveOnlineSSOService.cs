using F3R4L.DevPack.SSO.Models;
using F3R4L.DevPack.SSO.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F3R4L.DevPack.Eve.SSO
{
    public class EveOnlineSSOService : IEveOnlineSSOService
    {
        private readonly ISingleSignOnService _singleSignOnService;

        private const string _eveLoginUrlFormat = "https://login.eveonline.com/oauth/{0}";
        private const string _hostName = "login.eveonline.com";
        private const string _tokenRefreshUrlExtension = "token";

        public EveOnlineSSOService(ISingleSignOnService singleSignOnService)
        {
            _singleSignOnService = singleSignOnService;
        }

        public string SignOnRedirectUrl(string redirectURI, string clientId, IEnumerable<string> scopes)
        {
            return _singleSignOnService.SignOnRedirectUrl(redirectURI, clientId, scopes, _eveLoginUrlFormat);
        }

        public async Task<TokenResponse> GetTokensFromRefreshTokenAsync(string clientId, string applicationKey, string refreshToken)
        {
            return await _singleSignOnService.GetTokensFromRefreshTokenAsync(clientId, applicationKey, refreshToken, string.Format(_eveLoginUrlFormat, _tokenRefreshUrlExtension), _hostName);
        }

        public string GetRefreshTokenFromReturnUri(Uri requestUri)
        {
            return _singleSignOnService.GetRefreshTokenFromReturnUri(requestUri);
        }
    }}