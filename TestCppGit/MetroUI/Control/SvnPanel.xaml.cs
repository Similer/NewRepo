using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MetroUI.Control;

namespace MetroUI
{
    /// <summary>
    /// Interaction logic for SvnPanel.xaml
    /// </summary>
    public partial class SvnPanel : UserControl
    {
		public static int GIndexCount = 0;

		public int SeletedIndex = -1;

        public SvnPanel(string path)
        {
            InitializeComponent();

			SeletedIndex = GIndexCount++;

			svnLable.Content = path;
		}

        private void Lable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();

            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Label lable = sender as Label;
                if (lable != null)
                {
                    var beforeContent = lable.Content;
                    lable.Content = dialog.SelectedPath;

                    EzConfig.Save((string)beforeContent, (string)lable.Content);
                }
            }
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string path = svnLable.Content as string;
			path.RepoBrowser();
		}

		public void Select()
		{
			this.Background = Brushes.Blue;

		}

		public void Deselect()
		{
			this.Background = Brushes.White;
		}

	}
}
