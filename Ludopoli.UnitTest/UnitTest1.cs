using Ludopoli.Core;
using Ludopoli.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

namespace Ludopoli.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        InMemoryTaskRepository repository;

        public UnitTest1()
        {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<TaskContext>()
                            .UseInMemoryDatabase(databaseName: myDatabaseName)
                            .Options;
            this.repository = new InMemoryTaskRepository(new TaskContext(options));
        }


        [TestMethod]
        public void task_add_test()
        {
            TaskEntity taskTest = GetNewTask();

            this.repository.AddTask(taskTest);

            var taskControl = this.repository.GetTask(taskTest.Id);


            Assert.AreEqual(taskControl.Name, taskTest.Name);
            Assert.AreEqual(taskControl.PriorityId, taskTest.PriorityId);
            Assert.AreEqual(taskControl.StatusId, taskTest.StatusId);


        }

        private static TaskEntity GetNewTask()
        {
            return new TaskEntity()
            {
                Name = "Test Task",
                PriorityId = 1,
                StatusId = 1
                

            };
        }

        [TestMethod]
        public void task_update_test()
        {

            TaskEntity task = GetNewTask();
            this.repository.AddTask(task);
            var taskControl = this.repository.GetAllTaskList().FirstOrDefault();

            taskControl.Name = "TestUpdateTask";
            taskControl.PriorityId = 2;
            taskControl.StatusId = 2;

            this.repository.UpdateTask(taskControl.Id, taskControl);

            var taskTest = this.repository.GetTask(taskControl.Id);

            Assert.AreEqual(taskControl.Name, taskTest.Name);
            Assert.AreEqual(taskControl.PriorityId, taskTest.PriorityId);
            Assert.AreEqual(taskControl.StatusId, taskTest.StatusId);

        }

        [TestMethod]
        public void task_delete_test()
        {
            TaskEntity task = GetNewTask();
            this.repository.AddTask(task);

            this.repository.DeleteTask(task.Id);

            var deletedTask = this.repository.GetTask(task.Id);

            Assert.AreEqual(deletedTask.Id, task.Id);
            Assert.AreEqual(deletedTask.Name, task.Name);
            Assert.AreEqual(deletedTask.PriorityId, task.PriorityId);
            Assert.AreEqual(deletedTask.StatusId, task.StatusId);

        }

        [TestMethod]
        public void task_exist_test()
        {
            TaskEntity task = GetNewTask();
            this.repository.AddTask(task);


            var isExist = this.repository.IsTaskExist(task.Name);
            Assert.IsTrue(isExist);


        }


        [TestMethod]
        public void delete_completed_task_test()
        {
            TaskEntity task = GetNewTask();
            task.StatusId = 3;
            this.repository.AddTask(task);

            var deletedTask = this.repository.DeleteTask(task.Id);

            Assert.AreEqual(deletedTask.Id, task.Id);
            Assert.AreEqual(deletedTask.Name, task.Name);
            Assert.AreEqual(deletedTask.PriorityId, task.PriorityId);
            Assert.AreEqual(deletedTask.StatusId, task.StatusId);

        }



    }
}
