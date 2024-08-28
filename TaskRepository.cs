using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Homework_31
{
    public class TaskRepository
    {
        private string _filePath;

        public TaskRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Task> LoadTasks()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Task>();
            }

            string json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Task>>(json) ?? new List<Task>();
        }

        public void SaveTasks(List<Task> tasks)
        {
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}