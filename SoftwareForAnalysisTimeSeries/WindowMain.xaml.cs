using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class WindowMain : Window
    {
		public PredictTimeSeries predictTimeSeries;
		public StudyOfPeriodicityTimeSeries studyOfPeriodicityTimeSeries;
		public VisualPresentationTimeSeries visualPresentationTimeSeries;

		public WindowMain()
        {
            InitializeComponent();

			predictTimeSeries = new PredictTimeSeries();
			predictTimeSeries.ShowsNavigationUI = false;

			studyOfPeriodicityTimeSeries = new StudyOfPeriodicityTimeSeries();
			studyOfPeriodicityTimeSeries.ShowsNavigationUI = false;

			visualPresentationTimeSeries = new VisualPresentationTimeSeries();
			visualPresentationTimeSeries.ShowsNavigationUI = false;

			Frame.Navigate(studyOfPeriodicityTimeSeries);
        }

		private void ButtonAddNew_Click(object sender, RoutedEventArgs e)
		{
			WindowAddNewTimeSeries test = new WindowAddNewTimeSeries(this);
			test.Owner = this;
			test.ShowDialog();
		}

		private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
		{
			TableTimeSeries.ItemsSource = null;
			if (AllDataTimeSeries.ListTimeSeries.Count != 0)
			{
				List<TableInfo> list_table_info = new List<TableInfo>();

				for(int i = 0 ; i < AllDataTimeSeries.ListTimeSeries.Count; i++)
				{
					list_table_info.Add(AllDataTimeSeries.ListTimeSeries[i].GetTableInfo());
				}

				TableTimeSeries.ItemsSource = list_table_info;
			}
		}

		private void TableTimeSeries_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (TableTimeSeries.SelectedItems.Count == 1)
			{
				AllDataTimeSeries.SetSelectedRow(TableTimeSeries.SelectedIndex);

				if(visualPresentationTimeSeries.CheckedNumberTimeSeries.IsChecked.GetValueOrDefault() == true)
				{
					if(visualPresentationTimeSeries.NameSelectedTimeSeries.Text == "")
					{
						visualPresentationTimeSeries.NameSelectedTimeSeries.Text = AllDataTimeSeries.NameSelectedTimeSeries;
					}
					else
					{
						List<string> text = new List<string>(System.Text.RegularExpressions.Regex.Split(visualPresentationTimeSeries.NameSelectedTimeSeries.Text, ","));
						if(text.Find(item => item == AllDataTimeSeries.NameSelectedTimeSeries) == null)
						{
							visualPresentationTimeSeries.NameSelectedTimeSeries.Text += "," + AllDataTimeSeries.NameSelectedTimeSeries;
						}
						
					}
				}

				test_1.Text = AllDataTimeSeries.NameSelectedTimeSeries; //-----------------------------улучшить
			}
		}

		private void ButtonStudyOfPeriodicity_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(studyOfPeriodicityTimeSeries);
		}

		private void ButtonVisualPresentation_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(visualPresentationTimeSeries);
		}

		private void ButtonDeleteSelectedRow(object sender, RoutedEventArgs e)
		{
			if(AllDataTimeSeries.SelectedRow == -1)
			{
				WindowError windowError = new WindowError("Не выбран временной ряд");
				windowError.Show();
				return;
			}

			AllDataTimeSeries.ListTimeSeries.RemoveAt(AllDataTimeSeries.SelectedRow);
			AllDataTimeSeries.SelectedRow = -1;
			test_1.Text = "";
			this.ButtonUpdate_Click(sender , e);
		}

		private void ButtonSaveTimeSeries_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
			saveFileDialog.Filter = "Файлы xlsx|*.xlsx";
			//Microsoft.Office.Interop.Excel.Workbook xl = new Microsoft.Office.Interop.Excel.Workbook();

			if (saveFileDialog.ShowDialog() == true)
			{
				string str = saveFileDialog.FileName;


				Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
				application.Visible = true;
				application.Workbooks.Add();
				Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)application.ActiveSheet;
				ObjWorkSheet.Cells[1, "A"] = "Date";
				ObjWorkSheet.Cells[1, "B"] = "Value";

				List<Dimension> temp = AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetTimeSeries();
				for (int i = 0; i < temp.Count; i++)
				{
					ObjWorkSheet.Cells[i+2, "A"] = temp[i].Time.ToString();
					ObjWorkSheet.Cells[i+2, "B"] = temp[i].Value;
				}
				ObjWorkSheet.SaveAs(str);
				application.Quit();
				

			/*
				Stream stream = saveFileDialog.OpenFile();
				try
						{
							using (StreamWriter sw = new StreamWriter(stream))
							{
								sw.WriteLine(ParcerDataTable.GetFileName());
								sw.WriteLine(Checked_name_column_value.Text);
								sw.WriteLine(Checked_name_column_time.Text);
								sw.WriteLine(Checked_number_list.Text);
								sw.WriteLine(Checked_number_line_start_information.Text);
								sw.WriteLine(Checked_number_line_end_information.Text);
								sw.WriteLine(Checked_color_series.Text);
								sw.WriteLine(NameSeries.Text);
								if (Checked_flag_simplified_date.IsChecked == true)
								{
									sw.WriteLine("true");
								}
								else
								{
									sw.WriteLine("false");
								}


							}
						}
						catch
						{
							WindowError windowError = new WindowError("Не удалось сохранить файл");
							windowError.Show();
						}*/
			}
		}

		private void ButtonPredict_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(predictTimeSeries);
		}
	}
}
