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

namespace SoftwareForAnalysisTimeSeries.Page_VisualPresentation
{
	/// <summary>
	/// Логика взаимодействия для WindowTableView.xaml
	/// </summary>
	public partial class WindowTableView : Window
	{
		public WindowTableView(List<Dimension> dimensions)
		{
			InitializeComponent();
			List<Dimension> temp = new List<Dimension>();
			for(int i = 0; i < dimensions.Count; i++)
			{
				temp.Add(new Dimension(dimensions[i].Time, dimensions[i].Value));
			}
			
			Info_.ItemsSource = temp;
		}
	}
}
