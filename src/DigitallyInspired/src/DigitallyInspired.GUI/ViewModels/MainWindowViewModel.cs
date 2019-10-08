using DigitallyInspired.GUI.Abstractions.ViewModels;

namespace DigitallyInspired.GUI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public SceneViewModel SceneViewModel { get; }
        public TasksViewModel TasksViewModel { get; }

        public MainWindowViewModel()
        {
            SceneViewModel = new SceneViewModel();
            TasksViewModel = new TasksViewModel(SceneViewModel);
        }
    }
}