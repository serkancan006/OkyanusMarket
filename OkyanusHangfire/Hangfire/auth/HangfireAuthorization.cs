using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace OkyanusHangfire.Hangfire.auth
{
    public class HangfireAuthorization : IDashboardAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HangfireAuthorization(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool Authorize([NotNull] DashboardContext context)
        {
            // return true;
            var httpContext = _httpContextAccessor.HttpContext;
            var user = httpContext?.Session.GetString("HangfireUser");

            // Kullanıcı giriş yapmış mı kontrol et
            return !string.IsNullOrEmpty(user);
        }
    }
}
