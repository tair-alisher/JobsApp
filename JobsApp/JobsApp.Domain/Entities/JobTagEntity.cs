using JobsApp.Domain.Entities.Base;

namespace JobsApp.Domain.Entities
{
    public class JobTagEntity : BaseEntity<int>
    {
        public int JobId { get; set; }
        public int TagId { get; set; }

        public JobEntity Job { get; set; } = null!;
        public TagEntity Tag { get; set; } = null;
    }
}