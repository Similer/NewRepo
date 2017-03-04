using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;

namespace MetroUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        static public StackPanel mainPanel;

        public MainWindow()
        {
            InitializeComponent();

            mainPanel = svnPanelList;
        }

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
			Control.KeyboardShortcut.Process(sender as MainWindow, e);			
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            EzConfig.Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(EzConfig.Path);
        }
    }
}
