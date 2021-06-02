using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        double point = Math.Sqrt(x * x + y * y);
        return point <= 1.0 ? 10 : point <= 5.0 ? 5 : point <= 10.0 ? 1 : 0;
    }
}
