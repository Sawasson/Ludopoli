using Ludopoli.Core;
using Ludopoli.Model;

using Microsoft.AspNetCore.Mvc;


namespace Ludopoli.API.Controllers
{
    [ApiController]
    public class TasksController : Controller
    {
        private readonly ITaskRepository taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
            this.taskRepository.Init();
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetTaskList()
        {
            var taskList = taskRepository.GetTaskList();

            return Ok(taskList);
        }

        [HttpGet]
        [Route("[controller]/{taskId:int}")]
        public IActionResult GetTask([FromRoute] int taskId)
        {
            var task = taskRepository.GetTask(taskId);

            if (task == null)
            {
                return NotFound();
            }


            return Ok(task);
        }

        [HttpPut]
        [Route("[controller]/{taskId:int}")]
        public IActionResult UpdateTask([FromRoute] int taskId, [FromBody] UpdateTaskRequest request)
        {
            if (taskRepository.GetTask(taskId)!=null && !taskRepository.IsTaskExist(request.Name))
            {
                var task = new TaskEntity();
                task.Name = request.Name;
                task.PriorityId = request.PriorityId;
                task.StatusId = request.StatusId;

                var updatedTask = taskRepository.UpdateTask(taskId, task);

                if (updatedTask != null)
                {
                    return Ok(updatedTask);
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[controller]/{taskId:int}")]
        public IActionResult DeleteTask([FromRoute] int taskId)
        {
            if (taskRepository.GetTask(taskId) != null)
            {
                var task = taskRepository.DeleteTask(taskId);

                if (task != null)
                {
                    return Ok(task);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public IActionResult AddTask([FromBody] AddTaskRequest request)
        {
            if (!taskRepository.IsTaskExist(request.Name))
            {
                var newTask = new TaskEntity();
                newTask.Name = request.Name;
                newTask.PriorityId = request.PriorityId;
                newTask.StatusId = request.StatusId;

                var createdTask = taskRepository.AddTask(newTask);

                return CreatedAtAction(nameof(GetTask), new { taskId = createdTask.Id }, createdTask);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("Priorities")]
        public IActionResult GetPriorityList()
        {
            var priorityList = taskRepository.GetPriorityList();
            if (priorityList == null)
            {
                return NotFound();
            }
            return Ok(priorityList);
        }

        [HttpGet]
        [Route("Statuses")]
        public IActionResult GetStatusList()
        {
            var statusList = taskRepository.GetStatusList();
            if (statusList==null)
            {
                return NotFound();
            }
            return Ok(statusList);
        }


    }
}
