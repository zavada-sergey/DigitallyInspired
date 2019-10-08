using DigitallyInspired.GUI.Abstractions.ViewModels;
using DigitallyInspired.GUI.Models;
using HelixToolkit.Wpf;
using System.Windows.Media.Media3D;

namespace DigitallyInspired.GUI.ViewModels
{
    public class Task4ViewModel : BaseTaskViewModel 
    {
        private readonly Task4Model _model;

        public Task4ViewModel(SceneViewModel sceneViewModel) : base(sceneViewModel)
        {
            _model = new Task4Model();
        }

        //-------------------------------------------------------------------------------------

        public override void Init3DModel(Model3DGroup model)
        {
            var builder = new MeshBuilder();
            builder.AddBoundingBox(model.Bounds, 0.15);
            model.Children.Add(new GeometryModel3D(builder.ToMesh(), Materials.Black));
            SceneViewModel.Model3D = model;
            SceneViewModel.CoordinatesBoundingBox = _model.GetCoordinatesForBoundingBox(builder.Positions);
        }
    }
}