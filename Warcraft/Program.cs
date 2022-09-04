GuardTower gt = new GuardTower(100, 20, "guard tower", 10, 15, 2);
Dragon d = new Dragon(120, 30, "dragon", 10, 10, 2, 10, 10, 100);
FootMan ft = new FootMan(100, 20, "Foot man", 20, 12, 2, 4);

while (!ft.IsDestroyed() && !d.IsDestroyed())
{
    ft.Attack(d);
    Console.WriteLine();
    d.Attack(ft);
    Console.WriteLine();
}

Unit winner = ft.IsDestroyed() ? d : ft;
Console.WriteLine($"winner is {winner.GetName()}");