using Ludopoli.API.DataModels;
using Ludopoli.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludopoli.API.Repositories
{
    public interface ITaskRepository
    {
        List<TaskEntity> GetTaskList();

        TaskEntity GetTask(int taskId);

        TaskEntity UpdateTask(int taskId, TaskEntity task);

        List<Priority> GetPriorityList();

        List<Status> GetStatusList();

        TaskEntity DeleteTask(int taskId);

        TaskEntity AddTask(TaskEntity request);

        bool IsTaskExist(string taskName);


    }
}
