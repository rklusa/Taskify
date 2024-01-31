using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoListApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// DisplayMemberPath="Title"
    public partial class MainWindow : Window
    {
        User user = new User();

        public MainWindow()
        {
            InitializeComponent();

            dateText.Text = user.GetDate();
            //user.tasks.Add(new Task() { Title = "fart", Completed = false });
            TaskList.ItemsSource = user.tasks;
            CompletedTaskList.ItemsSource = user.completedTasks;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            user.AddTask("");
            RefreshTasks();
        }

        private void Task_Checked(object sender, RoutedEventArgs e)
        {
            user.CompleteTask();
            RefreshTasks();
        }

        private void Task_UnChecked(object sender, RoutedEventArgs e)
        {
            user.UnCompleteTask();
            RefreshTasks();
        }

        private void Delete_Task(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int index = TaskList.Items.IndexOf(button.DataContext);
            Trace.WriteLine(index);

            user.DeleteTask(index);
            RefreshTasks();
        }

        private void Delete_Completed_Task(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int index = CompletedTaskList.Items.IndexOf(button.DataContext);
            Trace.WriteLine(index);

            user.DeleteCompletedTask(index);
            RefreshTasks();
        }

        private void RefreshTasks()
        {
            TaskList.Items.Refresh();
            CompletedTaskList.Items.Refresh();
        }

        
    }
}
