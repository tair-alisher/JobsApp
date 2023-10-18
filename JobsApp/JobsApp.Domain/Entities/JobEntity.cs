using JobsApp.Domain.Entities.Base;
using JobsApp.Domain.Enums;

namespace JobsApp.Domain.Entities
{
    public class JobEntity : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
        public EmploymentTimeType TimeType { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public SalaryType SalaryType { get; set; }
        public bool IsClosed { get; set; }

        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; }

        public List<TagEntity> Tags { get; } = new();
        public List<JobTagEntity> JobTags { get; } = new();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}