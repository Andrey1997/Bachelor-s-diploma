using System;
using System.Drawing;
using System.Windows.Media;

public class Dimension
{
	public double Value { get; set; }
	public DateTime Time { get; set; }

	public Dimension(DateTime time_ , double value_)
	{
		Value = value_;
		Time = time_;
	}
	public Dimension()
	{

	}
	public static bool operator > (Dimension c1, Dimension c2)
	{
		return c1.Time > c2.Time;
	}
	public static bool operator < (Dimension c1, Dimension c2)
	{
		return c1.Time < c2.Time;
	}
}
