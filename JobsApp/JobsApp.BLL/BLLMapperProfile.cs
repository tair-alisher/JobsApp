using AutoMapper;
using JobsApp.BLL.DTO;
using JobsApp.Domain.Entities;

namespace JobsApp.BLL
{
    public class BLLMapperProfile : Profile
    {
        public BLLMapperProfile()
        {
            CreateMap<JobEntity, JobDto>();
        }
    }
}