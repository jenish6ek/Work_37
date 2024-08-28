using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_31
{
    public class TaskManager
    {
        private List<Task> _tasks;
        private TaskRepository _taskRepository;

        public TaskManager(string filePath)
        {
            _taskRepository = new TaskRepository(filePath);
            _tasks = _taskRepository.LoadTasks();
        }

        public void DisplayTasks()
        {
            if (_tasks.Count == 0)
            {
                Console.WriteLine("Задач нет.");
                return;
            }

            for (int i = 0; i < _tasks.Count; i++)
            {
                var task = _tasks[i];
                Console.WriteLine($"Индекс: {i}");
                Console.WriteLine($"Название: {task.Title}");
                Console.WriteLine($"Описание: {task.Description}");
                Console.WriteLine($"Дата завершения: {task.DueDate.ToShortDateString()}");
                Console.WriteLine($"Дата создания: {task.CreatedDate.ToShortDateString()}");
                Console.WriteLine($"Приоритет: {task.Priority}");
                Console.WriteLine($"Статус: {task.Status}");
                Console.WriteLine();
            }
        }

        public void AddTask(string title, string description, DateTime dueDate, Priority priority)
        {
            var newTask = new Task(title, description, dueDate, priority);
            _tasks.Add(newTask);
            _taskRepository.SaveTasks(_tasks);
        }

        public void ModifyTask(int taskIndex, string newDescription)
        {
            if (taskIndex < 0 || taskIndex >= _tasks.Count)
            {
                throw new ArgumentOutOfRangeException("Неверный индекс задачи.");
            }

            var task = _tasks[taskIndex];

            if (task.Status == TaskStatus.New)
            {
                task.Description = newDescription;
                _taskRepository.SaveTasks(_tasks);
            }
            else
            {
                throw new InvalidOperationException("Нельзя изменить описание задачи, которая не является новой.");
            }
        }

        public void ChangeTaskStatus(int taskIndex, TaskStatus newStatus)
        {
            if (taskIndex < 0 || taskIndex >= _tasks.Count)
            {
                throw new ArgumentOutOfRangeException("Неверный индекс задачи.");
            }

            var task = _tasks[taskIndex];

            if (task.Status == TaskStatus.New && newStatus == TaskStatus.InProgress)
            {
                task.Status = newStatus;
            }
            else if (task.Status == TaskStatus.InProgress && newStatus == TaskStatus.Done)
            {
                task.Status = newStatus;
            }
            else
            {
                throw new InvalidOperationException("Неверный переход статуса задачи.");
            }

            _taskRepository.SaveTasks(_tasks);
        }

        public void DeleteTask(int taskIndex)
        {
            if (taskIndex < 0 || taskIndex >= _tasks.Count)
            {
                throw new ArgumentOutOfRangeException("Неверный индекс задачи.");
            }

            var task = _tasks[taskIndex];

            if (task.Status == TaskStatus.New)
            {
                _tasks.RemoveAt(taskIndex);
                _taskRepository.SaveTasks(_tasks);
            }
            else
            {
                throw new InvalidOperationException("Нельзя удалить задачу, которая не является новой.");
            }
        }
    }
}