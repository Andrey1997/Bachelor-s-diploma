using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class AllDataTimeSeries
{
	const double e = 0.0000001;

	public static List<TimeSeries> ListTimeSeries = new List<TimeSeries>();
	public static int SelectedRow = -1;
	public static string NameSelectedTimeSeries;

	public static void AddNewTimeSeries(TimeSeries timeSeries_)
	{
		ListTimeSeries.Add(timeSeries_);
	}
	public static int CountTimeSeries()
	{
		return ListTimeSeries.Count();
	}
	public static void SetSelectedRow(int a)
	{
		SelectedRow = a;
		SetNameSelectedTimeSeries();
	}
	private static void SetNameSelectedTimeSeries()
	{
		NameSelectedTimeSeries = ListTimeSeries[SelectedRow].GetNameTimeSeries();
	}
	public static void NormalizeOn_Avg()
	{
		TableInfo temp = ListTimeSeries[SelectedRow].GetTableInfo();
		if (!(Math.Abs(temp.Avg) < e))
		{
			ListTimeSeries[SelectedRow].NormalizeOn_Avg();
			ListTimeSeries[SelectedRow].CalculateMin();
			ListTimeSeries[SelectedRow].CalculateMax();
			ListTimeSeries[SelectedRow].CalculateAvg();
			ListTimeSeries[SelectedRow].CalculateAvgSquareDeviation();
		}
	}
	public static void NormalizeOn_σ()
	{
		TableInfo temp = ListTimeSeries[SelectedRow].GetTableInfo();
		if (!(Math.Abs(temp.AvgSquareDeviation) < (e + 1) && Math.Abs(temp.AvgSquareDeviation) > (1 - e)))
		{
			ListTimeSeries[SelectedRow].NormalizeOn_σ();
			ListTimeSeries[SelectedRow].CalculateMin();
			ListTimeSeries[SelectedRow].CalculateMax();
			ListTimeSeries[SelectedRow].CalculateAvg();
			ListTimeSeries[SelectedRow].CalculateAvgSquareDeviation();
		}
	}
	public static List<Dimension> Autocorrelation()
	{
		if (CheckedUniqueNameTimeSeries(ListTimeSeries[SelectedRow].GetNameTimeSeries() + "_Autocorrelation") == true)
		{
			TimeSeries timeSeries_NewName = new TimeSeries();
			timeSeries_NewName.SetNameTimeSeries(ListTimeSeries[SelectedRow].GetNameTimeSeries() + "_Autocorrelation");
			timeSeries_NewName.SetColor(ListTimeSeries[SelectedRow].GetColor());
			timeSeries_NewName.Set_flag_sequence(ListTimeSeries[SelectedRow].Get_flag_sequence());
			timeSeries_NewName.SetTimeSeries(ListTimeSeries[SelectedRow].Autocorrelation());

			timeSeries_NewName.CalculateMin();
			timeSeries_NewName.CalculateMax();
			timeSeries_NewName.CalculateAvg();
			timeSeries_NewName.CalculateAvgSquareDeviation();

			AddNewTimeSeries(timeSeries_NewName);

			return timeSeries_NewName.GetTimeSeries();
		}
		else
		{
			return ListTimeSeries[SelectedRow].Autocorrelation();
		}
	}
	public static bool CheckedUniqueNameTimeSeries(string name)
	{
		if (ListTimeSeries.Count() == 0) return true;

		for(int i = 0; i < ListTimeSeries.Count(); i++)
		{
			if (ListTimeSeries[i].GetNameTimeSeries() == name)
				return false;
		}
		return true;
	}
	public static List<Dimension> FFT()
	{
		if (CheckedUniqueNameTimeSeries(ListTimeSeries[SelectedRow].GetNameTimeSeries() + "_FFT") == true)
		{
			TimeSeries timeSeries_NewName = new TimeSeries();
			timeSeries_NewName.SetNameTimeSeries(ListTimeSeries[SelectedRow].GetNameTimeSeries() + "_FFT");
			timeSeries_NewName.SetColor(ListTimeSeries[SelectedRow].GetColor());
			timeSeries_NewName.Set_flag_sequence(ListTimeSeries[SelectedRow].Get_flag_sequence());
			timeSeries_NewName.SetTimeSeries(ListTimeSeries[SelectedRow].FFT());

			timeSeries_NewName.CalculateMin();
			timeSeries_NewName.CalculateMax();
			timeSeries_NewName.CalculateAvg();
			timeSeries_NewName.CalculateAvgSquareDeviation();

			AddNewTimeSeries(timeSeries_NewName);

			return timeSeries_NewName.GetTimeSeries();
		}
		else
		{
			return ListTimeSeries[SelectedRow].FFT();
		}
	}
	public static List<Dimension> ExponentialSmoothingMethod(double a)
	{
		if (CheckedUniqueNameTimeSeries(ListTimeSeries[SelectedRow].GetNameTimeSeries() + "_ExpSmooth") == true)
		{
			TimeSeries timeSeries_NewName = new TimeSeries();
			timeSeries_NewName.SetNameTimeSeries(ListTimeSeries[SelectedRow].GetNameTimeSeries() + "_ExpSmooth");
			timeSeries_NewName.SetColor(ListTimeSeries[SelectedRow].GetColor());
			timeSeries_NewName.Set_flag_sequence(ListTimeSeries[SelectedRow].Get_flag_sequence());


			timeSeries_NewName.SetTimeSeries(ListTimeSeries[SelectedRow].ExponentialSmoothingMethod(a));

			timeSeries_NewName.CalculateMin();
			timeSeries_NewName.CalculateMax();
			timeSeries_NewName.CalculateAvg();
			timeSeries_NewName.CalculateAvgSquareDeviation();

			AddNewTimeSeries(timeSeries_NewName);

			return timeSeries_NewName.GetTimeSeries();
		}
		else
		{
			return ListTimeSeries[SelectedRow].ExponentialSmoothingMethod(a);
		}
	}
	public static List<Dimension> MovingAverageMethod(int n , int m)
	{
		if (CheckedUniqueNameTimeSeries(ListTimeSeries[SelectedRow].GetNameTimeSeries() + "_MovingAvg") == true)
		{
			TimeSeries timeSeries_NewName = new TimeSeries();
			timeSeries_NewName.SetNameTimeSeries(ListTimeSeries[SelectedRow].GetNameTimeSeries() + "_MovingAvg");
			timeSeries_NewName.SetColor(ListTimeSeries[SelectedRow].GetColor());
			timeSeries_NewName.Set_flag_sequence(ListTimeSeries[SelectedRow].Get_flag_sequence());


			timeSeries_NewName.SetTimeSeries(ListTimeSeries[SelectedRow].MovingAverageMethod(n, m));

			timeSeries_NewName.CalculateMin();
			timeSeries_NewName.CalculateMax();
			timeSeries_NewName.CalculateAvg();
			timeSeries_NewName.CalculateAvgSquareDeviation();

			AddNewTimeSeries(timeSeries_NewName);

			return timeSeries_NewName.GetTimeSeries();
		}
		else
		{
			return ListTimeSeries[SelectedRow].MovingAverageMethod(n, m);
		}
	}
	public static List<Dimension> LeastSquareMethod(int m , bool flag)
	{
		if (CheckedUniqueNameTimeSeries(ListTimeSeries[SelectedRow].GetNameTimeSeries() + "_LeastSquare") == true)
		{
			TimeSeries timeSeries_NewName = new TimeSeries();
			timeSeries_NewName.SetNameTimeSeries(ListTimeSeries[SelectedRow].GetNameTimeSeries() + "_LeastSquare");
			timeSeries_NewName.SetColor(ListTimeSeries[SelectedRow].GetColor());
			timeSeries_NewName.Set_flag_sequence(ListTimeSeries[SelectedRow].Get_flag_sequence());


			timeSeries_NewName.SetTimeSeries(ListTimeSeries[SelectedRow].LeastSquareMethod(m , flag));

			timeSeries_NewName.CalculateMin();
			timeSeries_NewName.CalculateMax();
			timeSeries_NewName.CalculateAvg();
			timeSeries_NewName.CalculateAvgSquareDeviation();

			AddNewTimeSeries(timeSeries_NewName);

			return timeSeries_NewName.GetTimeSeries();
		}
		else
		{
			return ListTimeSeries[SelectedRow].LeastSquareMethod(m , flag);
		}
	}

}

