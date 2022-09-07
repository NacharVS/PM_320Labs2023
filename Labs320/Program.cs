FootMan fm = new FootMan(100, 500, "Pidor", 100, 15, 45, 20);
FootMan fmEnemy = new FootMan(150, 280, "Uebok", 100, 10, 25, 25);

while (fm.isDestroyed || fmEnemy.isDestroyed)
{
    fm.Attack(fmEnemy);
    Console.WriteLine();
    fmEnemy.Attack(fm);
    Console.WriteLine();
}

if (fm.isDestroyed)
{
    Console.WriteLine($"{fmEnemy.GetName()} is winner");
}
else if (fmEnemy.isDestroyed)
{
    Console.WriteLine($"{fm.GetName()} is winner");
}
else
{
   Console.WriteLine("DRAW!");
}

