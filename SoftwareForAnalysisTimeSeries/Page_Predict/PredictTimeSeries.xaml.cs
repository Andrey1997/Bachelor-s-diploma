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


namespace SoftwareForAnalysisTimeSeries
{
	/// <summary>
	/// Логика взаимодействия для PredictTimeSeries.xaml
	/// </summary>
	public partial class PredictTimeSeries : Page
	{
		public PredictTimeSeries()
		{
			InitializeComponent();
		}

		private void ButtonExponentialSmoothingMethod_Click(object sender, RoutedEventArgs e)
		{
			if (AllDataTimeSeries.SelectedRow == -1)
			{
				WindowError windowError = new WindowError("Данные не выбраны");
				windowError.Show();
				return;
			}

			double a;

			try
			{
				a = Convert.ToDouble(SmoothingIntervalExp.Text);
			}
			catch
			{
				WindowError windowError = new WindowError("Некорректно задан параметр, диапазон от 0 до 1");
				windowError.Show();
				return;
			}

			if (a < 0 || a > 1)
			{
				WindowError windowError = new WindowError("Некорректно задан параметр, диапазон от 0 до 1");
				windowError.Show();
				return;
			}
			
			WindowGraphicView windowTest = new WindowGraphicView(AllDataTimeSeries.ExponentialSmoothingMethod(a), AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetColor());
			windowTest.Show();

		}

		private void ButtonMovingAverageMethod_Click(object sender, RoutedEventArgs e)
		{
			if (AllDataTimeSeries.SelectedRow == -1 || SmoothingInterval.Text == "")
			{
				WindowError windowError = new WindowError("Данные не выбраны");
				windowError.Show();
				return;
			}

			int n, m;
			try
			{
				n = Convert.ToInt32(SmoothingInterval.Text);
				m = Convert.ToInt32(QuantityPredict.Text);
			}
			catch
			{
				WindowError windowError = new WindowError("Неудалось распознать значение (требуется int)");
				windowError.Show();
				return;
			}

			if (n < 3 || n % 2 == 0)
			{
				WindowError windowError = new WindowError("Величина интервала сглаживания должна быть не меньше 3\n и нечетное");
				windowError.Show();
				return;
			}

			if (m < 0)
			{
				WindowError windowError = new WindowError("Количество предсказываемых значений \nдолжно быть не отрицательным");
				windowError.Show();
				return;
			}
			




			WindowGraphicView windowTest = new WindowGraphicView(AllDataTimeSeries.MovingAverageMethod(n , m), AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetColor());
			windowTest.Show();
		}

		private void ButtonMethodLeastSquares_Click(object sender, RoutedEventArgs e)
		{
			if (AllDataTimeSeries.SelectedRow == -1 || QuantityPredictLeastSquares.Text == "")
			{
				WindowError windowError = new WindowError("Данные не выбраны");
				windowError.Show();
				return;
			}

			int m;
			try
			{
				m = Convert.ToInt32(QuantityPredictLeastSquares.Text);
			}
			catch
			{
				WindowError windowError = new WindowError("Неудалось распознать значение (требуется int)");
				windowError.Show();
				return;
			}

			if (m < 0)
			{
				WindowError windowError = new WindowError("Количество предсказываемых значений \nдолжно быть не отрицательным");
				windowError.Show();
				return;
			}
			bool flag = TypeMethodLeastSquares.IsChecked.GetValueOrDefault();
			WindowGraphicView windowTest = new WindowGraphicView(AllDataTimeSeries.LeastSquareMethod(m , flag), AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetColor());
			windowTest.Show();
		}
	}
}
