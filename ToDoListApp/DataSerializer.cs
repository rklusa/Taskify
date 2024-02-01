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
            data = new List<Task>(tasks); // not a deep copy of the list may not work
            data.AddRange(completedTasks);
        }

        public void SaveData()
        {
            string json = JsonSerializer.Serialize(data);
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
