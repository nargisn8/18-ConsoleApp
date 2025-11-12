

using Academy.Domain.Common;

namespace Academy.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }
    }
}
