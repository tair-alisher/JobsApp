using AutoMapper;
using JobsApp.BLL.DTO;
using JobsApp.WebApi.Models.Responses;

namespace JobsApp.WebApi
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<JobDto, JobShortResponse>();
            CreateMap<JobDto, JobFullResponse>();
        }
    }
}