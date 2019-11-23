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

namespace SoftwareForAnalysisTimeSeries
{
	/// <summary>
	/// Логика взаимодействия для WindowError.xaml
	/// </summary>
	public partial class WindowError : Window
	{
		public WindowError(string TextError)
		{
			InitializeComponent();
			TextBlockError.Text = TextError;
		}

		private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
