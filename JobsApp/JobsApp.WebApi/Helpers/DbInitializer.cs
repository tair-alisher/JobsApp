using JobsApp.DAL.Context;
using JobsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobsApp.WebApi.Helpers
{
    public static class DbInitializer
    {
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                using (AppPgContext ctx = scope.ServiceProvider.GetRequiredService<AppPgContext>())
                {
                    ctx.Database.Migrate();
                }
            }

            return app;
        }

        public static WebApplication InitialData(this WebApplication app)
        {
            using (IServiceScope scope = app.Services.CreateScope())
            {
                using (var ctx = scope.ServiceProvider.GetRequiredService<AppPgContext>())
                {
                    var isJobTableEmpty = ctx.Jobs.Count() == 0;

                    if (!isJobTableEmpty) return app;

                    List<JobEntity> jobs = new List<JobEntity>()
                    {
                        new JobEntity
                    }
                }
            }
        }
    }
}