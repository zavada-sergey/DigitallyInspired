using DigitallyInspired.GUI.Abstractions.ViewModels;
using DigitallyInspired.GUI.Command;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DigitallyInspired.GUI.ViewModels
{
    public class Task5ViewModel : BaseTaskViewModel
    {
        public Task5ViewModel(SceneViewModel sceneViewModel) : base(sceneViewModel) { }

        //-------------------------------------------------------------------------------------

        private int _sliderMinZ;
        public int SliderMinZ
        {
            get => _sliderMinZ;
            set
            {
                _sliderMinZ = value;
                OnPropertyChanged();
            }
        }

        private int _sliderMaxZ;
        public int SliderMaxZ
        {
            get => _sliderMaxZ;
            set
            {
                _sliderMaxZ = value;
                OnPropertyChanged();
            }
        }

        private CancellationTokenSource _cancelTask;
        public CancellationTokenSource CancelTask
        {
            get => _cancelTask;
            set
            {
                _cancelTask = value;
                OnPropertyChanged();
            }
        }

        //-------------------------------------------------------------------------------------

        private bool _isEnabledStart;
        public bool IsEnabledStart
        {
            get => _isEnabledStart;
            set
            {
                _isEnabledStart = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnabledStop;
        public bool IsEnabledStop
        {
            get => _isEnabledStop;
            set
            {
                _isEnabledStop = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnabledSliderMinZ;
        public bool IsEnabledSliderMinZ
        {
            get => _isEnabledSliderMinZ;
            set
            {
                _isEnabledSliderMinZ = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnabledSliderMaxZ;
        public bool IsEnabledSliderMaxZ
        {
            get => _isEnabledSliderMaxZ;
            set
            {
                _isEnabledSliderMaxZ = value;
                OnPropertyChanged();
            }
        }

        //-------------------------------------------------------------------------------------

        private RelayCommand _clickStart;
        public ICommand ClickStart => _clickStart ??= new RelayCommand(ExecuteStartClick);
        private void ExecuteStartClick(object parameter)
        {
            StartControlState();

            var token = CancelTask.Token;

            Task.Run(() =>
            {
                const int delay = 30;
                var i = 0;

                while (!token.IsCancellationRequested)
                {
                    for (; i < SliderMaxZ && !token.IsCancellationRequested; i++)
                    {
                        SceneViewModel.ManipulatorValue = i;
                        Thread.Sleep(delay);
                    }

                    for (; i > SliderMinZ && !token.IsCancellationRequested; i--)
                    {
                        SceneViewModel.ManipulatorValue = i;
                        Thread.Sleep(delay);
                    }
                }
            }, token);
        }

        private RelayCommand _clickStop;
        public ICommand ClickStop => _clickStop ??= new RelayCommand(ExecuteStopClick);
        private void ExecuteStopClick(object parameter)
        {
            StopControlState();
            using (CancelTask)
            {
                CancelTask.Cancel();
            }
            CancelTask = new CancellationTokenSource();
        }

        //-------------------------------------------------------------------------------------

        public override void LoadControlState(IEnumerable<TaskViewModel> listTasks)
        {
            base.LoadControlState(listTasks);
            IsEnabledSliderMinZ = true;
            IsEnabledSliderMaxZ = true;
            IsEnabledStart = true;
        }

        public override void ClearControlState(IEnumerable<TaskViewModel> listTasks)
        {
            base.ClearControlState(listTasks);
            IsEnabledSliderMinZ = false;
            IsEnabledSliderMaxZ = false;
            IsEnabledStart = false;
        }

        private void StartControlState()
        {
            IsEnabledClear = false;
            IsEnabledStart = false;
            IsEnabledStop = true;
        }

        private void StopControlState()
        {
            IsEnabledStart = true;
            IsEnabledClear = true;
            IsEnabledStop = false;
        }
    }
}