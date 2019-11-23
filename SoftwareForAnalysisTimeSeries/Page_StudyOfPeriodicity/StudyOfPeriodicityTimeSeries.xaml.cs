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
    /// Логика взаимодействия для StudyOfPeriodicityTimeSeries.xaml
    /// </summary>
    public partial class StudyOfPeriodicityTimeSeries : Page
    {
        public StudyOfPeriodicityTimeSeries()
        {
            InitializeComponent();
			TextBoxColor.IsReadOnly = true;
			TextBoxName.IsReadOnly = true;
		}

		private void PermissionInputTextBox(object sender, RoutedEventArgs e)
		{
			TextBoxColor.IsReadOnly = false;
			TextBoxName.IsReadOnly = false;
		}

		private void NotPermissionInputTextBox(object sender, RoutedEventArgs e)
		{
			TextBoxColor.Text = "";
			TextBoxName.Text = "";
			TextBoxColor.IsReadOnly = true;
			TextBoxName.IsReadOnly = true;
		}

		private void Button_Click_Normalize(object sender, RoutedEventArgs e)
		{
			if (AllDataTimeSeries.SelectedRow == -1)
			{
				WindowError windowError = new WindowError("Данные не выбраны");
				windowError.Show();
				return;
			}

			if (NewTimeSeriesChecked.IsChecked == true)
			{
				if(TextBoxName.Text == "" || TextBoxColor.Text == "")
				{
					WindowError windowError = new WindowError("Присутствуют пустые поля");
					windowError.Show();
					return;
				}

				if (AllDataTimeSeries.CheckedUniqueNameTimeSeries(TextBoxName.Text) == false)
				{
					WindowError windowError = new WindowError("Необходимо уникальное имя для временного ряда");
					windowError.Show();
					return;
				}

				TimeSeries temp = new TimeSeries();
				temp.Set_flag_sequence(AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].Get_flag_sequence());
				temp.SetNameTimeSeries(TextBoxName.Text);
				temp.SetColor((Color)ColorConverter.ConvertFromString(TextBoxColor.Text));

				List<Dimension> dimensions =  AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetTimeSeries();
				for (int i = 0; i < dimensions.Count(); i++)
				{
					temp.AddDimensionTime(dimensions[i].Time , dimensions[i].Value);
				}

				temp.CalculateMin();
				temp.CalculateMax();
				temp.CalculateAvg();
				temp.CalculateAvgSquareDeviation();

				int temp_selected_row = AllDataTimeSeries.SelectedRow;
				AllDataTimeSeries.AddNewTimeSeries(temp);
				AllDataTimeSeries.SetSelectedRow(AllDataTimeSeries.ListTimeSeries.Count - 1);

				if (NormalizeOn_Avg.IsChecked == true)
					AllDataTimeSeries.NormalizeOn_Avg();

				if (NormalizeOn_σ.IsChecked == true)
					AllDataTimeSeries.NormalizeOn_σ();

				AllDataTimeSeries.SetSelectedRow(temp_selected_row);
			}
			else
			{
				if(NormalizeOn_Avg.IsChecked == true)
					AllDataTimeSeries.NormalizeOn_Avg();

				if (NormalizeOn_σ.IsChecked == true)
					AllDataTimeSeries.NormalizeOn_σ();
			}
		}

		private void ButtonAutocorrelation_Click(object sender, RoutedEventArgs e)
		{
			if (AllDataTimeSeries.SelectedRow == -1)
			{
				WindowError windowError = new WindowError("Данные не выбраны");
				windowError.Show();
				return;
			}
			//добавить создание нового ряда
			WindowGraphicView windowTest = new WindowGraphicView(AllDataTimeSeries.Autocorrelation() , AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetColor());
			windowTest.Show();
		}

		private void ButtonFFT_Click(object sender, RoutedEventArgs e)
		{
			if(AllDataTimeSeries.SelectedRow == -1)
			{
				WindowError windowError = new WindowError("Данные не выбраны");
				windowError.Show();
				return;
			}

			WindowGraphicView windowTest = new WindowGraphicView(AllDataTimeSeries.FFT(), AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetColor());
			windowTest.Show();

		}
	}
}
