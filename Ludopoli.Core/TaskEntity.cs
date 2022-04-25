using System;

namespace Ludopoli.Core
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
