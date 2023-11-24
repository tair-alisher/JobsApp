using JobsApp.BLL.DTO;
using JobsApp.Domain.Enums;

namespace JobsApp.WebApi.Models.Responses
{
    public class JobShortResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }

        public EmploymentTimeType TimeType { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public SalaryType SalaryType { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<TagDto> Tags { get; set; }

        public CompanyDto Company { get; set; }
    }
}