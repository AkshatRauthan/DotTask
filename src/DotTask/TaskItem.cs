using System;

namespace DotTask
{
    public class TaskItem
    {
        public string Title { get; set; } // Task name
        public bool IsCompleted { get; set; } // Completion status

        public TaskItem(string title)
        {
            Title = title;
            IsCompleted = false; // Initially, task is not completed
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public void MarkAsPending()
        {
            IsCompleted = false;
        }

        public override string ToString()
        {
            return $"{Title} (Completed: {IsCompleted})";
        }
    }
}
