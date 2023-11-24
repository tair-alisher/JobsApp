using AutoMapper;
using JobsApp.BLL.DTO;
using JobsApp.BLL.Interfaces;
using JobsApp.WebApi.Models;
using JobsApp.WebApi.Models.Requests;
using JobsApp.WebApi.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace JobsApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JobsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJobService _jobService;
        private readonly IMemoryCache _cache;

        public JobsController(IMapper mapper, IJobService jobService, IMemoryCache cache)
        {
            _mapper = mapper;
            _jobService = jobService;
            _cache = cache;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ResponseModel<JobFullResponse>> Get(JobDetailRequest request)
        {
            var job = await _jobService.Get(request.Id);

            return ResponseModel<JobFullResponse>.Success(_mapper.Map<JobFullResponse>(job));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ResponseModel<List<JobShortResponse>>> FeaturedJobs(FeaturedJobsRequest request)
        {
            if (!_cache.TryGetValue(WebApiConstants.FeaturedJobsCacheKey, out List<JobDto> featuredJobs))
            {
                featuredJobs = await _jobService.GetFeaturedJobsAsync(request.JobsNumber);

                _cache.Set(WebApiConstants.FeaturedJobsCacheKey, featuredJobs, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30),
                    Priority = CacheItemPriority.Normal,
                    SlidingExpiration = TimeSpan.FromMinutes(30)
                });
            }

            return ResponseModel<List<JobShortResponse>>.Success(_mapper.Map<List<JobShortResponse>>(featuredJobs));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ResponseModel<List<JobShortResponse>>> RecentJobs(PagedRequest request)
        {
            if (!_cache.TryGetValue(WebApiConstants.RecentJobsCacheKey, out List<JobDto> recentJobs))
            {
                recentJobs = await _jobService.GetRecentJobsAsync(request.Page, request.PageSize);

                _cache.Set(WebApiConstants.RecentJobsCacheKey, recentJobs, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10),
                    Priority = CacheItemPriority.Normal,
                    SlidingExpiration = TimeSpan.FromMinutes(10)
                });
            }

            return ResponseModel<List<JobShortResponse>>.Success(_mapper.Map<List<JobShortResponse>>(recentJobs));
        }
    }
}