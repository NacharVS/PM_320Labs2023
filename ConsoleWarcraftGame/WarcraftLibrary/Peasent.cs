﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Peasent : Moveable
    {
        public Peasent(string name, int health = 20, int cost = 10, int lvl = 1, bool isDestroyed = false, int speed = 15, int damage = 0, int attackSpeed = 0) : base(name, health, cost, lvl, isDestroyed, speed, damage, attackSpeed)
        { }

        public void Mining() 
        {
            Console.WriteLine("Is mining");
        }

        public void Choping() 
        {
            Console.WriteLine("Is choping");
        }

        public override string Attack(Unit unit, Blacksmith blacksmith)
        {
            return $"{Name} не может нанести удар.{0}";
        }
    }
}