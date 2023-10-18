using JobsApp.Domain.Entities.Base;

namespace JobsApp.Domain.Entities
{
    public class TagEntity : BaseEntity<int>
    {
        public string Title { get; set; }

        public List<JobEntity> Jobs { get; } = new();
        public List<JobTagEntity> JobTags { get; } = new();
    }
}