using DigitallyInspired.GUI.Abstractions.ViewModels;
using System.Windows.Media.Media3D;

namespace DigitallyInspired.GUI.ViewModels
{
    public class SceneViewModel : BaseViewModel
    {
        private Model3D _model3D;
        public Model3D Model3D
        {
            get => _model3D;
            set
            {
                _model3D = value;
                OnPropertyChanged();
            }
        }

        private Point3DCollection _coordinatesBoundingBox;
        public Point3DCollection CoordinatesBoundingBox
        {
            get => _coordinatesBoundingBox;
            set
            {
                _coordinatesBoundingBox = value;
                OnPropertyChanged();
            }
        }

        private double _manipulatorValue;
        public double ManipulatorValue
        {
            get => _manipulatorValue;
            set
            {
                if (_manipulatorValue == value) return;
                _manipulatorValue = value;
                OnPropertyChanged();
            }
        }

        //-------------------------------------------------------------------------------------

        public void ClearScene()
        {
            Model3D = null;
            CoordinatesBoundingBox = null;
            ManipulatorValue = 0;
        }
    }
}