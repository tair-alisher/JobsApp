using Microsoft.EntityFrameworkCore;

namespace JobsApp.DAL.Interfaces
{
    public interface IContextFactory
    {
        DbContext Create();
    }
}