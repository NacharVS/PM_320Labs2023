﻿// See https://aka.ms/new-console-template for more information
using Labs320;

TestClass unit = new TestClass(100);
unit.HealthChangedEvent += Rage;
unit.HealthChangedEvent += Adrenaline;

unit.TakeDamage(20);
unit.TakeDamage(10);
unit.TakeDamage(15);
unit.TakeDamage(30);
unit.TakeDamage(1); 
unit.TakeDamage(1);


static void Rage()
{
    Console.WriteLine("Rage is activated!");
}

static void Adrenaline()
{
    Console.WriteLine("Op op adrenaline!111");
}

