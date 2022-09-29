double Func1(double x) => x - (10 * Math.Sin(x));
double Func2(double x) => Math.PI - Math.Asin(x/10);

double A = 2;
double B = 3;
double e = 0.00001;


double a = 2;
double b = 3;
double E = 0.000001;

Console.WriteLine(SimpleIterationMethod(A, B, e));
Console.WriteLine(SimpleIterationMethod(a, b, E));


double SimpleIterationMethod(double a, double b, double E) 
{
    double x = (b + a) / 2;
    double x_1 = Func2(x);

    while (Math.Abs(x - x_1) < E)
    {
        x = x_1;
        x_1 = Func2(x);
    }

    return x_1;
}



double HalfSolutionMethod(double a, double b, double E)
{
    double c;

    while (Math.Abs(b - a) >= 2 * E)
    {
        c = (b + a) / 2;

        if (Func1(a) * Func1(c) < 0) b = c;
        else a = c;
    }

    return ((b + a) / 2);
}
