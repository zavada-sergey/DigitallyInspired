using DigitallyInspired.GUI.Abstractions.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace DigitallyInspired.GUI.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        public BaseTaskViewModel ViewModel { get; }

        public TaskViewModel(BaseTaskViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        private Brush _backGround;
        public Brush BackGround
        {
            get => _backGround;
            set
            {
                _backGround = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        //-------------------------------------------------------------------------------------

        public void TaskSwitcher(IEnumerable<TaskViewModel> tasks)
        {
            var previousSelectedTask = tasks.FirstOrDefault(x => x.IsSelected);
            if (previousSelectedTask != null)
            {
                previousSelectedTask.IsSelected = false;
                previousSelectedTask.BackGround = Constans.DefaultBackGroundButtonTask;
            }
            IsSelected = true;
            BackGround = Constans.SelectedBackGroundButtonTask;
        }
    }
}