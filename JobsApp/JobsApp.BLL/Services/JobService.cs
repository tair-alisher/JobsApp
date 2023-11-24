using AutoMapper;
using JobsApp.BLL.DTO;
using JobsApp.BLL.Interfaces;
using JobsApp.DAL.Interfaces;
using JobsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobsApp.BLL.Services
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly IMapper _mapper;

        public JobService(IUnitOfWorkFactory uowFactory, IMapper mapper)
        {
            _uowFactory = uowFactory;
            _mapper = mapper;
        }

        public async Task<JobDto> Get(int id)
        {
            using (var uow = _uowFactory.Create())
            {
                var entity = await uow.GetRepository<JobEntity>()
                    .All()
                    .Where(x => x.Id == id)
                    .Include(x => x.Company)
                    .Include(x => x.Tags)
                    .FirstOrDefaultAsync();

                return _mapper.Map<JobDto>(entity);
            }
        }

        public async Task<List<JobDto>> GetFeaturedJobsAsync(int jobsAmount)
        {
            using (var uow = _uowFactory.Create())
            {
                var entities = await uow.GetRepository<JobEntity>()
                    .All()
                    .Include(x => x.Company)
                    .Include(x => x.Tags)
                    .Where(x => !x.IsDeleted && !x.IsClosed && x.IsPinned)
                    .OrderBy(x => x.CreatedAt)
                    .Take(jobsAmount)
                    .AsNoTracking()
                    .ToListAsync();

                return _mapper.Map<List<JobDto>>(entities);
            }
        }

        public async Task<List<JobDto>> GetRecentJobsAsync(int page, int pageSize)
        {
            using (var uow = _uowFactory.Create())
            {
                var entities = await uow.GetRepository<JobEntity>()
                    .All()
                    .Include(x => x.Company)
                    .Include(x => x.Tags)
                    .Where(x => !x.IsDeleted && !x.IsClosed)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .OrderByDescending(x => x.CreatedAt)
                    .AsNoTracking()
                    .ToListAsync();

                return _mapper.Map<List<JobDto>>(entities);
            }
        }
    }
}