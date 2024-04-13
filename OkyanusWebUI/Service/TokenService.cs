using System.Data;
using System.Security.Claims;

namespace OkyanusWebUI.Service
{
    public class TokenService
    {

        private const string TokenKey = "Token";
        private const string TokenExpiresKey = "TokenExpires";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetToken(string token, string expires)
        {
            _httpContextAccessor?.HttpContext?.Session.SetString(TokenKey, token);
            _httpContextAccessor?.HttpContext?.Session.SetString(TokenExpiresKey, expires);
        }

        public string? GetToken()
        {
            return _httpContextAccessor?.HttpContext?.Session.GetString(TokenKey);
        }

        public string? GetTokenExpires()
        {
            return _httpContextAccessor?.HttpContext?.Session.GetString(TokenExpiresKey);
        }

        public void ClearToken()
        {
            _httpContextAccessor?.HttpContext?.Session.Remove(TokenKey);
            _httpContextAccessor?.HttpContext?.Session.Remove(TokenExpiresKey);
        }

        public bool IsAuthonticate()
        {
            return _httpContextAccessor?.HttpContext?.Session.GetString(TokenKey) != null;
        }

        public bool IsAuthonticateAdmin()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            foreach (var claim in user.Claims)
            {
                if (claim.Type == ClaimTypes.Role)
                {
                    var role = claim.Value;
                    Console.WriteLine(role);
                }
            }
            return _httpContextAccessor?.HttpContext?.User.IsInRole("Admin") ?? false;
        }


        //private readonly IHttpContextAccessor _httpContextAccessor;
        //public TokenService(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}

        //public void SetToken(string token, string expires)
        //{
        //    _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", token, new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Secure = true,
        //        SameSite = SameSiteMode.Strict,
        //        Expires = DateTime.Parse(expires)
        //    });

        //    _httpContextAccessor.HttpContext.Response.Cookies.Append("TokenExpires", expires, new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Secure = true,
        //        SameSite = SameSiteMode.Strict,
        //        Expires = DateTime.Parse(expires)
        //    });
        //}

        //public string GetToken()
        //{
        //    return _httpContextAccessor.HttpContext.Request.Cookies["Token"];
        //}

        //public string GetTokenExpires()
        //{
        //    return _httpContextAccessor.HttpContext.Request.Cookies["TokenExpires"];
        //}

        //public void ClearToken()
        //{
        //    _httpContextAccessor.HttpContext.Response.Cookies.Delete("Token");
        //    _httpContextAccessor.HttpContext.Response.Cookies.Delete("TokenExpires");
        //}


    }
}
