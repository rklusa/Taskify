using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    internal class User
    {
        public List<Task> tasks = new List<Task>();
        public List<Task> completedTasks = new List<Task>();


        public string GetDate()
        {
            string date = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            return date;
        }

        public void AddTask(string title)
        {
            tasks.Add(new Task() { Title =  title, Completed = false });
        }

        public void CompleteTask()
        {
            foreach (Task t in tasks.ToList()) // tasks.ToList() is not the ideal solution
            {
                if (t.Completed)
                {
                    tasks.Remove(t);
                    completedTasks.Add(t);
                }
            }
        }

        public void UnCompleteTask()
        {
            foreach (Task t in completedTasks.ToList()) // tasks.ToList() is not the ideal solution
            {
                if (!t.Completed)
                {
                    completedTasks.Remove(t);
                    tasks.Add(t);
                }
            }
        }
    }
}
