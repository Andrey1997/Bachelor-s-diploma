using SoftwareForAnalysisTimeSeries.Page_VisualPresentation;
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
	/// Логика взаимодействия для VisualPresentationTimeSeries.xaml
	/// </summary>
	public partial class VisualPresentationTimeSeries : Page
	{
		public VisualPresentationTimeSeries()
		{
			InitializeComponent();
			AllTime.IsChecked = true;

			StartDate.IsReadOnly = true;
			EndDate.IsReadOnly = true;
		}

		private void TableView_Click(object sender, RoutedEventArgs e)
		{
			if (AllDataTimeSeries.SelectedRow == -1)
			{
				WindowError windowError = new WindowError("Данные не выбраны");
				windowError.Show();
				return;
			}

			TimeSeries temp = new TimeSeries();
			temp.Set_flag_sequence(AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].Get_flag_sequence());
			temp.SetNameTimeSeries(AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetNameTimeSeries());
			temp.SetColor(AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetColor());

			List<Dimension> dimensions = AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetTimeSeries();
			for (int i = 0; i < dimensions.Count(); i++)
			{
				temp.AddDimensionTime(dimensions[i].Time, dimensions[i].Value);
			}


			if (GivenTime.IsChecked == true)
			{
				try
				{
					if (temp.Get_flag_sequence() == true)
					{
						temp.LimitDate(new DateTime(int.Parse(StartDate.Text), 1, 1), new DateTime(int.Parse(EndDate.Text), 1, 1));
					}
					else
					{
						temp.LimitDate(DateTime.Parse(StartDate.Text), DateTime.Parse(EndDate.Text));
					}
				}
				catch
				{
					WindowError windowError = new WindowError("Некорректно задана дата");
					windowError.Show();
					return;
				}
			}

			WindowTableView window = new WindowTableView(temp.GetTimeSeries());
			window.Show();
		}

		private void GraphicView_Click(object sender, RoutedEventArgs e)
		{
			if(CheckedNumberTimeSeries.IsChecked.GetValueOrDefault() == false)
			{
				if (AllDataTimeSeries.SelectedRow == -1)
				{
					WindowError windowError = new WindowError("Данные не выбраны");
					windowError.Show();
					return;
				}

				TimeSeries temp = new TimeSeries();
				temp.Set_flag_sequence(AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].Get_flag_sequence());
				temp.SetNameTimeSeries(AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetNameTimeSeries());
				temp.SetColor(AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetColor());

				List<Dimension> dimensions = AllDataTimeSeries.ListTimeSeries[AllDataTimeSeries.SelectedRow].GetTimeSeries();
				for (int i = 0; i < dimensions.Count(); i++)
				{
					temp.AddDimensionTime(dimensions[i].Time, dimensions[i].Value);
				}


				if (GivenTime.IsChecked == true)
				{
					try
					{
						if (temp.Get_flag_sequence() == true)
						{
							temp.LimitDate(new DateTime(int.Parse(StartDate.Text), 1, 1), new DateTime(int.Parse(EndDate.Text), 1, 1));
						}
						else
						{
							temp.LimitDate(DateTime.Parse(StartDate.Text), DateTime.Parse(EndDate.Text));
						}
					}
					catch
					{
						WindowError windowError = new WindowError("Некорректно задана дата");
						windowError.Show();
						return;
					}
				}

				WindowGraphicView graphicView = new WindowGraphicView(temp.GetTimeSeries(), temp.GetColor());
				graphicView.Show();
			}
			else
			{
				if (NameSelectedTimeSeries.Text == "")
				{
					WindowError windowError = new WindowError("Ничего не выбрано");
					windowError.Show();
					return;
				}

				List<string> qqqqq = new List<string>(System.Text.RegularExpressions.Regex.Split(NameSelectedTimeSeries.Text, ","));
				List<TimeSeries> timeSeries_s = new List<TimeSeries>();
				for(int i = 0; i < qqqqq.Count(); i++)
				{
					for(int j = 0; j < AllDataTimeSeries.ListTimeSeries.Count(); j++)
					{
						if(qqqqq[i] == AllDataTimeSeries.ListTimeSeries[j].GetNameTimeSeries())
						{
							TimeSeries temp = new TimeSeries();
							temp.Set_flag_sequence(AllDataTimeSeries.ListTimeSeries[j].Get_flag_sequence());
							temp.SetNameTimeSeries(AllDataTimeSeries.ListTimeSeries[j].GetNameTimeSeries());
							temp.SetColor(AllDataTimeSeries.ListTimeSeries[j].GetColor());

							List<Dimension> dimensions = AllDataTimeSeries.ListTimeSeries[j].GetTimeSeries();
							for (int k = 0; k < dimensions.Count(); k++)
							{
								temp.AddDimensionTime(dimensions[k].Time, dimensions[k].Value);
							}

							timeSeries_s.Add(temp);
						}
					}
				}

				if (GivenTime.IsChecked == true)
				{
					try
					{
						for (int i = 0; i < timeSeries_s.Count; i++)
							if (timeSeries_s[i].Get_flag_sequence() == true)
							{
								timeSeries_s[i].LimitDate(new DateTime(int.Parse(StartDate.Text), 1, 1), new DateTime(int.Parse(EndDate.Text), 1, 1));
							}
							else
							{
								timeSeries_s[i].LimitDate(DateTime.Parse(StartDate.Text), DateTime.Parse(EndDate.Text));
							}
					}
					catch
					{
						WindowError windowError = new WindowError("Некорректно задана дата");
						windowError.Show();
						return;
					}
				}

				WindowGraphicView graphicView = new WindowGraphicView(timeSeries_s);
				graphicView.Show();
			}
		}

		private void Clear_NameSelectedTimeSeries_Click(object sender, RoutedEventArgs e)
		{
			NameSelectedTimeSeries.Text = "";
		}

		private void OpenDate(object sender, RoutedEventArgs e)
		{
			StartDate.IsReadOnly = false;
			EndDate.IsReadOnly = false;
		}

		private void CloseDate(object sender, RoutedEventArgs e)
		{
			StartDate.IsReadOnly = true;
			EndDate.IsReadOnly = true;
		}
	}
}
