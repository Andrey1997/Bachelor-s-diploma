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
using System.IO;
using System.Drawing;

namespace SoftwareForAnalysisTimeSeries
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class WindowAddNewTimeSeries : Window
	{
		ParcerDataTable ParcerDataTable;
		WindowMain windowMain_;
		public WindowAddNewTimeSeries(WindowMain windowMain)
		{
			InitializeComponent();
			windowMain_ = windowMain;
		}

		public TimeSeries GetTimeSeries()
		{
			return ParcerDataTable.GetTimeSeries();
		}

		public bool CheckTimeSeries()
		{
			return ParcerDataTable.CheckedResultParcer();
		}

		private void SelectFile_Click(object sender, RoutedEventArgs e)
		{
			ParcerDataTable = new ParcerDataTable();
			if(ParcerDataTable.GetResultOpenFileDialog() == true)
			{
				TextBoxNotFoundFile.Text = "Файл выбран";
			}
			else
			{
				TextBoxNotFoundFile.Text = "Файл не выбран";
			}
		}

		private void FileProcessing_Click(object sender, RoutedEventArgs e)
		{
			if(Checked_name_column_time.Text == "" || Checked_name_column_value.Text == "" || 
				Checked_number_line_end_information.Text == "" || 
				Checked_number_line_end_information.Text == "" || Checked_number_list.Text == "")
			{
				WindowError windowError = new WindowError("Присутствуют незаполненные поля");
				windowError.Show();
				return;
			}

			if(NameSeries.Text == "" || NameSeries.Text.IndexOf(",") != -1)
			{
				WindowError windowError = new WindowError("Имя ряда не пустое поле, не содержащее запятую");
				windowError.Show();
				return;
			}

			try
			{
				if (ParcerDataTable.CheckedFile() == false)
				{
					WindowError windowError = new WindowError("Не найден выбранный файл");
					windowError.Show();
					return;	
				}
			}
			catch
			{
				WindowError windowError = new WindowError("Не выбран файл");
				windowError.Show();
				return;
			}

			OptionsParcerDataTable optionsParcerDataTable = new OptionsParcerDataTable();

			try
			{
				optionsParcerDataTable.Set_flag_simplified_date(Checked_flag_simplified_date.IsChecked.GetValueOrDefault());
				optionsParcerDataTable.Set_name_column_time(Checked_name_column_time.Text);
				optionsParcerDataTable.Set_name_column_value(Checked_name_column_value.Text);
				optionsParcerDataTable.Set_number_line_end_information(Checked_number_line_end_information.Text);
				optionsParcerDataTable.Set_number_line_start_information(Checked_number_line_start_information.Text);
				optionsParcerDataTable.Set_number_list(Checked_number_list.Text);
				optionsParcerDataTable.Set_color(Checked_color_series.Text);
				optionsParcerDataTable.Set_name(NameSeries.Text);

				if(AllDataTimeSeries.CheckedUniqueNameTimeSeries(NameSeries.Text) == false)
				{
					WindowError windowError = new WindowError("Необходимо уникальное имя для временного ряда");
					windowError.Show();
					return;
				}
			}
			catch
			{
				WindowError windowError = new WindowError("Некорректно заполнены поля");
				windowError.Show();
				return;
			}

			try
			{
				ParcerDataTable.Parcer(optionsParcerDataTable);
			}
			catch
			{
				WindowError windowError = new WindowError("Не удалось прочитать файл по указанным параметрам");
				windowError.Show();
				return;
			}

			if(ParcerDataTable.CheckedResultParcer() == true)
			{
				AllDataTimeSeries.AddNewTimeSeries(ParcerDataTable.GetTimeSeries());
				this.Close();				
			}
		}

		private void MenuSelectedColor_Click(object sender, RoutedEventArgs e)
		{
			WindowSelectColor windowSelectColor = new WindowSelectColor(this);
			windowSelectColor.Owner = this;
			windowSelectColor.ShowDialog();
		}

		public void GetResultWindowSelectColor(string NameColor)
		{
			Checked_color_series.Text = NameColor;
		}

		private void OpenConfiguration(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
			fileDialog.Filter = "Файлы txt|*.txt";

			if (fileDialog.ShowDialog() == true)
			{
				string Path = fileDialog.FileName;

				try
				{
					using (StreamReader sr = new StreamReader(Path, System.Text.Encoding.Default))
					{
						ParcerDataTable = new ParcerDataTable(sr.ReadLine());   //путь к xlsx
						Checked_name_column_value.Text = sr.ReadLine();
						Checked_name_column_time.Text = sr.ReadLine();
						Checked_number_list.Text = sr.ReadLine();
						Checked_number_line_start_information.Text = sr.ReadLine();
						Checked_number_line_end_information.Text = sr.ReadLine();
						Checked_color_series.Text = sr.ReadLine();
						NameSeries.Text = sr.ReadLine();
						if (sr.ReadLine() == "true")
							Checked_flag_simplified_date.IsChecked = true;
						else
						{
							Checked_flag_simplified_date.IsChecked = false;
						}
						TextBoxNotFoundFile.Text = "Файл выбран";
					}
				}
				catch
				{
					TextBoxNotFoundFile.Text = "Файл не выбран";
					WindowError windowError = new WindowError("Не удалось прочитать файл");
					windowError.Show();
					return;
				}
			}
				
		}

		private void SaveConfiguration(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
			saveFileDialog.Filter = "Файлы txt|*.txt";

			if (saveFileDialog.ShowDialog() == true)
			{
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
				}
			}
		}
	}

	public class ParcerDataTable
	{
		private TimeSeries timeSeries_ = new TimeSeries();

		private bool ResultOpenFileDialog = false;
		private bool ResultParcer = false;
		private string FileName = "";

		public ParcerDataTable(string Path)
		{
			FileName = Path;
			ResultOpenFileDialog = true;
		}
		public string GetFileName()
		{
			return FileName;
		}
		public ParcerDataTable()
		{
			Microsoft.Win32.OpenFileDialog FileDialog = new Microsoft.Win32.OpenFileDialog();
			FileDialog.Filter = "Файлы xlsx|*.xlsx";

			if (FileDialog.ShowDialog() == true)
			{
				FileName = FileDialog.FileName;
				ResultOpenFileDialog = true;
			}
			else ResultOpenFileDialog = false;
		}
		~ParcerDataTable()
		{
			
		}
		public bool GetResultOpenFileDialog()
		{			
			return ResultOpenFileDialog;
		}
		public bool CheckedFile()
		{
			if (FileName == "") return false;
			return File.Exists(FileName);
		}
		public void Parcer(OptionsParcerDataTable options)
		{
			timeSeries_.ClearTimeSeries();

			Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();			
			Microsoft.Office.Interop.Excel.Workbook ObjWorkbook = ObjExcel.Workbooks.Open(FileName, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); ;
			Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
			ObjWorkSheet = ObjWorkbook.Sheets[options.Get_number_list()];

			for (int i = options.number_line_start_information; i <= options.number_line_end_information; i++)
			{
				Microsoft.Office.Interop.Excel.Range range_time = ObjWorkSheet.get_Range(options.Get_name_column_time() + i.ToString(), options.Get_name_column_time() + i.ToString());
				Microsoft.Office.Interop.Excel.Range range_value = ObjWorkSheet.get_Range(options.Get_name_column_value() + i.ToString(), options.Get_name_column_value() + i.ToString());

				if (range_time.Text.ToString() == "" || range_value.Text.ToString() == "")
				{
					//обнаружена пустая клетка
					ObjExcel.Quit();
					WindowError windowError = new WindowError("В файле присутствуют пустые поля");
					windowError.Show();
					return;
				}

				timeSeries_.Set_flag_sequence(options.flag_simplified_date);
				if(options.flag_simplified_date == true)
				{
					timeSeries_.AddDimensionTime(new DateTime(int.Parse(range_time.Text), 1, 1), Double.Parse(range_value.Text));
				}
				else
				{
					timeSeries_.AddDimensionTime(DateTime.Parse(range_time.Text), Double.Parse(range_value.Text));
				}
			}
			ObjExcel.Quit();
			timeSeries_.Sort();
			
			timeSeries_.SetColor(options.Get_color());
			timeSeries_.SetNameTimeSeries(options.Get_name());

			timeSeries_.CalculateAvg();
			timeSeries_.CalculateMax();
			timeSeries_.CalculateMin();
			timeSeries_.CalculateAvgSquareDeviation();

			ResultParcer = true;			
		}
		public bool CheckedResultParcer()
		{
			return ResultParcer;
		}
		public TimeSeries GetTimeSeries()
		{
			return timeSeries_;
		}
	}

	public class OptionsParcerDataTable
	{
		public String name_column_value;	//название столбца со значениями ряда
		public String name_column_time;		//название столбца со значениями дата
		public bool flag_simplified_date;   //флаг датой является числа integer

		public int number_line_start_information; //строка с которой начинаются необходимые значения
		public int number_line_end_information; //строка с которой начинаются необходимые значения

		public int number_list;             //номер необходимого листа в excel
		public Color colors_;
		public string NameTimeSeries;

		public void Set_name(string name)
		{
			NameTimeSeries = name;
		}
		public string Get_name()
		{
			return NameTimeSeries;
		}
		public void Set_color(string color)
		{
			colors_ = (Color)ColorConverter.ConvertFromString(color);
		}
		public void Set_flag_simplified_date(bool flag)
		{
			flag_simplified_date = flag;
		}
		public void Set_number_list(String text)
		{
			number_list = Convert.ToInt32(text);
			if (number_list < 0) number_list = 0;
		}
		public void Set_name_column_value(String text)
		{
			name_column_value = text;
		}
		public void Set_name_column_time(String text)
		{
			name_column_time = text;
		}
		public void Set_number_line_start_information(String text)
		{
			number_line_start_information = Convert.ToInt32(text);
			if (number_line_start_information < 1) number_line_start_information = 1;
		}
		public void Set_number_line_end_information(String text)
		{
			number_line_end_information = Convert.ToInt32(text);
			if (number_line_end_information < 1) number_line_end_information = 1;
		}
		public String Get_name_column_value()
		{
			return name_column_value;
		}
		public String Get_name_column_time()
		{
			return name_column_time;
		}
		public bool Get_flag_simplified_date()
		{
			return flag_simplified_date;
		}
		public int Get_number_line_start_information()
		{
			return number_line_start_information;
		}
		public int Get_number_line_end_information()
		{
			return number_line_end_information;
		}
		public int Get_number_list()
		{
			return number_list;
		}
		public Color Get_color()
		{
			return colors_;
		}

	}

}
