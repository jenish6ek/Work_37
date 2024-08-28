using System;

namespace Homework_31
{
    public abstract class TaskState
    {
        public abstract void ChangeStatus(Task task, TaskStatus newStatus);
        public abstract void ChangeDescription(Task task, string newDescription);
    }

    public class NewTaskState : TaskState
    {
        public override void ChangeStatus(Task task, TaskStatus newStatus)
        {
            if (newStatus == TaskStatus.InProgress)
            {
                task.Status = newStatus;
            }
        }

        public override void ChangeDescription(Task task, string newDescription)
        {
            task.Description = newDescription;
        }
    }

    public class InProgressTaskState : TaskState
    {
        public override void ChangeStatus(Task task, TaskStatus newStatus)
        {
            if (newStatus == TaskStatus.Done)
            {
                task.Status = newStatus;
            }
        }

        public override void ChangeDescription(Task task, string newDescription)
        {
            throw new InvalidOperationException("Cannot change description of a task in progress.");
        }
    }

    public class DoneTaskState : TaskState
    {
        public override void ChangeStatus(Task task, TaskStatus newStatus)
        {
            throw new InvalidOperationException("Cannot change status of a done task.");
        }

        public override void ChangeDescription(Task task, string newDescription)
        {
            throw new InvalidOperationException("Cannot change description of a done task.");
        }
    }
}