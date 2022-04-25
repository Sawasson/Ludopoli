using System;

namespace Ludopoli.Model
{
    public class AddTaskRequest
    {

        public string Name { get; set; }
                public int PriorityId { get; set; }
                public int StatusId { get; set; }
    }
}
