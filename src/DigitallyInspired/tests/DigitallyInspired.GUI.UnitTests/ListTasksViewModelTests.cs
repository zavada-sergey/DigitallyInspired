//using DigitallyInspired.GUI.Models;
//using DigitallyInspired.GUI.ViewModels;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;

//namespace DigitallyInspired.GUI.UnitTests
//{
//    [TestClass]
//    public class ListTasksViewModelTests
//    {
//        [TestMethod]
//        public void Test_TaskSwitcher_Positive()
//        {
//            // Arrange
//            var tasks = new List<ListTasksViewModel>
//            {
//                new ListTasksViewModel
//                {
//                    Name = "TASK 3",
//                    Model = new Task3Model(),
//                    ViewModel = new Task3ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true,
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 4",
//                    Model = new Task4Model(),
//                    ViewModel = new Task4ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 5",
//                    Model = new Task5Model(),
//                    ViewModel = new Task5ViewModel
//                    {
//                        IsEnabledLoad = true,
//                        SliderMinZ = -20,
//                        SliderMaxZ = 20,
//                        CancelTask = new CancellationTokenSource()
//                    },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                }
//            };
           
//            var task3Model = new Task3Model();
//            var task3ViewModel = new Task3ViewModel { IsEnabledLoad = true };
//            var actualTask = new ListTasksViewModel
//            {
//                Name = "TASK 3",
//                Model = task3Model,
//                ViewModel = task3ViewModel,
//                BackGround = Constans.DefaultBackGroundButtonTask,
//                IsEnabled = true
//            };

//            // Act
//            actualTask.TaskSwitcher(tasks);

//            // Assert
//            Assert.AreEqual("TASK 3", actualTask.Name);
//            Assert.AreEqual(task3Model, actualTask.Model);
//            Assert.AreEqual(task3ViewModel, actualTask.ViewModel);
//            Assert.AreEqual(Constans.SelectedBackGroundButtonTask, actualTask.BackGround);
//            Assert.IsTrue(actualTask.IsEnabled);
//            Assert.IsTrue(actualTask.IsSelected);
//        }

//        [TestMethod]
//        public void Test_TaskSwitcher_Negative()
//        {
//            // Arrange
//            var tasks = new List<ListTasksViewModel>
//            {
//                new ListTasksViewModel
//                {
//                    Name = "TASK 3",
//                    Model = new Task3Model(),
//                    ViewModel = new Task3ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true,
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 4",
//                    Model = new Task4Model(),
//                    ViewModel = new Task4ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 5",
//                    Model = new Task5Model(),
//                    ViewModel = new Task5ViewModel
//                    {
//                        IsEnabledLoad = true,
//                        SliderMinZ = -20,
//                        SliderMaxZ = 20,
//                        CancelTask = new CancellationTokenSource()
//                    },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                }
//            };

//            var actualTask = new ListTasksViewModel
//            {
//                Name = "TASK 3",
//                Model = new Task3Model(),
//                ViewModel = new Task3ViewModel(),
//                BackGround = Constans.DefaultBackGroundButtonTask,
//                IsEnabled = true
//            };

//            // Act
//            actualTask.TaskSwitcher(tasks);

//            // Assert
//            Assert.AreNotEqual("TASK 5", actualTask.Name);
//            Assert.AreNotEqual(new Task3Model(), actualTask.Model);
//            Assert.AreNotEqual(new Task3ViewModel(), actualTask.ViewModel);
//            Assert.AreNotEqual(Constans.DefaultBackGroundButtonTask, actualTask.BackGround);
//            Assert.IsTrue(actualTask.IsEnabled);
//            Assert.IsTrue(actualTask.IsSelected);
//        }

//        [TestMethod]
//        public void Test_LoadControlState_Common_Positive()
//        {
//            // Arrange
//            var tasks = new List<ListTasksViewModel>
//            {
//                new ListTasksViewModel
//                {
//                    Name = "TASK 3",
//                    Model = new Task3Model(),
//                    ViewModel = new Task3ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true,
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 4",
//                    Model = new Task4Model(),
//                    ViewModel = new Task4ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 5",
//                    Model = new Task5Model(),
//                    ViewModel = new Task5ViewModel
//                    {
//                        IsEnabledLoad = true,
//                        SliderMinZ = -20,
//                        SliderMaxZ = 20,
//                        CancelTask = new CancellationTokenSource()
//                    },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                }
//            };
            
//            var token = new CancellationTokenSource();
//            var task5Model = new Task5Model();
//            var task5ViewModel = new Task5ViewModel
//            {
//                IsEnabledLoad = true,
//                SliderMinZ = -20,
//                SliderMaxZ = 20,
//                CancelTask = token
//            };
//            var actualTask = new ListTasksViewModel
//            {
//                Name = "TASK 5",
//                Model = task5Model,
//                ViewModel = task5ViewModel,
//                BackGround = Constans.DefaultBackGroundButtonTask,
//                IsEnabled = true
//            };

//            // Act
//            actualTask.ViewModel.LoadControlState(tasks);

//            // Assert
//            Assert.IsFalse(task5ViewModel.IsEnabledLoad);
//            Assert.IsTrue(task5ViewModel.IsEnabledClear);
//            Assert.IsFalse(tasks.ElementAt(0).IsEnabled);
//            Assert.IsFalse(tasks.ElementAt(1).IsEnabled);
//            Assert.IsFalse(tasks.ElementAt(2).IsEnabled);
//            Assert.IsTrue(task5ViewModel.IsEnabledSliderMinZ);
//            Assert.IsTrue(task5ViewModel.IsEnabledSliderMaxZ);
//            Assert.IsTrue(task5ViewModel.IsEnabledStart);
//            Assert.AreEqual(token, task5ViewModel.CancelTask);
//        }

//        [TestMethod]
//        public void Test_ClearControlState_Common_Positive()
//        {
//            // Arrange
//            var tasks = new List<ListTasksViewModel>
//            {
//                new ListTasksViewModel
//                {
//                    Name = "TASK 3",
//                    Model = new Task3Model(),
//                    ViewModel = new Task3ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true,
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 4",
//                    Model = new Task4Model(),
//                    ViewModel = new Task4ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 5",
//                    Model = new Task5Model(),
//                    ViewModel = new Task5ViewModel
//                    {
//                        IsEnabledLoad = true,
//                        SliderMinZ = -20,
//                        SliderMaxZ = 20,
//                        CancelTask = new CancellationTokenSource()
//                    },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                }
//            };

//            var token = new CancellationTokenSource();
//            var task5Model = new Task5Model();
//            var task5ViewModel = new Task5ViewModel
//            {
//                IsEnabledLoad = true,
//                SliderMinZ = -20,
//                SliderMaxZ = 20,
//                CancelTask = token
//            };
//            var actualTask = new ListTasksViewModel
//            {
//                Name = "TASK 5",
//                Model = task5Model,
//                ViewModel = task5ViewModel,
//                BackGround = Constans.DefaultBackGroundButtonTask,
//                IsEnabled = true
//            };

//            // Act
//            actualTask.ViewModel.ClearControlState(tasks);

//            // Assert
//            Assert.IsTrue(task5ViewModel.IsEnabledLoad);
//            Assert.IsFalse(task5ViewModel.IsEnabledClear);
//            Assert.IsTrue(tasks.ElementAt(0).IsEnabled);
//            Assert.IsTrue(tasks.ElementAt(1).IsEnabled);
//            Assert.IsTrue(tasks.ElementAt(2).IsEnabled);
//            Assert.IsFalse(task5ViewModel.IsEnabledSliderMinZ);
//            Assert.IsFalse(task5ViewModel.IsEnabledSliderMaxZ);
//            Assert.IsFalse(task5ViewModel.IsEnabledStart);
//            Assert.AreEqual(token, task5ViewModel.CancelTask);
//        }

//        [TestMethod]
//        public void Test_ClearControlState_Task5_Positive()
//        {
//            // Arrange
//            var tasks = new List<ListTasksViewModel>
//            {
//                new ListTasksViewModel
//                {
//                    Name = "TASK 3",
//                    Model = new Task3Model(),
//                    ViewModel = new Task3ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true,
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 4",
//                    Model = new Task4Model(),
//                    ViewModel = new Task4ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 5",
//                    Model = new Task5Model(),
//                    ViewModel = new Task5ViewModel
//                    {
//                        IsEnabledLoad = true,
//                        SliderMinZ = -20,
//                        SliderMaxZ = 20,
//                        CancelTask = new CancellationTokenSource()
//                    },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                }
//            };

//            var token = new CancellationTokenSource();
//            var task5ViewModel = new Task5ViewModel
//            {
//                IsEnabledLoad = true,
//                SliderMinZ = -20,
//                SliderMaxZ = 20,
//                CancelTask = token
//            };

//            // Act
//            task5ViewModel.ClearControlState(tasks);

//            // Assert
//            Assert.IsTrue(task5ViewModel.IsEnabledLoad);
//            Assert.IsFalse(task5ViewModel.IsEnabledClear);
//            Assert.IsTrue(tasks.ElementAt(0).IsEnabled);
//            Assert.IsTrue(tasks.ElementAt(1).IsEnabled);
//            Assert.IsTrue(tasks.ElementAt(2).IsEnabled);
//            Assert.IsFalse(task5ViewModel.IsEnabledSliderMinZ);
//            Assert.IsFalse(task5ViewModel.IsEnabledSliderMaxZ);
//            Assert.IsFalse(task5ViewModel.IsEnabledStart);
//            Assert.AreEqual(token, task5ViewModel.CancelTask);
//        }

//        //Not Migrated
//        [TestMethod]
//        public void Test_ClearControlState_Common_Negative()
//        {
//            // Arrange
//            var tasks = new List<ListTasksViewModel>
//            {
//                new ListTasksViewModel
//                {
//                    Name = "TASK 3",
//                    Model = new Task3Model(),
//                    ViewModel = new Task3ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true,
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 4",
//                    Model = new Task4Model(),
//                    ViewModel = new Task4ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 5",
//                    Model = new Task5Model(),
//                    ViewModel = new Task5ViewModel
//                    {
//                        IsEnabledLoad = true,
//                        SliderMinZ = -20,
//                        SliderMaxZ = 20,
//                        CancelTask = new CancellationTokenSource()
//                    },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                }
//            };

//            var token = new CancellationTokenSource();
//            var task5ViewModel = new Task5ViewModel
//            {
//                IsEnabledLoad = true,
//                SliderMinZ = -20,
//                SliderMaxZ = 20,
//                CancelTask = token
//            };

//            // Act
//            task5ViewModel.ClearControlState(tasks);

//            // Assert
//            Assert.IsTrue(task5ViewModel.IsEnabledLoad);
//            Assert.IsFalse(task5ViewModel.IsEnabledClear);
//            Assert.IsTrue(tasks.ElementAt(0).IsEnabled);
//            Assert.IsTrue(tasks.ElementAt(1).IsEnabled);
//            Assert.IsTrue(tasks.ElementAt(2).IsEnabled);
//            Assert.IsFalse(task5ViewModel.IsEnabledSliderMinZ);
//            Assert.IsFalse(task5ViewModel.IsEnabledSliderMaxZ);
//            Assert.IsFalse(task5ViewModel.IsEnabledStart);
//            Assert.AreNotEqual(new CancellationTokenSource(), task5ViewModel.CancelTask);
//        }

//        [TestMethod]
//        public void Test_ClearControlState_Task5_Negative()
//        {
//            // Arrange
//            var tasks = new List<ListTasksViewModel>
//            {
//                new ListTasksViewModel
//                {
//                    Name = "TASK 3",
//                    Model = new Task3Model(),
//                    ViewModel = new Task3ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true,
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 4",
//                    Model = new Task4Model(),
//                    ViewModel = new Task4ViewModel { IsEnabledLoad = true },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                },
//                new ListTasksViewModel
//                {
//                    Name = "TASK 5",
//                    Model = new Task5Model(),
//                    ViewModel = new Task5ViewModel
//                    {
//                        IsEnabledLoad = true,
//                        SliderMinZ = -20,
//                        SliderMaxZ = 20,
//                        CancelTask = new CancellationTokenSource()
//                    },
//                    BackGround = Constans.DefaultBackGroundButtonTask,
//                    IsEnabled = true
//                }
//            };

//            var token = new CancellationTokenSource();
//            var task5ViewModel = new Task5ViewModel
//            {
//                IsEnabledLoad = true,
//                SliderMinZ = -20,
//                SliderMaxZ = 20,
//                CancelTask = token
//            };

//            // Act
//            task5ViewModel.ClearControlState(tasks);

//            // Assert
//            Assert.IsTrue(task5ViewModel.IsEnabledLoad);
//            Assert.IsFalse(task5ViewModel.IsEnabledClear);
//            Assert.IsTrue(tasks.ElementAt(0).IsEnabled);
//            Assert.IsTrue(tasks.ElementAt(1).IsEnabled);
//            Assert.IsTrue(tasks.ElementAt(2).IsEnabled);
//            Assert.IsFalse(task5ViewModel.IsEnabledSliderMinZ);
//            Assert.IsFalse(task5ViewModel.IsEnabledSliderMaxZ);
//            Assert.IsFalse(task5ViewModel.IsEnabledStart);
//            Assert.AreNotEqual(new CancellationTokenSource(), task5ViewModel.CancelTask);
//        }

//        [TestMethod]
//        public void Test_StartControlState_Task5_Positive()
//        {
//            // Arrange
//            var token = new CancellationTokenSource();
//            var task5ViewModel = new Task5ViewModel
//            {
//                IsEnabledLoad = true,
//                SliderMinZ = -20,
//                SliderMaxZ = 20,
//                CancelTask = token
//            };

//            // Act
//            task5ViewModel.StartControlState();

//            // Assert
//            Assert.IsFalse(task5ViewModel.IsEnabledClear);
//            Assert.IsFalse(task5ViewModel.IsEnabledStart);
//            Assert.IsTrue(task5ViewModel.IsEnabledStop);
//            Assert.AreEqual(token, task5ViewModel.CancelTask);
//        }

//        [TestMethod]
//        public void Test_StartControlState_Task5_Negative()
//        {
//            // Arrange
//            var token = new CancellationTokenSource();
//            var task5ViewModel = new Task5ViewModel
//            {
//                IsEnabledLoad = true,
//                SliderMinZ = -20,
//                SliderMaxZ = 20,
//                CancelTask = token
//            };

//            // Act
//            task5ViewModel.StartControlState();

//            // Assert
//            Assert.IsFalse(task5ViewModel.IsEnabledClear);
//            Assert.IsFalse(task5ViewModel.IsEnabledStart);
//            Assert.IsTrue(task5ViewModel.IsEnabledStop);
//            Assert.AreNotEqual(new CancellationTokenSource(), task5ViewModel.CancelTask);
//        }

//        [TestMethod]
//        public void Test_StopControlState_Task5_Positive()
//        {
//            // Arrange
//            var token = new CancellationTokenSource();
//            var task5ViewModel = new Task5ViewModel
//            {
//                IsEnabledLoad = true,
//                SliderMinZ = -20,
//                SliderMaxZ = 20,
//                CancelTask = token
//            };

//            // Act
//            task5ViewModel.StartControlState();

//            // Assert
//            Assert.IsFalse(task5ViewModel.IsEnabledStart);
//            Assert.IsFalse(task5ViewModel.IsEnabledClear);
//            Assert.IsTrue(task5ViewModel.IsEnabledStop);
//            Assert.AreEqual(token, task5ViewModel.CancelTask);
//        }

//        [TestMethod]
//        public void Test_StopControlState_Task5_Negative()
//        {
//            // Arrange
//            var token = new CancellationTokenSource();
//            var task5ViewModel = new Task5ViewModel
//            {
//                IsEnabledLoad = true,
//                SliderMinZ = -20,
//                SliderMaxZ = 20,
//                CancelTask = token
//            };

//            // Act
//            task5ViewModel.StartControlState();

//            // Assert
//            Assert.IsFalse(task5ViewModel.IsEnabledStart);
//            Assert.IsFalse(task5ViewModel.IsEnabledClear);
//            Assert.IsTrue(task5ViewModel.IsEnabledStop);
//            Assert.AreNotEqual(new CancellationTokenSource(), task5ViewModel.CancelTask);
//        }
//    }
//}