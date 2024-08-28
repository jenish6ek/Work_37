using System;

namespace Homework_31
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum TaskStatus
    {
        New,
        InProgress,
        Done
    }

    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Priority Priority { get; set; }
        public TaskStatus Status { get; set; }

        public Task(string title, string description, DateTime dueDate, Priority priority)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            CreatedDate = DateTime.Now;
            Priority = priority;
            Status = TaskStatus.New;
        }
    }
}