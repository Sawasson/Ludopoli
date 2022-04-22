using Ludopoli.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ludopoli.API.Enums;


namespace Ludopoli.API.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {

        private readonly TaskContext context;

        public InMemoryTaskRepository(TaskContext context)
        {
            this.context = context;
        }




        public List<Priority> GetPriorityList()
        {
            return context.Priorities.ToList();
        }


        public List<Status> GetStatusList()
        {
            return context.Statuses.ToList();
        }


        public List<TaskEntity> GetTaskList()
        {

            return context.TaskEntities.Include(x=>x.Priority).Include(x=>x.Status).ToList();
        }

        public TaskEntity GetTask(int taskId)
        {
            return context.TaskEntities.FirstOrDefault(x=>x.Id==taskId);
        }

        public TaskEntity UpdateTask(int taskId, TaskEntity request)
        {
            var existingTask = GetTask(taskId);
            if (existingTask != null)
            {
                existingTask.Name = request.Name;
                existingTask.PriorityId = request.PriorityId;
                existingTask.StatusId = request.StatusId;
                context.SaveChanges();
                return existingTask;
            }

            return null;

        }

        public TaskEntity DeleteTask(int taskId)
        {
            var existingTask = GetTask(taskId);
            if (existingTask != null)
            {
                if (existingTask.StatusId==3)
                {
                    context.TaskEntities.Remove(existingTask);
                    context.SaveChanges();
                    return existingTask;
                }
                return null;
            }

            return null;

        }

        public TaskEntity AddTask(TaskEntity request)
        {
            var task = context.TaskEntities.Add(request);
            context.SaveChanges();
            return task.Entity;
        }

        public bool IsTaskExist(string taskName)
        {
            if (context.TaskEntities.Any(x=>x.Name == taskName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
