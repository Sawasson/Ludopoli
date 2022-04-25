using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludopoli.Model
{
    public class UpdateTaskRequest
    {
        public string Name { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
    }
}
