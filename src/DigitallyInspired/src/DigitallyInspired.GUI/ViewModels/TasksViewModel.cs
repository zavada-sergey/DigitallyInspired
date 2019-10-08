using DigitallyInspired.GUI.Abstractions.ViewModels;
using DigitallyInspired.GUI.Command;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;

namespace DigitallyInspired.GUI.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        public IEnumerable<TaskViewModel> ListTasks { get; }

        private TaskViewModel _selectedTask;
        public TaskViewModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                OnPropertyChanged();
            }
        }

        public TasksViewModel(SceneViewModel sceneViewModel)
        {
            var task3ViewModel = new Task3ViewModel(sceneViewModel) { IsEnabledLoad = true };
            var task4ViewModel = new Task4ViewModel(sceneViewModel) { IsEnabledLoad = true };
            var task5ViewModel = new Task5ViewModel(sceneViewModel)
            {
                IsEnabledLoad = true,
                SliderMinZ = -20,
                SliderMaxZ = 20,
                CancelTask = new CancellationTokenSource()
            };

            ListTasks = new List<TaskViewModel>
            {
                new TaskViewModel(task3ViewModel)
                {
                    Name = "TASK 3",
                    BackGround = Constans.DefaultBackGroundButtonTask,
                    IsEnabled = true,
                },
                new TaskViewModel(task4ViewModel)
                {
                    Name = "TASK 4",
                    BackGround = Constans.DefaultBackGroundButtonTask,
                    IsEnabled = true
                },
                new TaskViewModel(task5ViewModel)
                {
                    Name = "TASK 5",
                    BackGround = Constans.DefaultBackGroundButtonTask,
                    IsEnabled = true
                }
            };
        }

        private RelayCommand _clickSelectTask;
        public ICommand ClickSelectTask => _clickSelectTask ??= new RelayCommand(ExecuteClickSelectTask);
        private void ExecuteClickSelectTask(object parameter)
        {
            SelectedTask = (TaskViewModel)parameter;
            SelectedTask.TaskSwitcher(ListTasks);
        }
    }
}
