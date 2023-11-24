using JobsApp.BLL.DTO;

namespace JobsApp.BLL.Interfaces
{
    public interface IJobService
    {
        Task<JobDto> Get(int id);

        Task<List<JobDto>> GetFeaturedJobsAsync(int jobsAmount);

        Task<List<JobDto>> GetRecentJobsAsync(int page, int pageSize);
    }
}