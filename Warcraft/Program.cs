GuardTower gt = new GuardTower(100, 20, "guard tower", 10, 15, 1000);
Dragon d = new Dragon(120, 30, "dragon", 100, 10, 10000, 10, 10, 100);
FootMan ft = new FootMan(100, 20, "Foot man", 200, 12, 2000, 4);
Mage m = new Mage(75, 15, "Maga", 25, 10, 1000, 5, 10, 100);

var list = new List<Military>()
{
    //d,
    ft,
    m
};

//while (!ft.IsDestroyed() && !d.IsDestroyed())
//{
//    ft.Attack(d);
//    Console.WriteLine();

//    d.Attack(ft);
//    Console.WriteLine();
//}

ThreadPool.QueueUserWorkItem(delegate { ft.Attack(m);  });
ThreadPool.QueueUserWorkItem(delegate { m.Attack(ft);  });

while (list.Count(x => !x.IsDestroyed()) > 1)
{
    Thread.Sleep(200);
}

Unit winner = ft.IsDestroyed() ? m : ft;
Console.WriteLine($"winner is {winner.GetName()}");
