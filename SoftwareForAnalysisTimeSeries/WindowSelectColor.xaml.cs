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
using System.Windows.Shapes;
using System.Drawing;
using System.Reflection;

namespace SoftwareForAnalysisTimeSeries
{
	/// <summary>
	/// Логика взаимодействия для WindowSelectColor.xaml
	/// </summary>
	public partial class WindowSelectColor : Window
	{
		WindowAddNewTimeSeries window_;
		public WindowSelectColor(WindowAddNewTimeSeries window)
		{
			InitializeComponent();
			window_ = window;

			List<Cell> ListCell = new List<Cell>();
			Color obj = (Color)Colors.AliceBlue;

			foreach (var item in typeof(Colors).GetProperties())
			{
				Cell cell = new Cell();
				string[] words = item.ToString().Split(new char[] { ' ' });
				cell.NameColor = words[1];
				ListCell.Add(cell);
			}
			TableColor.ItemsSource = ListCell;
		}

		public class Cell
		{
			public string NameColor { get; set; }
		}

		private void TableColor_MouseDoubleClick(object sender, RoutedEventArgs e)
		{
			if(TableColor.SelectedItems.Count == 1)
			{
				window_.GetResultWindowSelectColor(((Cell)TableColor.SelectedItems[0]).NameColor);
				this.Close();
			}
		}
	}
}
