using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace OkyanusHangfire.Hangfire.auth
{
    public class HangfireAuthorization : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            //var httpContext = context.GetHttpContext();
            //var user = httpContext?.User;

            //// Kullanıcının doğrulanmış olup olmadığını ve Admin rolüne sahip olup olmadığını kontrol edin
            //return user?.Identity?.IsAuthenticated == true && user.IsInRole("Admin");
            return true;
        }
    }
}
