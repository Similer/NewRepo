using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;

namespace MetroUI.Control
{
    static public class KeyboardShortcut
    {
		static public int selectedPanelIndex = -1;

		static public void Process(MainWindow mainWindow, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				mainWindow.Close();
			}

			if (e.Key >= Key.D1 && e.Key <= Key.D9)
			{
				var index = e.Key - Key.D1;
				var uilist = mainWindow.svnPanelList.Children.OfType<SvnPanel>();

				// 요기부터
				var existItem = uilist.Where(x => x.SeletedIndex == selectedPanelIndex).FirstOrDefault();

				uilist.Where(x => x.SeletedIndex == index)
					.First()
					.Select();

				selectedPanelIndex = index;
			}
		}
    }
}
