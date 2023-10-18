using JobsApp.Domain.Entities.Base;

namespace JobsApp.Domain.Entities
{
    public class CompanyEntity : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Logo { get; set; }
        public string Location { get; set; }

        public ICollection<JobEntity> PublicatedJobs { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}