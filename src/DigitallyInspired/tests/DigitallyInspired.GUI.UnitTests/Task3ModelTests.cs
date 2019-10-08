//using DigitallyInspired.GUI.Abstractions.Models;
//using DigitallyInspired.GUI.Models;
//using DigitallyInspired.GUI.ViewModels;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Windows.Media.Media3D;

//namespace DigitallyInspired.GUI.UnitTests
//{
//    [TestClass]
//    public class Task3ModelTests
//    {
//        [TestMethod]
//        public void Test_TaskDefinitions_Positive()
//        {
//            // Arrange
//            BaseTaskModel task = new Task3Model();
//            var scene = new SceneViewModel();
//            var model = new Model3DGroup();

//            // Act
//            task.InitModel(scene, model);

//            // Assert
//            Assert.IsNotNull(scene.Model3D);
//            Assert.IsNull(scene.CoordinatesBoundingBox);
//            Assert.AreEqual(0, scene.ManipulatorValue);
//        }

//        [TestMethod]
//        public void Test_TaskDefinitions_Negative()
//        {
//            // Arrange
//            BaseTaskModel task = new Task3Model();
//            var scene = new SceneViewModel();
//            var model = new Model3DGroup();

//            // Act
//            task.InitModel(scene, model);

//            // Assert
//            Assert.IsNotNull(scene.Model3D);
//            Assert.IsNull(scene.CoordinatesBoundingBox);
//            Assert.AreNotEqual(10, scene.ManipulatorValue);
//        }
//    }
//}