double F(double p) => 4*Math.Cos(p) + 0.3*p;
double Fi(double p) => 0.3 - 4*Math.Sin(p);


Console.WriteLine(HordMethod(1.5,1.7,0.000001));
Console.WriteLine(TangentMethod(1.5,1.7,0.000001));
Console.WriteLine(CombinedMethod(1.5,1.7,0.000001));

double CombinedMethod(double a, double b, double E) 
{
    double h;
    double x0;
    double x1;
    double x;
    double y;
    double c;

    h = (b - a) / 100;
    x = F(a);
    y = F(a + 2 * h) - 2 * F(a + h) + F(a);

    if (x * y < 0)
    {
        x0 = a; x1 = b; c = b;
    }
    else
    {
        x0 = b; x1 = a; c = a;
    }

    double x2 = (x0*F(c)-c*F(x0)) / (F(c)-F(x0));
    double x3 = x1 - F(x1)/Fi(x1);

    while(Math.Abs(x3-x2)>2*E)
    {
        x0 = x2;
        x2 = (x0 * F(c) - c * F(x0)) / (F(c) - F(x0));
        x1 = x3;
        x3 = x1 - F(x1)/Fi(x1);
    }

    x = (x2 + x3) / 2;

    return x;
}


double TangentMethod(double a, double b, double E) 
{
    double h;
    double x0;
    double x1;
    double x;
    double y;

    h = (b - a) / 100;
    x = F(a);
    y = F(a + 2 * h) - 2 * F(a + h) + F(a);

    if (x * y > 0) x0 = a;
    else x0 = b;

    x1 = x0 - F(x0)/Fi(x0);

    while (Math.Abs(x1 - x0) > E)
    {
        x0 = x1;
        x1 = x0 - F(x0) / Fi(x0);
    }

    x = x1;

    return x;
}

double HordMethod(double a, double b, double E) 
{
    double h;
    double x0;
    double x1;
    double x;
    double y;
    double d;
    double c;

    h = (b - a) / 100;
    y = F(a);
    d = F(a + 2 * h) - 2 * F(a + h) + F(a);

    if (y * d < 0)
    {
        x0 = a;
        c = b;
    }
    else 
    { 
        x0 = b;
        c = a;
    }

    x1 = (x0*F(c) - c*F(x0)) 
        / (F(c) - F(x0));

    while (Math.Abs(x1 - x0) > E) 
    {
        x0 = x1;
        x1 = (x0 * F(c) - c * F(x0))
        / (F(c) - F(x0));
    }

    x = x1;

    return x;
}
