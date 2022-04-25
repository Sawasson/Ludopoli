using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludopoli.Core
{
    public interface ITaskRepository
    {
        List<TaskEntity> GetTaskList();

        TaskEntity GetTask(int taskId);

        TaskEntity UpdateTask(int taskId, TaskEntity task);

        List<Priority> GetPriorityList();

        List<Status> GetStatusList();
        void Init();
        TaskEntity DeleteTask(int taskId);

        TaskEntity AddTask(TaskEntity request);

        bool IsTaskExist(string taskName);


    }
}
