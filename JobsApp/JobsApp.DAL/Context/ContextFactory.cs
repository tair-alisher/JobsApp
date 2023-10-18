using JobsApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobsApp.DAL.Context
{
    public class ContextFactory : IContextFactory
    {
        private readonly DbContextOptions<AppPgContext> _contextOptions;

        public ContextFactory(DbContextOptions<AppPgContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        public DbContext Create()
        {
            return new AppPgContext(_contextOptions);
        }
    }
}