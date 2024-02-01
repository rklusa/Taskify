using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.IO;

namespace ToDoListApp
{
    internal class DataSerializer
    {
        private List<Task> data;
        private string fileName;

        public DataSerializer() 
        {
            data = new List<Task>();
            fileName = "Data.json";
        }

        public void CopyData(List<Task> tasks, List<Task> completedTasks)
        {
            data = new List<Task>(tasks);
            data.AddRange(completedTasks);
        }

        public void SaveData()
        {
            var formatting = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(data, formatting);
            File.WriteAllText(fileName, json);
        }

        public List<Task> LoadData()
        {
            string json = File.ReadAllText(fileName);
            var list = JsonSerializer.Deserialize<List<Task>>(json);

            return list;
        }
    }
}
