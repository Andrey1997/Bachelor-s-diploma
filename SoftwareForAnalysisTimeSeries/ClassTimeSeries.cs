using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Numerics;


public class TimeSeries
{
	const double e = 0.0000001;

	private List<Dimension> Time_Series;
	private bool flag_sequence;
	private string NameTimeSeries;
	private Color color;

	private double Min;
	private double Max;
	private double Avg;
	private double AvgSquareDeviation;

	public List<Dimension> LeastSquareMethod(int m , bool flag)
	{
		double sum_yx = 0;
		double sum_yxx = 0;

		for (int i = 0; i < Time_Series.Count; i++)
		{
			sum_yx += Time_Series[i].Value * (i + 1);
			sum_yxx += Time_Series[i].Value * (i + 1) * (i + 1);
		}

		double sum_x = 0;
		double sum_xx = 0;
		double sum_xxx = 0;
		double sum_xxxx = 0;
		double sum_x_x = 0;
		double sum_y = 0;

		for (int i = 0; i < Time_Series.Count; i++)
		{
			sum_x += (i + 1);
			sum_y += Time_Series[i].Value;
			sum_xx += (i + 1) * (i + 1);
			sum_xxx += (i + 1) * (i + 1) * (i + 1);
			sum_xxxx += (i + 1) * (i + 1) * (i + 1) * (i + 1);
		}

		sum_x_x = sum_x * sum_x;

		List<Dimension> dimensions = new List<Dimension>();

		if (flag == true)
		{
			List<List<double>> matrix = new List<List<double>>();
			List<double> a_ = new List<double>();
			a_.Add(sum_xx / Time_Series.Count);
			a_.Add(sum_x / Time_Series.Count);

			List<double> b_ = new List<double>();
			b_.Add(sum_x / Time_Series.Count);
			b_.Add(1);

			matrix.Add(a_);
			matrix.Add(b_);

			List<Double> y_ = new List<double>();
			y_.Add(sum_yx / Time_Series.Count);
			y_.Add(sum_y / Time_Series.Count);

			List<double> result = gauss(matrix, y_, 2);

			//double a = (sum_yx - sum_x * sum_y / Time_Series.Count) / (sum_xx - sum_x_x / Time_Series.Count);
			double a = result[0];
			//double b = (sum_y - a * sum_x) / Time_Series.Count;
			double b = result[1];
			

			for (int i = 0; i < Time_Series.Count; i++)
			{
				dimensions.Add(new Dimension(Time_Series[i].Time, a * (i+1) + b));
			}

			for (int i = Time_Series.Count; i < m + Time_Series.Count; i++)
			{
				DateTime dateTime = dimensions[dimensions.Count - 1].Time + (dimensions[dimensions.Count - 1].Time - dimensions[dimensions.Count - 2].Time);
				dimensions.Add(new Dimension(dateTime, a * (i + 1) + b));
			}
		}
		else
		{
			List<List<double>> matrix = new List<List<double>>();
			List<double> a_ = new List<double>();
			a_.Add(sum_xxxx / Time_Series.Count);
			a_.Add(sum_xxx / Time_Series.Count);
			a_.Add(sum_xx / Time_Series.Count);

			List<double> b_ = new List<double>();
			b_.Add(sum_xxx / Time_Series.Count);
			b_.Add(sum_xx / Time_Series.Count);
			b_.Add(sum_x / Time_Series.Count);

			List<double> c_ = new List<double>();
			c_.Add(sum_xx / Time_Series.Count);
			c_.Add(sum_x / Time_Series.Count);
			c_.Add(1);


			matrix.Add(a_);
			matrix.Add(b_);
			matrix.Add(c_);

			List<Double> y_ = new List<double>();
			y_.Add(sum_yxx / Time_Series.Count);
			y_.Add(sum_yx / Time_Series.Count);
			y_.Add(sum_y / Time_Series.Count);

			List<double> result = gauss(matrix, y_, 3);

			//double a = (sum_yx - sum_x * sum_y / Time_Series.Count) / (sum_xx - sum_x_x / Time_Series.Count);
			double a = result[0];
			//double b = (sum_y - a * sum_x) / Time_Series.Count;
			double b = result[1];
			double c = result[2];

			for (int i = 0; i < Time_Series.Count; i++)
			{
				dimensions.Add(new Dimension(Time_Series[i].Time, a * (i + 1) * (i + 1) + b * (i + 1) + c));
			}

			for (int i = Time_Series.Count; i < m + Time_Series.Count; i++)
			{
				DateTime dateTime = dimensions[dimensions.Count - 1].Time + (dimensions[dimensions.Count - 1].Time - dimensions[dimensions.Count - 2].Time);
				dimensions.Add(new Dimension(dateTime, a * (i + 1) * (i + 1) + b * (i + 1) + c));
			}
		}


		return dimensions;
	}
	public List<Dimension> MovingAverageMethod(int n, int m)
	{
		List<Dimension> dimensions = new List<Dimension>();

		for (int i = 0; i < (n - 1) / 2; i++)
		{
			dimensions.Add(new Dimension(Time_Series[i].Time, Time_Series[i].Value));
		}

		for (int i = (n - 1) / 2; i < Time_Series.Count - (n - 1) / 2; i++)
		{
			double value = 0;
			for (int j = -(n - 1) / 2; j <= (n - 1) / 2; j++)
			{
				value += Time_Series[i + j].Value;
			}
			value /= n;
			dimensions.Add(new Dimension(Time_Series[i].Time, value));
		}

		for (int i = Time_Series.Count - (n - 1) / 2; i < Time_Series.Count; i++)
		{
			dimensions.Add(new Dimension(Time_Series[i].Time, Time_Series[i].Value));
		}

		if (m >= 1)
		{
			for (int i = 0; i < m; i++)
			{
				double value = 0;
				for(int j = 0; j < n; j++)
				{
					if(i + j - n >= 0)
					{
						value += dimensions[Time_Series.Count - n + j + i].Value;
					}
					else
						value += Time_Series[Time_Series.Count - n + j + i].Value;
				}
				value /= n;

				double new_value = value + (dimensions[dimensions.Count - 1].Value - dimensions[dimensions.Count - 2].Value)/n;
				DateTime dateTime = dimensions[dimensions.Count - 1].Time + (dimensions[dimensions.Count - 1].Time - dimensions[dimensions.Count - 2].Time);

				dimensions.Add(new Dimension(dateTime, new_value));
			}
		}

		return dimensions;
	}
	public List<Dimension> ExponentialSmoothingMethod(double a)
	{
		List<Dimension> dimensions = new List<Dimension>();

		dimensions.Add(new Dimension(Time_Series[0].Time, Time_Series[0].Value));

		for(int i = 1; i < Time_Series.Count; i++)
		{
			double value = a * Time_Series[i - 1].Value + (1 - a) * dimensions[i - 1].Value;
			dimensions.Add(new Dimension(Time_Series[i].Time, value));
		}

		double temp = a * Time_Series[Time_Series.Count - 1].Value + (1 - a) * dimensions[Time_Series.Count - 1].Value;
		DateTime dateTime = Time_Series[Time_Series.Count - 1].Time + (Time_Series[Time_Series.Count - 1].Time - Time_Series[Time_Series.Count - 2].Time);
		dimensions.Add(new Dimension(dateTime , temp));


		return dimensions;
	}
	public List<Dimension> FFT()
	{
		List<Complex> complices = new List<Complex>();

		for(int i = 0; i < Time_Series.Count; i++)
		{
			complices.Add(new Complex(Time_Series[i].Value, 0));
		}

		int k = 0;
		while(true)
		{
			if(Math.Pow(2 , k) >= complices.Count)
			{
				k++;
				break;
			}
			else
			{
				k++;
			}
		}

		while (true)
		{
			if (complices.Count == Math.Pow(2, k))
			{
				break;
			}
			else
			{
				complices.Add(new Complex(0, 0));
			}		
		}

		fft(complices, false);
		for(int i = 0; i < complices.Count; i++)
		{
			Complex complex = new Complex(complices[i].Real * complices[i].Real , complices[i].Imaginary * complices[i].Imaginary);
			complices[i] = complex;
		}
		fft(complices, true);

		List<Dimension> dimensions = new List<Dimension>();
		for(int i = 0; i < Time_Series.Count; i++)
		{
			Dimension dimension = new Dimension(new DateTime(i+1, 1, 1), complices[i].Real);
			dimensions.Add(dimension);
		}

		return dimensions;
	}
	private void fft(List<Complex> a, bool invert)
	{
		int n = a.Count;

		for (int i = 1, j = 0; i < n; ++i)
		{
			int bit = n >> 1;
			for (; j >= bit; bit >>= 1)
				j -= bit;
			j += bit;
			if (i < j)
			{
				Complex temp = a[i];
				a[i] = a[j];
				a[j] = temp;
			}				
		}

		for (int len = 2; len <= n; len <<= 1)
		{
			double ang = 2 * Math.PI / len;
			if(invert == true)
			{
				ang *= -1;
			}
			else
			{
				ang *= 1;
			}

			Complex wlen = new Complex(Math.Cos(ang), Math.Sin(ang));
			
			for (int i = 0; i < n; i += len)
			{
				Complex w = new Complex(1 , 0);
				for (int j = 0; j < len / 2; ++j)
				{
					Complex u = a[i + j],  v = a[i + j + len / 2] * w;
					a[i + j] = u + v;
					a[i + j + len / 2] = u - v;
					w *= wlen;
				}
			}
		}
		if (invert)
			for (int i = 0; i < n; ++i)
				a[i] /= n;
	}
	public void SetTimeSeries(List<Dimension> dimensions)
	{
		Time_Series = dimensions;
	}
	public void LimitDate(DateTime start , DateTime end)
	{
		List<Dimension> NewSeries = new List<Dimension>();

		for(int i = 0; i < Time_Series.Count; i++)
		{
			if (Time_Series[i].Time >= start && Time_Series[i].Time <= end)
				NewSeries.Add(Time_Series[i]);
		}

		Time_Series.Clear();
		Time_Series = NewSeries;
	}
	public void Sort()
	{
		Time_Series.Sort((x, y) => DateTime.Compare(x.Time, y.Time));
	}
	private double Autocorrelation_on_k(int k , List<Dimension> temp)
	{
		double b = 0;

		for(int i = 0; i < temp.Count(); i++)
		{
			b += (temp[i].Value - Avg)* (temp[i].Value - Avg);
		}

		double a = 0;

		for(int i = 0; i < (temp.Count() - k); i++)
		{
			a += (temp[i].Value - Avg) * (temp[i + k].Value - Avg);
		}
		return a/b;
	}
	public List<Dimension> Autocorrelation()
	{
		List<Dimension> dimensions = new List<Dimension>();
		List<Dimension> dimensions_sr = new List<Dimension>();

		for(int i = 1; i < Time_Series.Count(); i++)
		{
			Dimension temp = new Dimension(new DateTime(i + 1, 1, 1), Time_Series[i].Value - Time_Series[i - 1].Value);
			dimensions_sr.Add(temp);
		}

		double Autocorrelation_on_zero = Autocorrelation_on_k(0 , dimensions_sr);

		for (int i = 0; i < dimensions_sr.Count(); i++)
		{
			Dimension temp = new Dimension(new DateTime(i + 1, 1, 1) , Autocorrelation_on_k(i , dimensions_sr) /Autocorrelation_on_zero);
			dimensions.Add(temp);
		}

		return dimensions;
	}
	public void NormalizeOn_Avg()
	{
		for(int i = 0; i < Time_Series.Count; i++)
		{
			Time_Series[i].Value -= Avg; 
		}
	}
	public void NormalizeOn_σ()
	{
		for (int i = 0; i < Time_Series.Count; i++)
		{
			Time_Series[i].Value /= AvgSquareDeviation;
		}
	}
	public TableInfo GetTableInfo()
	{
		TableInfo tableInfo = new TableInfo(NameTimeSeries , Time_Series.Count , Max , Min , Avg , AvgSquareDeviation);
		return tableInfo;
	}
	public void CalculateAvgSquareDeviation()
	{
		double sum = 0;
		for (int i = 0; i < Time_Series.Count; i++)
		{
			sum += (Time_Series[i].Value - Avg) * (Time_Series[i].Value - Avg);
		}
		sum /= (Time_Series.Count - 1);
		sum = Math.Sqrt(sum);

		AvgSquareDeviation = sum;

		if (Math.Abs(AvgSquareDeviation) < e) AvgSquareDeviation = 0;
	}
	public void CalculateAvg()
	{
		double avg = 0;
		for (int i = 0; i < Time_Series.Count; i++)
			avg += Time_Series[i].Value;
		Avg = avg/Time_Series.Count;

		if (Math.Abs(Avg) < e) Avg = 0;
	}
	public void CalculateMax()
	{
		double max = Time_Series[0].Value;
		for (int i = 1; i < Time_Series.Count; i++)
			if (Time_Series[i].Value > max) max = Time_Series[i].Value;
		Max = max;
	}
	public void CalculateMin()
	{
		double min = Time_Series[0].Value;
		for (int i = 1; i < Time_Series.Count; i++)
			if (Time_Series[i].Value < min) min = Time_Series[i].Value;
		Min = min;
	}
	public List<Dimension> GetTimeSeries()
	{
		return Time_Series;
	}
	public TimeSeries()
	{
		Time_Series = new List<Dimension>();
	}
	~TimeSeries()
	{
		Time_Series.Clear();
	}
	public void ClearTimeSeries()
	{
		Time_Series.Clear();
	}
	public void SetColor(Color color_)
	{
		color = color_;
	}
	public void SetNameTimeSeries(String name)
	{
		NameTimeSeries = name;
	}
	public Color GetColor()
	{
		return color;
	}
	public String GetNameTimeSeries()
	{
		return NameTimeSeries;
	}
	public void Set_flag_sequence(bool flag)
	{
		flag_sequence = flag;
	}
	public bool Get_flag_sequence()
	{
		return flag_sequence;
	}
	public void AddDimensionTime(DateTime time , double value)
	{
		Dimension dimension = new Dimension(time, value);
		Time_Series.Add(dimension);
	}
	private List<double> gauss(List<List<double>> a, List<double> y, int n)
	{
		List<double> x = new List<double>();
		for (int i = 0; i < n; i++)
			x.Add(0);
		double max;
		int k, index;
		const double eps = 0.00001;  // точность
		
		k = 0;
		while (k < n)
		{
			// Поиск строки с максимальным a[i][k]
			max = Math.Abs(a[k][k]);
			index = k;
			for (int i = k + 1; i < n; i++)
			{
				if (Math.Abs(a[i][k]) > max)
				{
					max = Math.Abs(a[i][k]);
					index = i;
				}
			}
			// Перестановка строк
			if (max < eps)
			{
				return x; //-------------------------------------
			}
			for (int j = 0; j < n; j++)
			{
				double temp1 = a[k][j];
				a[k][j] = a[index][j];
				a[index][j] = temp1;
			}

			double temp = y[k];
			y[k] = y[index];
			y[index] = temp;
			
			for (int i = k; i < n; i++)
			{
				double temp1 = a[i][k];
				if (Math.Abs(temp1) < eps) continue; // для нулевого коэффициента пропустить
				for (int j = 0; j < n; j++)
					a[i][j] = a[i][j] / temp1;
				y[i] = y[i] / temp1;
				if (i == k) continue; // уравнение не вычитать само из себя
				for (int j = 0; j < n; j++)
					a[i][j] = a[i][j] - a[k][j];
				y[i] = y[i] - y[k];
			}
			k++;
		}
		// обратная подстановка
		for (k = n - 1; k >= 0; k--)
		{
			x[k] = y[k];
			for (int i = 0; i < k; i++)
				y[i] = y[i] - a[i][k] * x[k];
		}
		return x;
	}
}

public class TableInfo
{
	public string Name { get; set; }
	public int Count { get; set; }
	public double Max { get; set; }
	public double Min { get; set; }
	public double Avg { get; set; }
	public double AvgSquareDeviation { get; set; }

	public TableInfo(string Name , int Count , double Max , double Min , double Avg , double AvgSquareDeviation)
	{
		this.Name = Name;
		this.Max = Max;
		this.Min = Min;
		this.Avg = Avg;
		this.Count = Count;
		this.AvgSquareDeviation = AvgSquareDeviation;
	}

}

