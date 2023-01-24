using Microsoft.AspNetCore.Builder;

namespace ET.Caching.Memcached
{
    public static class MemcachedApplicationRegistration
    {
        public static IApplicationBuilder AddMemcachedApplications(this IApplicationBuilder app)
        {
            app.UseEnyimMemcached();
            return app;
        }
    }
}
