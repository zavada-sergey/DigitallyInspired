using DigitallyInspired.GUI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Media.Media3D;

namespace DigitallyInspired.GUI.UnitTests
{
    [TestClass]
    public class SceneViewModelTests
    {
        [TestMethod]
        public void Test_ClearScene_Positive()
        {
            // Arrange
            var scene = new SceneViewModel { Model3D = new Model3DGroup(), CoordinatesBoundingBox = new Point3DCollection(), ManipulatorValue = 10.0 };

            // Act
            scene.ClearScene();

            // Assert
            Assert.IsNull(scene.Model3D);
            Assert.IsNull(scene.CoordinatesBoundingBox);
            Assert.AreEqual(0, scene.ManipulatorValue);
        }

        [TestMethod]
        public void Test_ClearScene_Negative()
        {
            // Arrange
            var scene = new SceneViewModel { Model3D = new Model3DGroup(), CoordinatesBoundingBox = new Point3DCollection(), ManipulatorValue = 10.0 };

            // Act
            scene.ClearScene();

            // Assert
            Assert.IsNull(scene.Model3D);
            Assert.IsNull(scene.CoordinatesBoundingBox);
            Assert.AreNotEqual(10, scene.ManipulatorValue);
        }
    }
}