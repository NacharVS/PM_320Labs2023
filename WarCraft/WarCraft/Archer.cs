﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft
{
    class Archer : Military
    {
        public int ArrowCount { get; set; } 

        public Archer(string name, int health, int cost,
            int speed, int damage, int attackSpeed, int armor, 
            int arrowCount) : base(name, health, cost, speed, 
                damage, attackSpeed, armor)
        {
            this.ArrowCount = arrowCount;
        }

        public void UpgradeBow(int value)
        {
            ArrowCount += value;
        }

        public override string Attack(int number, Military player1, Military player2) 
        {
            ArrowCount--;
            return $"Archer attacks with damage {Damage}";
        }
    }
}
