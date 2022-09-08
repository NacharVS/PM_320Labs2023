Mage mage = new Mage(150, 350, "ogre", 60, 40, 30, 10, 150);
FootMan fmEnemy = new FootMan(10, 500, "juga", 60, 35, 30, 8);

while (!mage.isDestroyed && !fmEnemy.isDestroyed)
{
    mage.Attack(fmEnemy);
    Console.WriteLine();
    fmEnemy.Attack(mage);
    Console.WriteLine();
}

if (!mage.isDestroyed)
{
    Console.WriteLine($"{mage.GetName()} is winner");
}
else if (!fmEnemy.isDestroyed)
{
    Console.WriteLine($"{fmEnemy.GetName()} is winner");
}
else
{
   Console.WriteLine("DRAW!");
}

