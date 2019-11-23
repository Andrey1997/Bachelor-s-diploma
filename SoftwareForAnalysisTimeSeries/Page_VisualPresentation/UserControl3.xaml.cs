using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace Wpf.CartesianChart.Using_DateTime
{
	public partial class UserControl1 : UserControl
	{
		public UserControl1(List<Dimension> test_ , Color colors)
		{
			InitializeComponent();

			var dayConfig = Mappers.Xy<Dimension>()
				.X(dayModel => (double)dayModel.Time.Ticks / TimeSpan.FromDays(1).Ticks)
				.Y(dayModel => dayModel.Value);
	

			Series = new SeriesCollection(dayConfig)
			{
				new LineSeries
				{
					Title = "Series",
					Values = new ChartValues<Dimension> (test_),
					PointForeground = new SolidColorBrush(colors),
					Stroke = new SolidColorBrush(colors),
					Fill = Brushes.Transparent
				}
			};

			Formatter = value => new System.DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("d");

			DataContext = this;
		}

		public UserControl1(List<TimeSeries> timeSeries_s)
		{
			InitializeComponent();

			var dayConfig = Mappers.Xy<Dimension>()
				.X(dayModel => (double)dayModel.Time.Ticks / TimeSpan.FromDays(1).Ticks)
				.Y(dayModel => dayModel.Value);

			Series = new SeriesCollection(dayConfig);
			for(int i = 0; i < timeSeries_s.Count(); i++)
			{
				LineSeries temp = new LineSeries()
				{
					Title = timeSeries_s[i].GetNameTimeSeries(),
					Values = new ChartValues<Dimension>(timeSeries_s[i].GetTimeSeries()),
					PointForeground = new SolidColorBrush(timeSeries_s[i].GetColor()),
					Stroke = new SolidColorBrush(timeSeries_s[i].GetColor()),
					Fill = Brushes.Transparent
				};

				Series.Add(temp);
			}

			Formatter = value => new System.DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("d");

			DataContext = this;
		}
		
		public Func<double, string> Formatter { get; set; }
		public SeriesCollection Series { get; set; }
	}
}