using Hangfire.Dashboard;

namespace OkyanusWebAPI.Hangfire.auth
{
    public class RoleBasedAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            //var httpContext = context.GetHttpContext();
            //var user = httpContext?.User;

            //// Kullanıcının doğrulanmış olup olmadığını ve Admin rolüne sahip olup olmadığını kontrol edin
            //return user?.Identity?.IsAuthenticated == true && user.IsInRole("Admin");
            return true;
        }
    }
}
