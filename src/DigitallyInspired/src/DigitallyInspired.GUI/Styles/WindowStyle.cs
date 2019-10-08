using System;
using System.Windows;
using System.Windows.Controls;

namespace DigitallyInspired.GUI.Styles
{
    internal static class LocalExtensions
    {
        public static void ForWindowFromTemplate(this object templateFrameworkElement, Action<Window> action)
        {
            if (((FrameworkElement)templateFrameworkElement).TemplatedParent is Window window) action(window);
        }
    }

    public partial class WindowStyle
    {
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ((Window)sender).StateChanged += WindowStateChanged;
        }

        private void WindowStateChanged(object sender, EventArgs e)
        {
            var w = ((Window)sender);
            var containerBorder = (Border)w.Template.FindName("PART_Container", w);

            if (w.WindowState == WindowState.Maximized)
            {
                containerBorder.Padding = new Thickness(
                    SystemParameters.WorkArea.Left + 7,
                    SystemParameters.WorkArea.Top + 7,
                    (SystemParameters.PrimaryScreenWidth - SystemParameters.WorkArea.Right) + 7,
                    (SystemParameters.PrimaryScreenHeight - SystemParameters.WorkArea.Bottom) + 5);
            }
            else
            {
                containerBorder.Padding = new Thickness(7, 7, 7, 5);
            }
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(SystemCommands.CloseWindow);
        }

        private void MinButtonClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(SystemCommands.MinimizeWindow);
        }

        private void MaxButtonClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(w =>
            {
                if (w.WindowState == WindowState.Maximized) SystemCommands.RestoreWindow(w);
                else SystemCommands.MaximizeWindow(w);
            });
        }
    }
}