using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MetroUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            EzConfig.Load(ref svnPanelList);
        }
    }
}
