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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using Wpf;
using Wpf.CartesianChart.Using_DateTime;

namespace SoftwareForAnalysisTimeSeries
{
	/// <summary>
	/// Логика взаимодействия для WindowTest.xaml
	/// </summary>
	public partial class WindowGraphicView : Window
	{
		


		public WindowGraphicView(List<Dimension> test_ , Color a)
		{
			InitializeComponent();
			GraphicView.Content = new UserControl1(test_ , a);
		}

		public WindowGraphicView(List<TimeSeries> timeSeries_s)
		{
			InitializeComponent();
			GraphicView.Content = new UserControl1(timeSeries_s);
		}
		

	}

}
