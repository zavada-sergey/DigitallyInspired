using DigitallyInspired.GUI.Command;
using DigitallyInspired.GUI.ViewModels;
using HelixToolkit.Wpf;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace DigitallyInspired.GUI.Abstractions.ViewModels
{
    public abstract class BaseTaskViewModel : BaseViewModel
    {
        protected readonly SceneViewModel SceneViewModel;

        protected BaseTaskViewModel(SceneViewModel sceneViewModel)
        {
            SceneViewModel = sceneViewModel;
        }

        //-------------------------------------------------------------------------------------

        private bool _isEnabledLoad;
        public bool IsEnabledLoad
        {
            get => _isEnabledLoad;
            set
            {
                _isEnabledLoad = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnabledClear;
        public bool IsEnabledClear
        {
            get => _isEnabledClear;
            set
            {
                _isEnabledClear = value;
                OnPropertyChanged();
            }
        }

        //-------------------------------------------------------------------------------------

        private RelayCommand _clickLoad;
        public ICommand ClickLoad => _clickLoad ??= new RelayCommand(ExecuteClickLoad);
        private void ExecuteClickLoad(object parameter)
        {
            var openFileDialog = new OpenFileDialog { Filter = "3D model format (*.obj)|*.obj" };
            if (openFileDialog.ShowDialog() ?? true)
            {
                Task.Run(() => new ModelImporter().Load(openFileDialog.FileName, null, true)).ContinueWith(task =>
                {
                    LoadControlState((IEnumerable<TaskViewModel>)parameter);
                    Init3DModel(task.Result.CloneCurrentValue());
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private RelayCommand _clickClear;
        public ICommand ClickClear => _clickClear ??= new RelayCommand(ExecuteClickClear);
        private void ExecuteClickClear(object parameter)
        {
            SceneViewModel.ClearScene();
            ClearControlState((IEnumerable<TaskViewModel>)parameter);
        }

        //-------------------------------------------------------------------------------------

        public virtual void LoadControlState(IEnumerable<TaskViewModel> listTasks)
        {
            foreach (var taskViewModel in listTasks.Where(x => !x.IsSelected))
            {
                taskViewModel.IsEnabled = false;
            }
            IsEnabledLoad = false;
            IsEnabledClear = true;
        }

        public virtual void ClearControlState(IEnumerable<TaskViewModel> listTasks)
        {
            foreach (var taskViewModel in listTasks)
            {
                taskViewModel.IsEnabled = true;
            }
            IsEnabledLoad = true;
            IsEnabledClear = false;
        }

        public virtual void Init3DModel(Model3DGroup model)
        {
            SceneViewModel.Model3D = model;
        }
    }
}