using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => r.Expreal(realNumber);
}

public struct RationalNumber
{
    public int A { get; private set; }
    public int B { get; private set; }

    public RationalNumber(int numerator, int denominator)
    {
        A = numerator;
        B = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) => new RationalNumber { A = r1.A * r2.B + r2.A * r1.B, B = r1.B * r2.B }.Reduce();
    


    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) => new RationalNumber { A = r1.A * r2.B - r2.A * r1.B, B = r1.B * r2.B }.Reduce();

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) => new RationalNumber { A = r1.A * r2.A, B = r1.B * r2.B }.Reduce();

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) => r2.A * r1.B >= 0 ? new RationalNumber { A = r1.A * r2.B, B = r2.A * r1.B }.Reduce() : 
                                                                                                        new RationalNumber { A = (r1.A * r2.B) * (-1), B = (r2.A * r1.B) * (-1) }.Reduce();

    public RationalNumber Abs() => new RationalNumber { A = Math.Abs(A), B = Math.Abs(B) };

    public RationalNumber Reduce()
    {
        int tempA = A;
        if (A < 0)
            tempA = A * (-1);
        if (B < 0)
        {
            B *= -1;
            A *= -1;
        }
            
        int gcd = GCD(tempA, B);
        return gcd <= 0 ? new RationalNumber(A, B) : new RationalNumber(A / gcd, B / gcd);
    }

    public RationalNumber Exprational(int power) => power > 0 ? new RationalNumber { A = (int)Math.Pow(A, power), B = (int)Math.Pow(B, power) } : new RationalNumber { A = (int)Math.Pow(B, Math.Abs(power)), B = (int)Math.Pow(A, Math.Abs(power)) }.Reduce();

    public double Expreal(int baseNumber) => Math.Pow(baseNumber, (double)A / (double)B);

    public int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
}