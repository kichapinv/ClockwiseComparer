using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        var array = new[]
        {
            new Point { X = 1, Y = 0 },
            new Point { X = -1, Y = 0 },
            new Point { X = 0, Y = 1 },
            new Point { X = 0, Y = -1 },
            new Point { X = 0.01, Y = 1 }
        };
        Array.Sort(array, new ClockwiseComparer());
        foreach (Point e in array)
            Console.WriteLine("{0} {1}", e.X, e.Y);
    }
}

public class Point
{
    public double X;
    public double Y;
}

public class ClockwiseComparer : IComparer
{
    public int Compare(object? x, object? y)
    {
        Point xPoint = (Point)x;
        Point yPoint = (Point)y;
        var angleRadiusX = -Math.Atan2(xPoint.Y, -xPoint.X);
        var angleRadiusY = -Math.Atan2(yPoint.Y, -yPoint.X);  
        return angleRadiusX.CompareTo(angleRadiusY);
    }
}

